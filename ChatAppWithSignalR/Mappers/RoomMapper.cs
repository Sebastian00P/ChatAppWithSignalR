using ChatAppWithSignalR.Entity;
using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Mappers
{
    public static class RoomMapper
    {
        public static Room ToModel(this RoomEntity roomEntity)
        {
            return new Room
            {
                Id = roomEntity.ChatRoomId,
                ChatName = roomEntity.ChatName,
                OwnerId = roomEntity.OwnerId,
                HasPassword = roomEntity.HasPassword,
                Password = roomEntity.Password,
                MessageIds = roomEntity.Messages?.Select(m => m.MessageId).ToList() ?? new(),
                UserIds = roomEntity.Users?.Select(u => u.Id).ToList() ?? new(),
            };
        }

        public static RoomEntity ToEntity(this Room room)
        {
            return new RoomEntity
            {
                ChatRoomId = room.Id,
                ChatName = room.ChatName,
                IsActive = true,
                HasPassword = room.HasPassword,
                Password = room.Password,
                OwnerId = room.OwnerId,
            };
        }
    }
}
