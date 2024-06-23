using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Tejedor.Infrastructure;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

/*
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()); // Permitir credenciales
});
*/

// Cargar configuración desde appsettings.json o configuración de entorno
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

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
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderLineRepository, OrderLineRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IPromotionRepository, PromotionRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// JWT Configuration
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TejedorDBContext>();
    db.Database.Migrate();
};

// First Migration
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<TejedorDBContext>();
//    context.Database.Migrate();
//}

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseCors("AllowOrigin"); // Aplicar política CORS en desarrollo
}

app.UseHttpsRedirection();

/*
app.UseCors(options =>
{
    options.AllowAnyMethod(); // Permitir cualquier método HTTP
    options.AllowAnyHeader(); // Permitir cualquier encabezado HTTP
});
*/

app.UseAuthentication(); // Añadir autenticación
// app.UseAuthorization();

app.MapControllers();

app.Run();
