using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuthorDAO
    {
        public static List<Author> GetAuthors()
        {
            var listAuthors = new List<Author>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listAuthors = context.Authors.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAuthors;
        }

        public static Author GetAuthorById(int AuthorId)
        {
            var Author = new Author();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Author = context.Authors.FirstOrDefault(x => x.AuthorId == AuthorId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Author;
        }

        public static void SaveAuthor(Author Author)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Authors.Add(Author);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateAuthor(Author Author)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Author>(Author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAuthor(Author Author)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var a = context.Authors.SingleOrDefault(x => x.AuthorId == Author.AuthorId);
                    context.BookAuthors.RemoveRange(context.BookAuthors.Where(x => x.AuthorId == a.AuthorId).ToList());
                    context.Authors.Remove(a);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
