﻿using Microsoft.EntityFrameworkCore;
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
            return await _dbContext.Products.ToListAsync();
        }

        async Task<Product?> IProductRepository.GetProduct(int productID)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(product => product.ProductID == productID);
        }

        async Task<Product?> IProductRepository.SearchProduct(string productName)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(product => product.Name.Contains(productName));
        }

        async Task IProductRepository.AddProducts(IEnumerable<Product> products)
        {
            _dbContext.Products.AddRange(products);
            await _dbContext.SaveChangesAsync();
        }

        async Task IProductRepository.UpdateProducts(IEnumerable<Product> products)
        {
            _dbContext.Products.UpdateRange(products);
            await _dbContext.SaveChangesAsync();
        }

        async Task IProductRepository.DeleteProducts(IEnumerable<Product> products)
        {
            _dbContext.Products.RemoveRange(products);
            await _dbContext.SaveChangesAsync();
        }
    }
}
