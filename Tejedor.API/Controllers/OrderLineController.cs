using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.OrderLineDTO;
using Tejedor.Infrastructure.Entity;
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
    public async Task AddOrderLines(SetOrderLineListDTO orderLines)
    {
        await OrderLineRepository.AddOrderLines(new List<OrderLine>() { (OrderLine)orderLines } );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderLines"></param>
    [HttpPut("updateOrderLines")]
    public async Task UpdateProducts(SetOrderLineListDTO orderLines)
    {
        await OrderLineRepository.UpdateOrderLines(new List<OrderLine>() { (OrderLine)orderLines });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderLines"></param>
    [HttpDelete("deleteOrderLines")]
    public async Task DeleteProducts(SetOrderLineListDTO orderLines)
    {
        await OrderLineRepository.DeleteOrderLines(new List<OrderLine>() { (OrderLine)orderLines });
    }
}