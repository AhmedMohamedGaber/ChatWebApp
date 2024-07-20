using Chat.Contexts;
using Chat.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class ChatHub: Hub
    {
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public async Task Send(string user, string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage",user, message);
            // Database
            ChattingDbContext context = new ChattingDbContext();
            Message messageObj = new Message()
            {
                MessageText = message,
                MessageDate = DateTime.Now,
                UserName = user
            };
            context.Messages.Add(messageObj);
            await context.SaveChangesAsync();
        }

        public async Task JoinGroup(string groupName, string userName)
        {
            await Groups.AddToGroupAsync(GetConnectionId(), groupName);
            await Clients.OthersInGroup(groupName).SendAsync("NewMemeberJoin", userName, groupName);
            _logger.LogInformation(GetConnectionId());
        }

        public async Task SendMessageToGroup(string groupName, string sender, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessageFromGroup", message, sender);
        }

        private string GetConnectionId()
            => Context.ConnectionId;
    }
}
