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
    public required string ProductName { get; set; }
    public required int Qty { get; set; }
    public required float UnitPrice { get; set; }
    public required float Tax { get; set; }
    public required float Discount { get; set; }
    public required float SubTotal { get; set; }
    public required float Total { get; set; }
    public required int OrderID { get; set; }

    public static explicit operator GetOrderLineListDTO(OrderLine orderLine)
    {
        return new GetOrderLineListDTO()
        {
            OrderLineID = orderLine.OrderLineID,
            ProductName = orderLine.ProductName,
            Qty = orderLine.Qty,
            UnitPrice = orderLine.UnitPrice,
            Tax = orderLine.Tax,
            Discount = orderLine.Discount,
            SubTotal = orderLine.SubTotal,
            Total = orderLine.Total,
            OrderID = orderLine.OrderID
        };
    }
}
public class SetOrderLineListDTO
{
    public required int OrderLineID { get; set; }
    public required string ProductName { get; set; }
    public required int Qty { get; set; }
    public required float UnitPrice { get; set; }
    public required float Tax { get; set; }
    public required float Discount { get; set; }
    public required float SubTotal { get; set; }
    public required float Total { get; set; }
    public required int OrderID { get; set; }

    public static explicit operator OrderLine(SetOrderLineListDTO orderLine)
    {
        return new OrderLine()
        {
            OrderLineID = orderLine.OrderLineID,
            ProductName = orderLine.ProductName,
            Qty = orderLine.Qty,
            UnitPrice = orderLine.UnitPrice,
            Tax = orderLine.Tax,
            Discount = orderLine.Discount,
            SubTotal = orderLine.SubTotal,
            Total = orderLine.Total,
            OrderID = orderLine.OrderID
        };
    }
}
