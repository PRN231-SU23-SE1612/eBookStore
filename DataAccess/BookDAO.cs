using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDAO
    {
        public static List<Book> GetBooks()
        {
            var listBooks = new List<Book>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listBooks = context.Books.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBooks;
        }

        public static Book GetBookById(int BookId)
        {
            var Book = new Book();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Book = context.Books.FirstOrDefault(x => x.BookId == BookId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Book;
        }

        public static void SaveBook(Book Book)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Books.Add(Book);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateBook(Book Book)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Book>(Book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteBook(Book Book)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var a = context.Books.SingleOrDefault(x => x.BookId == Book.BookId);
                    context.BookAuthors.RemoveRange(context.BookAuthors.Where(x => x.BookId == a.BookId).ToList());
                    context.Books.Remove(a);
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
