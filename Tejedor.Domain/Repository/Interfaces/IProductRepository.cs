using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.Repository.Interfaces;

public interface IProductRepository
{
    /// <summary>
    ///     It search for all the products in the database
    /// </summary>
    /// <returns> Return all the products </returns>
    public Task<IEnumerable<Product>> GetProducts();

    /// <summary>
    ///     It search for a product by the ID in the parameters
    /// </summary>
    /// <param name="productID"> Id of the prodcut to search </param>
    /// <returns> Return the Product, if not, returns null </returns>
    public Task<Product?> GetProduct(int productID);

    /// <summary>
    ///     It adds all the products in the IEnumerable into the database
    /// </summary>
    /// <param name="products"></param>
    public Task AddProducts(IEnumerable<Product> products);

    /// <summary>
    ///     It updates all the products in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="products"></param>
    public Task UpdateProducts(IEnumerable<Product> products);

    /// <summary>
    ///     It delete all the products in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="products"></param>
    public Task DeleteProducts(IEnumerable<Product> products);
}
