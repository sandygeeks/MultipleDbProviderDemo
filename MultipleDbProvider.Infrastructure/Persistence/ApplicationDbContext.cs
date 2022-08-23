using Microsoft.EntityFrameworkCore;
using MultipleDbProvider.Domain.Entities;

namespace MultipleDbProvider.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
