using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try {
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch(Exception ex) {
    logger.LogError(ex, "An error occured during migration");
}


app.Run();



// dotnet watch --no-hot-reload
// dotnet ef migrations add InitialCreate -o Data/Migrations
// dotnet ef database update

// dotnet ef migrations add "InitialCreate" --project Infrastructure --output-dir Data/Migrations/  --startup-project API 
// dotnet ef migrations remove --project Infrastructure --startup-project API 

// dotnet ef --project .\ProjectK.Main --startup-project .\ProjectK.Main migrations add "MigrationName"
// dotnet ef --project .\ProjectK.Main --startup-project .\ProjectK.Main migrations remove
// dotnet ef --project .\ProjectK.Main --startup-project .\ProjectK.Main database update
// dotnet ef --project .\ProjectK.Main --startup-project .\ProjectK.Main migrations script --idempotent --output "script.sql" --context SQLDBContext