using Chat.Models;

namespace Chat.Services
{
    public interface IMessageService
    {
        Task SaveMessageAsync(string userName, string message, string? groupName = null);
        Task<List<Message>> GetRecentMessagesAsync(int count = 50);
        Task<List<Message>> GetGroupMessagesAsync(string groupName, int count = 50);
    }
}
