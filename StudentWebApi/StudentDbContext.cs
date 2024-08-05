using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
        :base(options){ }

        public DbSet<Student>  Students { get; set; }
    }
}
