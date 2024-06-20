using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tejedor.Infrastructure.Entity
{
    public class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PromotionID { get; set; }
        public required int Code { get; set; }
        public string? Description { get; set; }
        public float Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int MaxUses { get; set; }
        public int UsesCount { get; set; }
    }
}
