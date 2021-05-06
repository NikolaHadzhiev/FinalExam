using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);


            //mb.Entity<User>().HasData(
            //    new User() { Email = "Mubeen@gmail.com", Name = "Mubeen", Password = "123123" },
            //    new User() { Email = "Tahir@gmail.com", Name = "Tahir", Password = "321321" },
            //    new User() { Email = "Cheema@gmail.com", Name = "Cheema", Password = "123321" }
            //    );
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
    }
}
