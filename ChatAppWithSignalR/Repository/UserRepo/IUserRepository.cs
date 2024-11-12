using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Repository.UserRepo
{
    public interface IUserRepository
    {
        Task<ChatUser> GetUserAsync(string id);
        Task<IEnumerable<ChatUser>> GetUsersAsync();
        Task<UserData?> GetUserData(string userId);
        Task SavePhotoAsync(string userId, string photo);
    }
}
