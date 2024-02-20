using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class OatMealDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public DbSet<Inventory> Inventories { get; set; }

    public DbSet<Store> Stores { get; set; }

    public OatMealDbContext(DbContextOptions options) : base(options)
    {
        
    }

 
}