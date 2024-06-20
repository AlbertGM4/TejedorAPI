using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tejedor.Infrastructure.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public string? Description { get; set; }  
        public string? ImagesRoute { get; set; }
        public int Stock { get; set; }
        // Category
        public required int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category? Category { get; set; }
    }
}
