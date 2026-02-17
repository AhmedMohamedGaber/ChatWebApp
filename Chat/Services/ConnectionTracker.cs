using System.Collections.Concurrent;

namespace Chat.Services
{
    public class ConnectionTracker : IConnectionTracker
    {
        private readonly ConcurrentDictionary<string, string> _connections = new();
        private readonly ILogger<ConnectionTracker> _logger;

        public ConnectionTracker(ILogger<ConnectionTracker> logger)
        {
            _logger = logger;
        }

        public void AddConnection(string connectionId, string userName)
        {
            _connections.TryAdd(connectionId, userName);
            _logger.LogInformation($"User {userName} connected with ID {connectionId}. Total online: {GetOnlineUsersCount()}");
        }

        public void RemoveConnection(string connectionId)
        {
            if (_connections.TryRemove(connectionId, out var userName))
            {
                _logger.LogInformation($"User {userName} disconnected. Total online: {GetOnlineUsersCount()}");
            }
        }

        public string? GetUserName(string connectionId)
        {
            _connections.TryGetValue(connectionId, out var userName);
            return userName;
        }

        public int GetOnlineUsersCount()
        {
            return _connections.Count;
        }

        public List<string> GetOnlineUsers()
        {
            return _connections.Values.Distinct().ToList();
        }
    }
}
