using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class OrderItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int OrderId { get; set; }

        //Relationships
        public virtual Book Book { get; set; }        
        public virtual Order Order { get; set; }
    }
}
