using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.ProductDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository;
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
    [HttpGet("getProduct/{productID}")]
    public async Task<ActionResult<GetProductListDTO>> GetProduct(int productID)
    {
        var getProduct = await ProductRepository.GetProduct(productID);
        return getProduct != null ? (GetProductListDTO)getProduct : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    [HttpPost("addProducts")]
    public async Task<IActionResult> AddProducts([FromBody] IEnumerable<SetProductListDTO> products)
    {
        var productEntities = products.Select(dto => (Product)dto).ToList();
        await ProductRepository.AddProducts(productEntities);
        return CreatedAtAction(nameof(GetAllProducts), null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    [HttpPut("updateProducts")]
    public async Task<IActionResult> UpdateProducts([FromBody] IEnumerable<SetProductListDTO> products)
    {
        var productEntities = products.Select(dto => (Product)dto).ToList();
        await ProductRepository.UpdateProducts(productEntities);
        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="products"></param>
    [HttpDelete("deleteProducts")]
    public async Task<IActionResult> DeleteProducts([FromBody] IEnumerable<SetProductListDTO> products)
    {
        var productEntities = products.Select(dto => (Product)dto).ToList();
        await ProductRepository.DeleteProducts(productEntities);
        return NoContent();
    }
}
