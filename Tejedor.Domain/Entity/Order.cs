using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tejedor.Infrastructure.Entity
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public required DateTime Created { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
        public required int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual User? Customer { get; set; }
        public int PromotionID { get; set; }
        [ForeignKey("PromotionID")]
        public virtual Promotion? Promotion { get; set; }
    }
}
