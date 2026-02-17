using Chat.Services;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;
        private readonly IConnectionTracker _connectionTracker;
        private readonly IChatGroupService _groupService;

        public ChatHub(ILogger<ChatHub> logger, IConnectionTracker connectionTracker, IChatGroupService groupService)
        {
            _logger = logger;
            _connectionTracker = connectionTracker;
            _groupService = groupService;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            _logger.LogInformation($"Client connected: {Context.ConnectionId}");
            
            // Broadcast online users count
            await BroadcastOnlineUsersCount();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _connectionTracker.RemoveConnection(Context.ConnectionId);
            await BroadcastOnlineUsersCount();
            
            if (exception != null)
            {
                _logger.LogError(exception, $"Client disconnected with error: {Context.ConnectionId}");
            }
            else
            {
                _logger.LogInformation($"Client disconnected: {Context.ConnectionId}");
            }
            
            await base.OnDisconnectedAsync(exception);
        }

        public async Task RegisterUser(string userName)
        {
            _connectionTracker.AddConnection(Context.ConnectionId, userName);
            await BroadcastOnlineUsersCount();
            _logger.LogInformation($"User registered: {userName}");
        }

        public async Task Send(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            _logger.LogInformation($"Message from {user}: {message}");
        }

        public async Task CreateGroup(string name, string creator, bool isPrivate, string? password)
        {
            var success = _groupService.CreateGroup(name, creator, isPrivate, password);
            if (success)
            {
                await Clients.All.SendAsync("GroupsUpdated");
                _logger.LogInformation($"Group created: {name} by {creator}");
            }
        }

        public IEnumerable<GroupInfo> GetPublicGroups(string userName)
        {
            return _groupService.GetAllVisibleGroups(userName);
        }

        public async Task JoinGroup(string groupName, string userName, string? password = null)
        {
            if (_groupService.JoinGroup(groupName, userName, password, out bool alreadyMember))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
                
                // CRITICAL: Send notification to EVERYONE in the group, including the person who just joined
                await Clients.Group(groupName).SendAsync("NewMemberJoin", userName, groupName);
                
                await Clients.All.SendAsync("GroupsUpdated");
            }
            else
            {
                await Clients.Caller.SendAsync("Error", "Invalid group name or password");
            }
        }

        public async Task UpdateGroupName(string oldName, string newName, string userName)
        {
            if (_groupService.UpdateGroupName(oldName, newName, userName))
            {
                await Clients.All.SendAsync("GroupsUpdated");
                await Clients.Group(newName).SendAsync("GroupNameChanged", oldName, newName);
            }
        }

        public async Task SendMessageToGroup(string groupName, string sender, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessageFromGroup", message, sender, groupName);
            _logger.LogInformation($"Group message in {groupName} from {sender}: {message}");
        }

        public async Task NotifyTyping(string userName)
        {
            await Clients.Others.SendAsync("UserTyping", userName);
        }

        private async Task BroadcastOnlineUsersCount()
        {
            var count = _connectionTracker.GetOnlineUsersCount();
            await Clients.All.SendAsync("OnlineUsersCount", count);
        }

        private string GetConnectionId() => Context.ConnectionId;
    }
}
