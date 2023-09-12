using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BookAuthor
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int AuthorOder { get; set; }
        [Required]
        public decimal RoyaltyPercentage { get; set; }
        public virtual Book Book { get; set; } = null!;
        public virtual Author Author { get; set; } = null!;
    }
}
