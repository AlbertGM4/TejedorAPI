using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.ProductDTO;

public class ProductListDTO
{
    public int IDProduct;
    public string ProductName;
    public float ProductPrice;

    public static explicit operator ProductListDTO(Product product)
    {
        return new ProductListDTO()
        {
            IDProduct = product.ProductID,
            ProductName = product.Name,
            ProductPrice = product.Price
        };
    }
}
