using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Services.UserService
{
    public interface IUserService
    {
        Task<List<ChatUser>> GetAllAsync();
        Task<ChatUser> GetUserByIdAsync(string id);
    }
}
