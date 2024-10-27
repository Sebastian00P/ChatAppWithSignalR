using ChatAppWithSignalR.Repository.UserRepo;
using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository chatUserRepository;
        public UserService(IUserRepository chatUserRepository)
        {
            this.chatUserRepository = chatUserRepository;
        }
        public async Task<List<ChatUser>> GetAllAsync()
        {
            var users = await chatUserRepository.GetUsersAsync();
            return users.ToList();
        }

        public Task<ChatUser> GetUserByIdAsync(string id)
        {
            var user = chatUserRepository.GetUserAsync(id);
            return user;
        }
    }
}
