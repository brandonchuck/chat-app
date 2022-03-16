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

            //specifications for CreatedAt in User table
            modelBuilder.Entity<User>()
               .Property(u => u.CreatedAt)
               .HasDefaultValueSql("now()");

            //specifications for CreatedAt in User table
            modelBuilder.Entity<Channel>()
               .Property(u => u.CreatedAt)
               .HasDefaultValueSql("now()");

            //specifications for CreatedAt in User table
            modelBuilder.Entity<Message>()
               .Property(u => u.CreatedAt)
               .HasDefaultValueSql("now()");
        }

        // Turning model classes into a set of model objects aka allowing there to be rows
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Channel> Channels{ get; set; }


    }
}
