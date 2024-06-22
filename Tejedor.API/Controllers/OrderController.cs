using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tejedor.Infrastructure.DTO.OrderDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository;
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
    public async Task<IEnumerable<GetOrderListDTO>> GetAllOrders()
    {
        return (await OrderRepository.GetOrders()).Select(order => (GetOrderListDTO) order);        
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
    public async Task<IActionResult> AddOrders([FromBody] IEnumerable<SetOrderListDTO> orders)
    {
        var orderEntities = orders.Select(dto => (Order)dto).ToList();
        await OrderRepository.AddOrders(orderEntities);
        return CreatedAtAction(nameof(GetAllOrders), null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderDto"></param>
    [HttpPost("addOrder")]
    public async Task<IActionResult> AddOrder([FromBody] SetOrderListDTO orderDto)
    {
        try
        {
            var orderEntity = (Order)orderDto;
            
            // Guardar la orden usando el repositorio de órdenes
            await OrderRepository.AddOrder(orderEntity);

            return Ok(orderEntity.OrderID);
        }
        catch (Exception ex)
        {
            // Manejar cualquier error y devolver un estado apropiado
            return StatusCode(500, $"Error al agregar la orden: {ex.Message}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orders"></param>
    [HttpPut("updateOrders")]
    public async Task<IActionResult> UpdateOrders([FromBody] IEnumerable<SetOrderListDTO> orders)
    {
        var orderEntities = orders.Select(dto => (Order)dto).ToList();
        await OrderRepository.UpdateOrders(orderEntities);
        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orders"></param>
    [HttpDelete("deleteOrders")]
    public async Task<IActionResult> DeleteOrders([FromBody] IEnumerable<SetOrderListDTO> orders)
    {
        var orderEntities = orders.Select(dto => (Order)dto).ToList();
        await OrderRepository.DeleteOrders(orderEntities);
        return NoContent();
    }
}