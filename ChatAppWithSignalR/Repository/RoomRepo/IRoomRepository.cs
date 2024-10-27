using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Repository.RoomRepo
{
    public interface IRoomRepository
    {
        Task CreateRoomAsync(Room room);
        Task DeleteRoomAsync(Guid roomId);
        Task<Room> GetRoomAsync(Guid roomId);
        Task<IEnumerable<Room>> GetRoomsAsync();
    }
}
