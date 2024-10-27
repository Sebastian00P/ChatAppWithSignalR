using ChatAppWithSignalR.Data;
using ChatAppWithSignalR.Mappers;
using ChatAppWithSignalR.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChatAppWithSignalR.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChatUser> GetUserAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? throw new Exception("No user found") : user.ToModel();
        }

        public async Task<IEnumerable<ChatUser>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            List<ChatUser> result = new();

            users.ForEach(user =>
            {
                result.Add(user.ToModel());
            });

            return result;
        }
    }
}
