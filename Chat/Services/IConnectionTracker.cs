namespace Chat.Services
{
    public interface IConnectionTracker
    {
        void AddConnection(string connectionId, string userName);
        void RemoveConnection(string connectionId);
        string? GetUserName(string connectionId);
        int GetOnlineUsersCount();
        List<string> GetOnlineUsers();
    }
}
