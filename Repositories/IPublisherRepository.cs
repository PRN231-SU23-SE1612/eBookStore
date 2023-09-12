using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPublisherRepository
    {
        List<Publisher> GetPublishers();
        Publisher GetPublisherById(int PublisherId);
        void SavePublisher(Publisher Publisher);
        void UpdatePublisher(Publisher Publisher);
        void DeletePublisher(Publisher Publisher);
    }
}
