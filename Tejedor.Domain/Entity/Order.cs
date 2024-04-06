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
        public DateTime? Created { get; set; }
        public virtual ICollection<OrderLine>? OrderLines { get; set; }
        //Vendor Info
        public string VendorName { get; set; }
        public string OrgAddr { get; set; }
        public string OrgCity { get; set; }
        public string OrgCountry { get; set; }
        public string OrgZip { get; set; }
        //Customer Info
        public string CustomerName { get; set; }
        public string DestAddr { get; set; }
        public string DestCity { get; set; }
        public string DestCountry { get; set; }
        public string DestZip { get; set; }
        public User Buyer { get; set; }


    }
}
