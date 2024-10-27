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

        public RoomController(IRoomService roomService, UserManager<IdentityUser> userManager)
        {
            _roomService = roomService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _roomService.GetAllAsync();
            return View(model);
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
    }
}
