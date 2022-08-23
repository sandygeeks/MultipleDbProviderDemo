using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultipleDbProvider.Domain.Entities;

namespace MultipleDbProvider.Infrastructure.Persistence;
public class ApplicationDbContextInitialier
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialier(IConfiguration config, ApplicationDbContext context)
    {
        _config = config;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        _context.Database.EnsureCreated();

        var dbProvider = _config.GetRequiredSection("Provider").Value;

        _context.Products.RemoveRange(_context.Products);

        if (dbProvider == "SqlServer")
            _context.Products.Add(new Product("Sql Server Pen", 50d));
        else if (dbProvider == "PostGreSql")
            _context.Products.Add(new Product("Post Gre Sql Pen", 80d));

        await _context.SaveChangesAsync();
    }
}
