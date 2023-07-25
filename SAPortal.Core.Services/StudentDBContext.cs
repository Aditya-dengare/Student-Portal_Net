using Microsoft.EntityFrameworkCore;
using SAPortal.Core.Contracts;

namespace SAPortal.Core.Services
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options) 
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<CourseName> CourseNames { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}
