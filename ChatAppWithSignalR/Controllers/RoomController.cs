using ChatAppWithSignalR.Services.MessageServices;
using ChatAppWithSignalR.Services.RoomServices;
using ChatAppWithSignalR.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppWithSignalR.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMessageService _messageService;
        private static string RoomId = "";
        public List<Message> Messages { get; set; } = new List<Message>();

        public RoomController(IRoomService roomService, UserManager<IdentityUser> userManager, IMessageService messageService)
        {
            _roomService = roomService;
            _userManager = userManager;
            _messageService = messageService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _roomService.GetAllAsync();
            return View(model);
        }
        public async Task<IActionResult> CreatePartialView()
        {
            string roomName = "";
            return PartialView(roomName);
        }
        public async Task<IActionResult> CreateRoom(string chatName)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var owner = await _userManager.GetUserAsync(User);
            var room = new Room
            {
                OwnerId = owner.Id,
                Id = Guid.NewGuid(),
                MessageIds = new List<Guid>(),
                UserIds = new List<string>() { owner.Id },
                ChatName = chatName
            };
            await _roomService.CreateAsync(room);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetMessages(string roomId)
        {
            RoomId = roomId;
            if (string.IsNullOrEmpty(RoomId))
            {
                return NotFound();
            }

            Messages = await _messageService.GetAllByRoomIdAsync(Guid.Parse(RoomId));
            var model = new RoomViewModel()
            {
                Messages = Messages,
                RoomId = RoomId,
                User = User
            };

            return View(model);
        }
    }
}
