using ChatAppWithSignalR.Data;
using ChatAppWithSignalR.Mappers;
using ChatAppWithSignalR.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChatAppWithSignalR.Repository.MessageRepo
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
            _context.Messages.Add(message.ToEntity());
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            var messages = await _context.Messages.ToListAsync();
            List<Message> result = new();

            messages.ForEach(message =>
            {
                result.Add(message.ToModel());
            });

            return result;
        }

        public async Task<IEnumerable<Message>> GetMessagesInRoomAsync(Guid roomId)
        {
            var messages = await _context.Messages.Where(m => m.ChatRoomId == roomId)
                .OrderBy(x => x.CreationTime).ToListAsync();
            List<Message> result = new();

            messages.ForEach(message =>
            {
                result.Add(message.ToModel());
            });

            return result;
        }
    }
}
