using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ChatAppWithSignalR.ViewModels
{
    public class RoomViewModel
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public List<Message> Messages { get; set; }
        public ClaimsPrincipal User { get; set; }
    }
}
