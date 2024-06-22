using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.PromotionDTO;

public class GetPromotionListDTO
{
    public int PromotionID { get; set; }
    public required int Code { get; set; }
    public required string Description { get; set; }
    public required decimal Discount { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int? MaxUses { get; set; }
    public int? UsesCount { get; set; }

    public static explicit operator GetPromotionListDTO(Promotion promotion)
    {
        return new GetPromotionListDTO
        {
            PromotionID = promotion.PromotionID,
            Code = promotion.Code,
            Description = promotion.Description,
            Discount = promotion.Discount,
            ExpirationDate = promotion.ExpirationDate,
            MaxUses = promotion.MaxUses,
            UsesCount = promotion.UsesCount
        };
    }
}

public class SetPromotionListDTO
{
    public int Code { get; set; }
    public required string Description { get; set; }
    public required decimal Discount { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int? MaxUses { get; set; }
    public int? UsesCount { get; set; }

    public static explicit operator Promotion(SetPromotionListDTO promotionDto)
    {
        return new Promotion
        {
            Code = promotionDto.Code,
            Description = promotionDto.Description,
            Discount = promotionDto.Discount,
            ExpirationDate = promotionDto.ExpirationDate,
            MaxUses = promotionDto.MaxUses,
            UsesCount = promotionDto.UsesCount
        };
    }
}
