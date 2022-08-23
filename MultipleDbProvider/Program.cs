using Microsoft.EntityFrameworkCore;
using MultipleDbProvider.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var dbProvider = builder.Configuration.GetValue("Provider", "SqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(
    options => _ = dbProvider switch
    {
        "PostGreSql" => options.UseNpgsql(builder.Configuration.GetConnectionString("PostGreConnection"),
        x => x.MigrationsAssembly("MultipleDbProvider.Infrastructure.PostGreMigrations")
        ),

        "SqlServer" => options.UseSqlServer(
            builder.Configuration.GetConnectionString("SqlServerConnection"),
            x => x.MigrationsAssembly("MultipleDbProvider.Infrastructure.SqlServerMigrations")
            ),

        _ => throw new Exception($"Unsupported provider: {dbProvider}")
    });

builder.Services.AddScoped(typeof(ApplicationDbContextInitialier));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbInitialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialier>();
await dbInitialiser.InitialiseAsync();
scope.Dispose();

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/products", (ApplicationDbContext _context) => _context.Products.ToList());

app.Run();
