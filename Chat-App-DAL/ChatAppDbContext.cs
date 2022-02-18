using Microsoft.EntityFrameworkCore;

namespace Chat_App_DAL.Models
{

    // Class responsible for allowing operations to be performed on the database
    public class ChatAppDbContext : DbContext
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
        }

        // Turning model classes into a set of model objects aka allowing there to be rows
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Channel> Channels{ get; set; }


    }
}
