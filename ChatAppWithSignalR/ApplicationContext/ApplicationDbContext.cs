using ChatAppWithSignalR.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatAppWithSignalR.ApplicationContext
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MessageEntity> Messages { get; set; }

        public DbSet<RoomEntity> Rooms { get; set; }
    }
}
