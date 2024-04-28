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
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Qty { get; set; }
        public float UnitPrice { get; set; }
        public float Tax { get; set; }
        public float Discount { get; set; }
        public float SubTotal { get; set; }
        public float Total { get; set; }
        public required int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }

    }
}
