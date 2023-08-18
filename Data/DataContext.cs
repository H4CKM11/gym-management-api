using gym_management_api.Model;
using Microsoft.EntityFrameworkCore;

namespace gym_management_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}