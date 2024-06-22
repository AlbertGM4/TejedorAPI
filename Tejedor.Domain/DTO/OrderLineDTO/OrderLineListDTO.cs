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
    public int Qty { get; set; }
    public decimal? Tax { get; set; }
    public decimal? Discount { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public int OrderID { get; set; }
    public int ProductID { get; set; }

    public static explicit operator GetOrderLineListDTO(OrderLine orderLine)
    {
        return new GetOrderLineListDTO()
        {
            Qty = orderLine.Qty,
            Tax = orderLine.Tax != null ? (decimal)orderLine.Tax : (decimal?)null, // Conversión explícita de Single a decimal
            Discount = orderLine.Discount != null ? (decimal)orderLine.Discount : (decimal?)null, // Igualmente
            SubTotal = orderLine.SubTotal,
            Total = orderLine.Total,
            OrderID = orderLine.OrderID,
            ProductID = orderLine.ProductID
        };
    }
}
public class SetOrderLineListDTO
{
    public required int Qty { get; set; }
    public decimal? Tax { get; set; }
    public decimal? Discount { get; set; }
    public required decimal SubTotal { get; set; }
    public required decimal Total { get; set; }
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
