using Microsoft.EntityFrameworkCore;

namespace TestApi.Models
{
    public class Context:DbContext 
    {
        public DbSet<Dog> Dog { get; set; }

        public DbSet<Breed> Breed { get; set; }

        public DbSet<StatusModel> Status { get; set; }

        public Context(DbContextOptions<Context>options):base(options)
        {
                
        }
    }
}
