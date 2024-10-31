using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ChatAppWithSignalR.ViewModels
{
    [Serializable]
    public class RoomViewModel
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public List<Message> Messages { get; set; }
        //public ClaimsPrincipal User { get; set; }
        public string UserId { get; set; }
        public Room Room { get; set; }
        public string Password { get; set; }
    }
}
