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

        async Task<IEnumerable<Product>> IProductRepository.GetProducts()
        {
            return _dbContext.Products;
        }

        async Task<Product?> IProductRepository.GetProduct(int productID)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == productID);
        }

        async Task IProductRepository.AddProducts(IEnumerable<Product> products)
        {
            _dbContext.Products.AddRange(products);
            await _dbContext.SaveChangesAsync();
        }

        async Task IProductRepository.UpdateProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        async Task IProductRepository.DeleteProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}
