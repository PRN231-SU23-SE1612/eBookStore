using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int BookId);
        void SaveBook(Book Book);
        void UpdateBook(Book Book);
        void DeleteBook(Book Book);
    }
}
