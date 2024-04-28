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
    public virtual ICollection<OrderLine>? OrderLines { get; set; }

    public static explicit operator GetOrderListDTO(Order order)
    {
        return new GetOrderListDTO()
        {
            OrderID = order.OrderID,
            OrderLines = order.OrderLines,
        };
    }
}
public class SetOrderListDTO
{
    public required DateTime? Created { get; set; }
    public virtual ICollection<OrderLine>? OrderLines { get; set; }
    //Vendor Info
    public required string VendorName { get; set; }
    public required string OrgAddr { get; set; }
    public required string OrgCity { get; set; }
    public required string OrgCountry { get; set; }
    public required string OrgZip { get; set; }
    //Customer Info
    public required string CustomerName { get; set; }
    public required string DestAddr { get; set; }
    public required string DestCity { get; set; }
    public required string DestCountry { get; set; }
    public required string DestZip { get; set; }
    public required User Buyer { get; set; }

    public static explicit operator Order(SetOrderListDTO order)
    {
        return new Order()
        {
            Created = order.Created,
            OrderLines = order.OrderLines,
            VendorName = order.VendorName,
            OrgAddr = order.OrgAddr,
            OrgCity = order.OrgCity,
            OrgCountry = order.OrgCountry,
            OrgZip = order.OrgZip,
            CustomerName = order.CustomerName,
            DestAddr = order.DestAddr,
            DestCity = order.DestCity,
            DestCountry = order.DestCountry,
            DestZip = order.DestZip,
            Buyer = order.Buyer,
        };
    }
}
