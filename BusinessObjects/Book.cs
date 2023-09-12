using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int PubId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Advance { get; set; }
        [Required]
        public string Royalty { get; set; }
        [Required]
        public string YtdSales { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        public virtual Publisher Publisher { get; set; } = null!;
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
