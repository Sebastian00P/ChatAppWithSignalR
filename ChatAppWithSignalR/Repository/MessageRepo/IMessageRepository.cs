using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Repository.MessageRepo
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessageAsync(Message message);
        Task<IEnumerable<Message>> GetAllMessagesAsync();
        Task<IEnumerable<Message>> GetMessagesInRoomAsync(Guid roomId);
    }
}
