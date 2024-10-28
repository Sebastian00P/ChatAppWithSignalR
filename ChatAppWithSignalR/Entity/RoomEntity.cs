using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChatAppWithSignalR.Entity
{
    public class RoomEntity
    {
        [Key]
        public Guid ChatRoomId { get; set; }
        public required string ChatName { get; set; }
        public required string OwnerId { get; set; }
        public required bool IsActive { get; set; }
        public required bool HasPassword { get; set; }
        public string? Password { get; set; }
        public ICollection<MessageEntity>? Messages { get; set; }
        public ICollection<IdentityUser>? Users { get; set; }
    }
}
