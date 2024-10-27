using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Repository.UserRepo
{
    public interface IUserRepository
    {
        Task<ChatUser> GetUserAsync(string id);
    }
}
