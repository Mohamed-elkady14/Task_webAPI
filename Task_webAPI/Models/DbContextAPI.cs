using Microsoft.EntityFrameworkCore;

namespace Task_webAPI.Models
{
    public class DbContextAPI: DbContext
    {
        public DbContextAPI()
        {

        }
        public DbContextAPI(DbContextOptions dbContextOptions)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Task_WebAPI;Integrated Security=True");
        }
    }
}
