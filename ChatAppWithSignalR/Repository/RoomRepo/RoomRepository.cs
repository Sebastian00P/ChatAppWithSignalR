using ChatAppWithSignalR.Data;
using ChatAppWithSignalR.Mappers;
using ChatAppWithSignalR.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteRoomAsync(Guid roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);

            if (room != null)
            {
                room.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Room> GetRoomAsync(Guid roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            return room == null ? throw new Exception("No room found") : room.ToModel();
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            var rooms = await _context.Rooms
             .Include(r => r.Users)
             .Include(r => r.Messages)
             .Where(r => r.IsActive)
             .ToListAsync();

            return rooms.Select(room => room.ToModel()).ToList();
        }
    }
}
