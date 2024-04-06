using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly TejedorDBContext _dbContext;
        public ProductRepository(TejedorDBContext context) 
        {
            _dbContext = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products;
        }
    }
}
