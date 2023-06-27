using Microsoft.EntityFrameworkCore;

namespace FluentValidation.UI.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
