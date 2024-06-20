using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.OrderDTO;

public class GetOrderListDTO
{
    public required int OrderID { get; set; }
    public required DateTime? Created { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public string? Status { get; set; }
    public required int CustomerID { get; set; }
    public required int PromotionID { get; set; }
    public virtual ICollection<OrderLine>? OrderLines { get; set; }

    public static explicit operator GetOrderListDTO(Order order)
    {
        return new GetOrderListDTO()
        {
            OrderID = order.OrderID,
            Created = order.Created,
            Subtotal = order.Subtotal,
            Total = order.Total,
            Status = order.Status,
            CustomerID = order.CustomerID,
            PromotionID = order.PromotionID,
        };
    }
}
public class SetOrderListDTO
{
    public required DateTime Created { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public string? Status { get; set; }
    public required int CustomerID { get; set; }
    public required int PromotionID { get; set; }

    public static explicit operator Order(SetOrderListDTO order)
    {
        return new Order()
        {
            Created = order.Created,
            Subtotal = order.Subtotal,
            Total = order.Total,
            Status = order.Status,
            CustomerID = order.CustomerID,
            PromotionID = order.PromotionID,
        };
    }
}
