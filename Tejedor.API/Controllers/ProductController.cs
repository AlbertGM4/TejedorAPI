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
    public ProductController(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    [HttpGet(Name = "getProducts")]
    public IEnumerable<ProductListDTO> GetAllProducts()
    {
        return ProductRepository.GetProducts().Select(x => (ProductListDTO) x);        
    }

    //1 producto

    //Añadir / Modificar / quitar 
}