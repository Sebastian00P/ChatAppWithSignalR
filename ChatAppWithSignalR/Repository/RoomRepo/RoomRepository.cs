using ChatAppWithSignalR.ApplicationContext;
using ChatAppWithSignalR.Mappers;
using ChatAppWithSignalR.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ChatAppWithSignalR.Repository.RoomRepo
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoomAsync(Room room)
        {
            var roomEntity = room.ToEntity();

            // Find the owner user by ID
            var owner = await _context.Users.FindAsync(room.OwnerId);
            if (owner != null)
            {
                roomEntity.OwnerId = owner.Id;
                roomEntity.Users = new List<IdentityUser> { owner };
            }

            _context.Rooms.Add(roomEntity);
            await _context.SaveChangesAsync();
        }
    }
}
