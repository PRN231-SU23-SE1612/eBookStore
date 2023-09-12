using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAuthors();
        Author GetAuthorById(int AuthorId);
        void SaveAuthor(Author Author);
        void UpdateAuthor(Author Author);
        void DeleteAuthor(Author Author);
    }
}
