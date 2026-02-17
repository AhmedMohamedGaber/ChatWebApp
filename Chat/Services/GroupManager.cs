using System.Collections.Concurrent;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Chat.Services
{
    public class GroupInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Creator { get; set; } = string.Empty;
        public bool IsPrivate { get; set; }
        public string? Password { get; set; }
        public HashSet<string> Members { get; set; } = new(StringComparer.OrdinalIgnoreCase);
        public int MemberCount => Members.Count;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public interface IChatGroupService
    {
        bool CreateGroup(string name, string creator, bool isPrivate, string? password);
        IEnumerable<GroupInfo> GetAllVisibleGroups(string userName);
        bool JoinGroup(string name, string userName, string? password, out bool alreadyMember);
        bool UpdateGroupName(string oldName, string newName, string requestor);
        int GetTotalGroupsCount();
    }

    public class ChatGroupService : IChatGroupService
    {
        private readonly ConcurrentDictionary<string, GroupInfo> _groups = new();

        public bool CreateGroup(string name, string creator, bool isPrivate, string? password)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (_groups.ContainsKey(name)) return false;
            
            var group = new GroupInfo
            {
                Name = name,
                Creator = creator,
                IsPrivate = isPrivate,
                Password = password
            };
            return _groups.TryAdd(name, group);
        }

        // Show public groups to everyone, and private groups ONLY to their creators OR members
        public IEnumerable<GroupInfo> GetAllVisibleGroups(string userName) 
        {
            return _groups.Values
                .Where(g => !g.IsPrivate || 
                            g.Creator.Equals(userName, StringComparison.OrdinalIgnoreCase) ||
                            g.Members.Contains(userName)) 
                .OrderByDescending(g => g.CreatedAt)
                .ToList();
        }

        public bool JoinGroup(string name, string userName, string? password, out bool alreadyMember)
        {
            alreadyMember = false;
            if (!_groups.TryGetValue(name, out var group)) return false;
            
            // Allow joining if public OR if password matches
            if (group.IsPrivate && !string.IsNullOrEmpty(group.Password) && group.Password != password) return false;
            
            lock(group.Members)
            {
                alreadyMember = !group.Members.Add(userName);
            }
            return true;
        }

        public bool UpdateGroupName(string oldName, string newName, string requestor)
        {
            if (string.IsNullOrWhiteSpace(newName) || _groups.ContainsKey(newName)) return false;
            if (!_groups.TryGetValue(oldName, out var group)) return false;
            if (group.Creator != requestor) return false;

            if (_groups.TryRemove(oldName, out var removedGroup))
            {
                removedGroup.Name = newName;
                return _groups.TryAdd(newName, removedGroup);
            }
            return false;
        }

        public int GetTotalGroupsCount() => _groups.Count;
    }
}
