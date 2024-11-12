using ChatAppWithSignalR.Entity;
using ChatAppWithSignalR.ViewModels;

namespace ChatAppWithSignalR.Mappers
{
    public static class UserDataMapper
    {
        public static UserData ToModel(this UserDataEntity entity)
        {
            return new UserData
            {
                Id = entity.Id,
                UserId = entity.UserId,
                UserPhoto = entity.UserPhoto
            };
        }

        public static UserDataEntity ToEntity(this UserData entity)
        {
            return new UserDataEntity
            {
                Id = entity.Id,
                UserId = entity.UserId,
                UserPhoto = entity.UserPhoto
            };
        }
    }
}
