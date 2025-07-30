using EmployeeManagementProject.Domain_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementProject.Infrastructure_Layer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
