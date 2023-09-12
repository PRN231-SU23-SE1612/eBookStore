using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PublisherDAO
    {
        public static List<Publisher> GetPublishers()
        {
            var listPublishers = new List<Publisher>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listPublishers = context.Publishers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listPublishers;
        }

        public static Publisher GetPublisherById(int PublisherId)
        {
            var Publisher = new Publisher();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Publisher = context.Publishers.FirstOrDefault(x => x.PubId == PublisherId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Publisher;
        }

        public static void SavePublisher(Publisher Publisher)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Publishers.Add(Publisher);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdatePublisher(Publisher Publisher)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Publisher>(Publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeletePublisher(Publisher Publisher)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var u = context.Publishers.SingleOrDefault(x => x.PubId == Publisher.PubId);
                    context.Publishers.Remove(u);
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
