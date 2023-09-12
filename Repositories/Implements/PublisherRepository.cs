using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class PublisherRepository : IPublisherRepository
    {
        public void DeletePublisher(Publisher Publisher)
        {
            PublisherDAO.DeletePublisher(Publisher);
        }

        public Publisher GetPublisherById(int PublisherId)
        {
            var u = PublisherDAO.GetPublisherById(PublisherId);
            return u;
        }

        public List<Publisher> GetPublishers()
        {
            List<Publisher> Publishers = PublisherDAO.GetPublishers();
            return Publishers;
        }

        public void SavePublisher(Publisher Publisher)
        {
            PublisherDAO.SavePublisher(Publisher);
        }

        public void UpdatePublisher(Publisher Publisher)
        {
            PublisherDAO.UpdatePublisher(Publisher);
        }
    }
}
