using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Order GetOrderById(int OrderId);
        void SaveOrder(Order Order);
        void UpdateOrder(Order Order);
        void DeleteOrder(Order Order);
    }
}
