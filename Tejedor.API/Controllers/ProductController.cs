using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.ProductDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository ProductRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productRepository"></param>
    public ProductController(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("getProducts")]
    public async Task<IEnumerable<GetProductListDTO>> GetAllProducts()
    {
        return (await ProductRepository.GetProducts()).Select(x => (GetProductListDTO) x);        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="productID"></param>
    /// <returns></returns>
    [HttpGet("getProduct/({productID})")]
    public async Task<ActionResult<GetProductListDTO>> GetProduct([FromRoute] int productID)
    {
        var getProduct = await ProductRepository.GetProduct(productID);
        return getProduct != null ? (GetProductListDTO)getProduct : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    [HttpPost("addProducts")]
    public async Task AddProducts(SetProductListDTO products)
    {
        await ProductRepository.AddProducts(new List<Product>() { (Product) products } );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    [HttpPut("updateProducts")]
    public async Task UpdateProducts(SetProductListDTO products)
    {
        await ProductRepository.UpdateProducts(new List<Product>() { (Product) products });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    [HttpDelete("deleteProducts")]
    public async Task DeleteProducts(SetProductListDTO products)
    {
        await ProductRepository.DeleteProducts(new List<Product>() { (Product) products });
    }
}