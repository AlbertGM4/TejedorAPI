using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.OrderLineDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderLineController : ControllerBase
{
    private readonly IOrderLineRepository OrderLineRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderLineRepository"></param>
    public OrderLineController(IOrderLineRepository orderLineRepository)
    {
        OrderLineRepository = orderLineRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("getOrderLine")]
    public async Task<IEnumerable<GetOrderLineListDTO>> GetAllOrderLines()
    {
        return (await OrderLineRepository.GetOrderLines()).Select(x => (GetOrderLineListDTO) x);        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderLineID"></param>
    /// <returns></returns>
    [HttpGet("getOrderLine/({orderLineID})")]
    public async Task<ActionResult<GetOrderLineListDTO>> GetOrderLine([FromRoute] int orderLineID)
    {
        var getOrderLine = await OrderLineRepository.GetOrderLine(orderLineID);
        return getOrderLine != null ? (GetOrderLineListDTO)getOrderLine : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderLines"></param>
    [HttpPost("addOrderLines")]
    public async Task<IActionResult> AddOrderLines([FromBody] IEnumerable<SetOrderLineListDTO> orderLines)
    {
        var orderLineEntities = orderLines.Select(dto => (OrderLine)dto).ToList();
        await OrderLineRepository.AddOrderLines(orderLineEntities);
        return Ok();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderLines"></param>
    [HttpPut("updateOrderLines")]
    public async Task<IActionResult> UpdateOrderLines([FromBody] IEnumerable<SetOrderLineListDTO> orderLines)
    {
        var orderLineEntities = orderLines.Select(dto => (OrderLine)dto).ToList();
        await OrderLineRepository.UpdateOrderLines(orderLineEntities);
        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderLines"></param>
    [HttpDelete("deleteOrderLines")]
    public async Task<IActionResult> DeleteOrderLines([FromBody] IEnumerable<SetOrderLineListDTO> orderLines)
    {
        var orderLineEntities = orderLines.Select(dto => (OrderLine)dto).ToList();
        await OrderLineRepository.DeleteOrderLines(orderLineEntities);
        return NoContent();
    }
}