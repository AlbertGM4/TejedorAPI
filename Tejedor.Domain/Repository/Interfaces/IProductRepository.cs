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
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Product>> GetProducts();

    /// <summary>
    ///     It returns the Product with the ID in the parameters
    /// </summary>
    /// <param name="productID"> Id of the prodcut to search </param>
    /// <returns> Return the Product, if not, returns null </returns>
    public Task<Product?> GetProduct(int productID);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    public Task AddProducts(IEnumerable<Product> products);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    public Task UpdateProducts(IEnumerable<Product> products);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    public Task DeleteProducts(IEnumerable<Product> products);
}
