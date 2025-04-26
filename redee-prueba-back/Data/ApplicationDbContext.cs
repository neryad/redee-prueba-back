using Microsoft.EntityFrameworkCore;
using redee_prueba_back.Entities;

namespace redee_prueba_back.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }



           public DbSet<Company> Companies { get; set; }
    }
}
