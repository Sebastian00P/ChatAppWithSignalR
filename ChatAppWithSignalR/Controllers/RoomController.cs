using ChatAppWithSignalR.Helpers;
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
            var model = new CreateRoomViewModel();
            return PartialView("CreatePartialView", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRoom(CreateRoomViewModel chatRoom)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (chatRoom.HasPassword)
            {
                chatRoom.Password = PasswordHasher.CreateMD5FromString(chatRoom.Password);
            }
            var owner = await _userManager.GetUserAsync(User);
            var room = new Room
            {
                OwnerId = owner.Id,
                Id = Guid.NewGuid(),
                MessageIds = new List<Guid>(),
                UserIds = new List<string> { owner.Id },
                ChatName = chatRoom.RoomName,
                HasPassword = chatRoom.HasPassword,
                Password = chatRoom.Password,
            };
            await _roomService.CreateAsync(room);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> GetMessages(string roomId, string? password)
        {
            RoomId = roomId;
            if (string.IsNullOrEmpty(RoomId))
            {
                return NotFound();
            }
            var room = await _roomService.GetRoomById(roomId);
            var providedPassword = "";
            if (room.HasPassword)
            {
                providedPassword = PasswordHasher.CreateMD5FromString(password);
                if(providedPassword != room.Password)
                {
                    return BadRequest(new { message = "Podane hasło jest nieprawidłowe." });
                }
            }
            var roomName = room.ChatName;
            Messages = await _messageService.GetAllByRoomIdAsync(Guid.Parse(RoomId));
            var model = new RoomViewModel()
            {
                Messages = Messages,
                RoomId = RoomId,
                User = User,
                RoomName = roomName
            };

            return View(model);
        }

        public async Task<IActionResult> PasswordPartialView(string roomId)
        {
            var model = new PasswordRoomViewModel()
            {
                RoomId = roomId,
                Password = ""
            };
            return PartialView("PasswordPartialView", model);
        }

    }
}
