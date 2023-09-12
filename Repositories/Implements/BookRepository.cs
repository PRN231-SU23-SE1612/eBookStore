using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class BookRepository : IBookRepository
    {
        public void DeleteBook(Book Book)
        {
            BookDAO.DeleteBook(Book);
        }

        public Book GetBookById(int BookId)
        {
            var u = BookDAO.GetBookById(BookId);
            return u;
        }

        public List<Book> GetBooks()
        {
            List<Book> Books = BookDAO.GetBooks();
            return Books;
        }

        public void SaveBook(Book Book)
        {
            BookDAO.SaveBook(Book);
        }

        public void UpdateBook(Book Book)
        {
            BookDAO.UpdateBook(Book);
        }
    }
}
