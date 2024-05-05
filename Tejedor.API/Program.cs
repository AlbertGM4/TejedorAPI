using Microsoft.EntityFrameworkCore;
using Tejedor.Infrastructure;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TejedorDBContext>(options =>
{
    // To use string connection (appsettings.json) and put migrations on "Tejedor.API"
    options.UseSqlServer(builder.Configuration.GetConnectionString("TejedorConnection"), options => options.MigrationsAssembly("Tejedor.API"));
});

// Service Injection
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IImageRepository, ImageRepository>();
builder.Services.AddTransient<IOrderLineRepository, OrderLineRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();

// First Migration
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<TejedorDBContext>();
//    context.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
