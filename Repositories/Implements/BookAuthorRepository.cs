using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        public void DeleteBookAuthor(BookAuthor BookAuthor)
        {
            BookAuthorDAO.DeleteBookAuthor(BookAuthor);
        }

        public BookAuthor GetBookAuthorById(int BookId, int AuthorId)
        {
            var u = BookAuthorDAO.GetBookAuthorById(BookId, AuthorId);
            return u;
        }

        public List<BookAuthor> GetBookAuthors()
        {
            List<BookAuthor> BookAuthors = BookAuthorDAO.GetBookAuthors();
            return BookAuthors;
        }

        public void SaveBookAuthor(BookAuthor BookAuthor)
        {
            BookAuthorDAO.SaveBookAuthor(BookAuthor);
        }

        public void UpdateBookAuthor(BookAuthor BookAuthor)
        {
            BookAuthorDAO.UpdateBookAuthor(BookAuthor);
        }
    }
}
