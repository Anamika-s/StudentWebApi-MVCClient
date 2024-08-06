using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
        :base(options){ }

        public DbSet<Student>  Students { get; set; }
        public DbSet<User>  Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    UserName = "user1",
                    Password = "user1"
                },
                new User
                {
                    Id = 2,
                    UserName = "user2",
                    Password = "user2"
                },
                new User
                {
                    Id = 3,
                    UserName = "user3",
                    Password = "user3"
                }
                );
        }

    }
}
