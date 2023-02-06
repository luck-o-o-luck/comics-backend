using ComicsBackend.Comics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Comics.DataAccess;

public class ComicsDbContext : DbContext
{
    public DbSet<ComicBook> ComicBooks => Set<ComicBook>();
    public ComicsDbContext() => Database.EnsureCreated();
    
    public ComicsDbContext(DbContextOptions<ComicsDbContext> options) :
        base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=comics.db");
    }
}