using ChatAppWithSignalR.Repository.MessageRepo;
using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public async Task<List<Message>> GetAllByRoomIdAsync(Guid roomId)
        {
            var messages = await messageRepository.GetMessagesInRoomAsync(roomId);
            return messages.ToList();
        }

        public async Task CreateMessageAsync(Message message)
        {
            await messageRepository.CreateMessageAsync(message);
        }
    }
}
