using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.ProductDTO;

public class GetProductListDTO
{
    public int ProductID { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImagesRoute { get; set; }
    public int Stock { get; set; }
    public int CategoryID { get; set; }

    public static explicit operator GetProductListDTO(Product product)
    {
        return new GetProductListDTO
        {
            ProductID = product.ProductID,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            ImagesRoute = product.ImagesRoute,
            Stock = product.Stock,
            CategoryID = product.CategoryID
        };
    }
}
public class SetProductListDTO
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImagesRoute { get; set; }
    public int Stock { get; set; }
    public int CategoryID { get; set; }

    public static explicit operator Product(SetProductListDTO productDto)
    {
        return new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Description = productDto.Description,
            ImagesRoute = productDto.ImagesRoute,
            Stock = productDto.Stock,
            CategoryID = productDto.CategoryID
        };
    }
}
