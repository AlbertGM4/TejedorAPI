using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.OrderDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository OrderRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderRepository"></param>
    public OrderController(IOrderRepository orderRepository)
    {
        OrderRepository = orderRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("getOrders")]
    public async Task<IEnumerable<GetOrderListDTO>> GetAllorders()
    {
        return (await OrderRepository.GetOrders()).Select(x => (GetOrderListDTO) x);        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderID"></param>
    /// <returns></returns>
    [HttpGet("getOrder/({orderID})")]
    public async Task<ActionResult<GetOrderListDTO>> GetOrder([FromRoute] int orderID)
    {
        var getOrder = await OrderRepository.GetOrder(orderID);
        return getOrder != null ? (GetOrderListDTO)getOrder : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orders"></param>
    [HttpPost("addOrders")]
    public async Task AddOrders(SetOrderListDTO orders)
    {
        await OrderRepository.AddOrders(new List<Order>() { (Order) orders } );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orders"></param>
    [HttpPut("updateOrders")]
    public async Task UpdateProducts(SetOrderListDTO orders)
    {
        await OrderRepository.UpdateOrders(new List<Order>() { (Order) orders });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orders"></param>
    [HttpDelete("deleteOrders")]
    public async Task DeleteOrders(SetProductListDTO orders)
    {
        await OrderRepository.DeleteOrders(new List<Order>() { (Order) orders });
    }
}