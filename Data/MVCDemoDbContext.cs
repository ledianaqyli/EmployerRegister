using EmployerRegister.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployerRegister.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options ) : base(options) { 
        
        }

        public DbSet<Employee> Employees{ get; set; }

    }
}
