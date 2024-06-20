using Microsoft.EntityFrameworkCore;
using Tejedor.Infrastructure.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Tejedor.Infrastructure;

public class TejedorDBContext : DbContext
{
    public TejedorDBContext(DbContextOptions<TejedorDBContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<User> Users { get; set; }
}
