using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Services.RoomServices
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllAsync();
        Task CreateAsync(Room room);
        Task DeleteAsync(Guid roomId, string currentUserId);
    }
}
