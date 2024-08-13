using Microsoft.EntityFrameworkCore;

namespace ResultPatternOneOf.Application
{
    internal sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
    }

}