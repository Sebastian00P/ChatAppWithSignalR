using ChatAppWithSignalR.Repository.RoomRepo;
using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Services.RoomServices
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            var rooms = await roomRepository.GetRoomsAsync();
            return rooms.ToList();
        }
        public async Task CreateAsync(Room room)
        {
            await roomRepository.CreateRoomAsync(room);
        }

        public async Task DeleteAsync(Guid roomId, string currentUserId)
        {
            var room = await roomRepository.GetRoomAsync(roomId) ?? throw new Exception("No room found with provided ID");

            if (room.OwnerId != currentUserId)
            {
                throw new Exception("Cannot remove another user's room");
            }

            await roomRepository.DeleteRoomAsync(roomId);
        }

        public async Task<Room> GetRoomById(string roomId)
        {
            return await roomRepository.GetRoomAsync(Guid.Parse(roomId));
        }
    }
}
