using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }
        public int Amount { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
    }
}
