using EmployeeManagerRazor.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerRazor.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
    }
}
