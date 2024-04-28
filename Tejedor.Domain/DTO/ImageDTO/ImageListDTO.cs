using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.ImageDTO;

public class GetImageListDTO
{
    public required int ImageID { get; set; }
    public required int ProductID { get; set; }

    public static explicit operator GetImageListDTO(Image image)
    {
        return new GetImageListDTO()
        {
            ImageID = image.ImageID,
            ProductID = image.ProductID
        };
    }
}
public class SetImageListDTO
{
    public required int ProductID { get; set; }

    public static explicit operator Image(SetImageListDTO image)
    {
        return new Image()
        {
            ProductID = image.ProductID,

        };
    }
}
