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
    }
}
