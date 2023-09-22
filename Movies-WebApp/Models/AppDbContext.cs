using Microsoft.EntityFrameworkCore;

namespace Movies_WebApp.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
