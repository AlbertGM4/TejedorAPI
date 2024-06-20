using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.OrderLineDTO;

public class GetOrderLineListDTO
{
    public required int OrderLineID { get; set; }
    public int Qty { get; set; }
    public float Tax { get; set; }
    public float Discount { get; set; }
    public float SubTotal { get; set; }
    public float Total { get; set; }
    public required int OrderID { get; set; }
    public required int ProductID { get; set; }

    public static explicit operator GetOrderLineListDTO(OrderLine orderLine)
    {
        return new GetOrderLineListDTO()
        {
            OrderLineID = orderLine.OrderLineID,
            Qty = orderLine.Qty,
            Tax = orderLine.Tax,
            Discount = orderLine.Discount,
            SubTotal = orderLine.SubTotal,
            Total = orderLine.Total,
            OrderID = orderLine.OrderID,
            ProductID = orderLine.ProductID
        };
    }
}
public class SetOrderLineListDTO
{
    public int Qty { get; set; }
    public float Tax { get; set; }
    public float Discount { get; set; }
    public float SubTotal { get; set; }
    public float Total { get; set; }
    public required int OrderID { get; set; }
    public required int ProductID { get; set; }

    public static explicit operator OrderLine(SetOrderLineListDTO orderLine)
    {
        return new OrderLine()
        {
            Qty = orderLine.Qty,
            Tax = orderLine.Tax,
            Discount = orderLine.Discount,
            SubTotal = orderLine.SubTotal,
            Total = orderLine.Total,
            OrderID = orderLine.OrderID,
            ProductID = orderLine.ProductID
        };
    }
}
