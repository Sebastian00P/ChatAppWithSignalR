using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<Message>> GetAllByRoomIdAsync(Guid roomId);
        Task CreateMessageAsync(Message message);
    }
}
