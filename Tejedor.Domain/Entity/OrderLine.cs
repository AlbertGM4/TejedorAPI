using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tejedor.Infrastructure.Entity
{
    public class OrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderLineID { get; set; }
        public required int Qty { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Discount { get; set; }
        public required decimal SubTotal { get; set; }
        public required decimal Total { get; set; }
        // Order
        public required int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }
        //Product
        public required int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product? Product { get; set; }

    }
}
