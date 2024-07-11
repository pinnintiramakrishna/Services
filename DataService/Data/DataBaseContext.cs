using Microsoft.EntityFrameworkCore;
using DataService.Models;

namespace DataService.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
