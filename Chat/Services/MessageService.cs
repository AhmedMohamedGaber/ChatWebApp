using Chat.Contexts;
using Chat.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Services
{
    public class MessageService : IMessageService
    {
        private readonly ChattingDbContext _context;
        private readonly ILogger<MessageService> _logger;

        public MessageService(ChattingDbContext context, ILogger<MessageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SaveMessageAsync(string userName, string message, string? groupName = null)
        {
            try
            {
                var messageEntity = new Message
                {
                    UserName = userName,
                    MessageText = message,
                    MessageDate = DateTime.UtcNow,
                    GroupName = groupName
                };

                _context.Messages.Add(messageEntity);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation($"Message saved: {userName} - {message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving message");
            }
        }

        public async Task<List<Message>> GetRecentMessagesAsync(int count = 50)
        {
            try
            {
                return await _context.Messages
                    .Where(m => m.GroupName == null)
                    .OrderByDescending(m => m.MessageDate)
                    .Take(count)
                    .OrderBy(m => m.MessageDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving recent messages");
                return new List<Message>();
            }
        }

        public async Task<List<Message>> GetGroupMessagesAsync(string groupName, int count = 50)
        {
            try
            {
                return await _context.Messages
                    .Where(m => m.GroupName == groupName)
                    .OrderByDescending(m => m.MessageDate)
                    .Take(count)
                    .OrderBy(m => m.MessageDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving messages for group {groupName}");
                return new List<Message>();
            }
        }
    }
}
