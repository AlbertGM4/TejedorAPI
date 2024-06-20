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
    public required string CategoryDescription { get; set; }
    public required string CategoryImagesRoute { get; set; }

    public static explicit operator GetCategoryListDTO(Category category)
    {
        return new GetCategoryListDTO()
        {
            CategoryID = category.CategoryID,
            CategoryName = category.Name,
            CategoryDescription = category.Description,
            CategoryImagesRoute = category.ImagesRoute,
        };
    }
}
public class SetCategoryListDTO
{
    public required int CategoryID { get; set; }
    public required string CategoryName { get; set; }
    public required string CategoryDescription { get; set; }
    public required string CategoryImagesRoute { get; set; }

    public static explicit operator Category(SetCategoryListDTO category)
    {
        return new Category()
        {
            CategoryID = category.CategoryID,
            Name = category.CategoryName,
            Description = category.CategoryDescription,
            ImagesRoute = category.CategoryImagesRoute,
        };
    }
}
