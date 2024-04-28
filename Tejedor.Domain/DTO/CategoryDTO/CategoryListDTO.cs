using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.CategoryDTO;

public class GetCategoryListDTO
{
    public required int CategoryID { get; set; }
    public required string CategoryName { get; set; }

    public static explicit operator GetCategoryListDTO(Category category)
    {
        return new GetCategoryListDTO()
        {
            CategoryID = category.CategoryID,
            CategoryName = category.Name
        };
    }
}
public class SetCategoryListDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required int CategoryID { get; set; }

    public static explicit operator Category(SetCategoryListDTO category)
    {
        return new Category()
        {
            Name = category.Name,
            Description = category.Description,
            CategoryID = category.CategoryID
        };
    }
}
