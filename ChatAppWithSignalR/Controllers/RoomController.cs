using ChatAppWithSignalR.Helpers;
using ChatAppWithSignalR.Services.MessageServices;
using ChatAppWithSignalR.Services.RoomServices;
using ChatAppWithSignalR.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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


        public async Task<IActionResult> GetMessages(string roomId, string? password = "")
        {
            this.HttpContext.Session.Remove("VM");

            RoomId = roomId;
            if (string.IsNullOrEmpty(RoomId))
            {
                return NotFound();
            }
            var room = await _roomService.GetRoomById(roomId);
            var providedPassword = "";
           
            var roomName = room.ChatName;
            Messages = await _messageService.GetAllByRoomIdAsync(Guid.Parse(RoomId));
            var model = new RoomViewModel()
            {
                Messages = Messages,
                RoomId = RoomId,
                UserId = User.Identity.Name,
                RoomName = roomName,
                Room = room,
                Password = password
            };

            try
            {
                this.HttpContext.Session.SetString("VM", JsonConvert.SerializeObject(model));

            }
            catch (Exception ex)
            {

                throw;
            }

            if (!string.IsNullOrEmpty(password))
                providedPassword = PasswordHasher.CreateMD5FromString(password);

            if (room.HasPassword)
            {
                if (providedPassword != room.Password)
                {
                    return BadRequest(new { message = "Podane hasło jest nieprawidłowe." });
                }
            }

            return RedirectToAction(nameof(GetRm), "Room");
        }



        public async Task<IActionResult> GetRm()
        {
            RoomViewModel model = JsonConvert.DeserializeObject<RoomViewModel>(this.HttpContext.Session.GetString("VM"));
            model.Messages = await _messageService.GetAllByRoomIdAsync(Guid.Parse(model.RoomId));

            return View("GetMessages", model);
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
