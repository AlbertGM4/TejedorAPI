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
        public User Buyer { get; set; }


    }
}
