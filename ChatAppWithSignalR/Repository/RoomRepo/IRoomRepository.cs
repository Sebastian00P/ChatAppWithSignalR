using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Repository.RoomRepo
{
    public interface IRoomRepository
    {
        Task CreateRoomAsync(Room room);
    }
}
