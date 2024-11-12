using ChatAppWithSignalR.Helpers;
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

        public async Task<string> GetUserPhoto(string userId)
        {
            var userData = await chatUserRepository.GetUserData(userId);
            if (userData.UserPhoto == null)
            {
                userData.UserPhoto = DefaultImageSetter.GetDefaultPhoto();
            }
            return userData.UserPhoto;
        }

        public async Task UpdateUserPhotoAsync(string userId, string photo)
        {
            await chatUserRepository.SavePhotoAsync(userId, photo);
        }
    }
}
