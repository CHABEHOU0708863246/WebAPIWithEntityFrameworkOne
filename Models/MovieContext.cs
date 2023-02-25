using Microsoft.EntityFrameworkCore;

namespace WebAPIWithEntityFrameworkOne.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AUXENCE;Database=Movie;User Id=sa;Password=1234; Trusted_Connection=True; Encrypt=False;");
        }
    }
}
