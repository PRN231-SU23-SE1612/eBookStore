using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookAuthorRepository
    {
        List<BookAuthor> GetBookAuthors();
        BookAuthor GetBookAuthorById(int BookId, int AuthorId);
        void SaveBookAuthor(BookAuthor BookAuthor);
        void UpdateBookAuthor(BookAuthor BookAuthor);
        void DeleteBookAuthor(BookAuthor BookAuthor);
    }
}
