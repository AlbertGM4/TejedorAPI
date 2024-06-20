using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.CategoryDTO;
using Tejedor.Infrastructure.DTO.PromotionDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PromotionController : ControllerBase
{
    private readonly IPromotionRepository PromotionRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="promotionRepository"></param>
    public PromotionController(IPromotionRepository promotionRepository)
    {
        PromotionRepository = promotionRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("getPromotions")]
    public async Task<IEnumerable<GetPromotionListDTO>> GetAllPromotions()
    {
        var promotions = await PromotionRepository.GetPromotions();
        return promotions.Select(p => (GetPromotionListDTO)p);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="promotionID"></param>
    /// <returns></returns>
    [HttpGet("getPromotion/({promotionID})")]
    public async Task<ActionResult<GetPromotionListDTO>> GetPromotion([FromRoute] int promotionID)
    {
        var promotion = await PromotionRepository.GetPromotion(promotionID);
        return promotion != null ? (GetPromotionListDTO)promotion : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="promotionDtos"></param>
    [HttpPost("addPromotions")]
    public async Task<IActionResult> AddPromotions([FromBody] IEnumerable<SetPromotionListDTO> promotionDtos)
    {
        var promotions = promotionDtos.Select(dto => (Promotion)dto).ToList();
        await PromotionRepository.AddPromotions(promotions);
        return CreatedAtAction(nameof(GetAllPromotions), null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="promotions"></param>
    [HttpPut("updatePromotions")]
    public async Task<IActionResult> UpdatePromotions([FromBody] IEnumerable<SetPromotionListDTO> promotionDtos)
    {
        var promotions = promotionDtos.Select(dto => (Promotion)dto).ToList();
        await PromotionRepository.UpdatePromotions(promotions);
        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="promotions"></param>
    [HttpDelete("deletePromotions")]
    public async Task<IActionResult> DeletePromotions([FromBody] IEnumerable<SetPromotionListDTO> promotionDtos)
    {
        var promotions = promotionDtos.Select(dto => (Promotion)dto).ToList();
        await PromotionRepository.DeletePromotions(promotions);
        return NoContent();
    }
}