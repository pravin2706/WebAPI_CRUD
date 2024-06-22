using Microsoft.EntityFrameworkCore;
using WebApi_emprepositorycrud.Models;

namespace WebApi_emprepositorycrud.Repository
{
    public class Appdbcontext:DbContext
    {

        public Appdbcontext(DbContextOptions<Appdbcontext> options)
                 : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mydb;Integrated Security=True;");
            }
        }
        public DbSet<Employee> Employees { get; set; }
    }

    
}
