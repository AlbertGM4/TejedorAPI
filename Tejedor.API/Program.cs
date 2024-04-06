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
    options.UseSqlServer(builder.Configuration.GetConnectionString("TejedorConnection"), options => options.MigrationsAssembly("Tejedor.API"));
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();


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
