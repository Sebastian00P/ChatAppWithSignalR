using ChatAppWithSignalR.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ChatAppWithSignalR.Mappers
{
    public static class ChatUserMapper
    {
        public static ChatUser ToModel(this IdentityUser chatUserEntity)
        {
            return new()
            {
                UserName = chatUserEntity.Email,
                Id = chatUserEntity.Id
            };
        }
    }
}
