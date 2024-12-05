using Microsoft.EntityFrameworkCore;

namespace Application.Domain.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, CreateDate=DateTime.Now, Email = "user1@gmail.com", Password = "User1@123" },
                new User { Id = 2, CreateDate = DateTime.Now, Email = "user2@gmail.com", Password = "User2@123" }
            );
        }
    }
}
