using ChatAppWithSignalR.Entity;
using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Mappers
{
    public static class MessageMapper
    {
        public static MessageEntity ToEntity(this Message message)
        {
            return new()
            {
                MessageId = message.Id,
                UserId = message.UserId,
                ChatRoomId = message.ChatRoomId,
                IsActive = message.IsActive,
                CreationTime = message.CreationTime,
                MessageContent = message.MessageContent,
            };
        }

        public static Message ToModel(this MessageEntity message)
        {
            return new()
            {
                MessageContent = message.MessageContent,
                Id = message.MessageId,
                UserId = message.UserId,
                ChatRoomId = message.ChatRoomId,
                IsActive = message.IsActive,
                CreationTime = message.CreationTime,
            };
        }
    }
}
