using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class AuthorRepository : IAuthorRepository
    {
        public void DeleteAuthor(Author Author)
        {
            AuthorDAO.DeleteAuthor(Author);
        }

        public Author GetAuthorById(int AuthorId)
        {
            var u = AuthorDAO.GetAuthorById(AuthorId);
            return u;
        }

        public List<Author> GetAuthors()
        {
            List<Author> Authors = AuthorDAO.GetAuthors();
            return Authors;
        }

        public void SaveAuthor(Author Author)
        {
            AuthorDAO.SaveAuthor(Author);
        }

        public void UpdateAuthor(Author Author)
        {
            AuthorDAO.UpdateAuthor(Author);
        }
    }
}
