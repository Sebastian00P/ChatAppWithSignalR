using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Services.UserService
{
    public interface IUserService
    {
        Task<List<ChatUser>> GetAllAsync();
        Task<ChatUser> GetUserByIdAsync(string id);
        Task<string> GetUserPhoto(string userId);
        Task UpdateUserPhotoAsync(string userId, string photo);
    }
}
