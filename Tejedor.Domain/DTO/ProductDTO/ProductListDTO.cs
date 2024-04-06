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
    public required int ProductID { get; set; }
    public required string ProductName { get; set; }
    public required decimal ProductPrice { get; set; }

    public static explicit operator GetProductListDTO(Product product)
    {
        return new GetProductListDTO()
        {
            ProductID = product.ProductID,
            ProductName = product.Name,
            ProductPrice = product.Price
        };
    }
}
public class SetProductListDTO
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public required int CategoryID { get; set; }
    public virtual ICollection<Image>? Images { get; set; }
    public int Stock { get; set; }

    public static explicit operator Product(SetProductListDTO product)
    {
        return new Product()
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryID = product.CategoryID,
            Images  = product.Images,
            Stock = product.Stock,
        };
    }
}
