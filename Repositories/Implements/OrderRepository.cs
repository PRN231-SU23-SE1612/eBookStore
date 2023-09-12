using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order Order)
        {
            OrderDAO.DeleteOrder(Order);
        }

        public Order GetOrderById(int OrderId)
        {
            var u = OrderDAO.GetOrderById(OrderId);
            return u;
        }

        public List<Order> GetOrders()
        {
            List<Order> Orders = OrderDAO.GetOrders();
            return Orders;
        }

        public void SaveOrder(Order Order)
        {
            OrderDAO.SaveOrder(Order);
        }

        public void UpdateOrder(Order Order)
        {
            OrderDAO.UpdateOrder(Order);
        }
    }
}
