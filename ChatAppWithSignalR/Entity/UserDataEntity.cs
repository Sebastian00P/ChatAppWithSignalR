using System.ComponentModel.DataAnnotations;

namespace ChatAppWithSignalR.Entity
{
    public class UserDataEntity
    {
        [Key]
        public long Id { get; set; }
        public string UserId { get; set; }
        public string UserPhoto { get; set; }
    }
}
