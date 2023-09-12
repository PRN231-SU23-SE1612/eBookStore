using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class BookAuthorDTO
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public int AuthorOder { get; set; }
        public decimal RoyaltyPercentage { get; set; }
    }
}
