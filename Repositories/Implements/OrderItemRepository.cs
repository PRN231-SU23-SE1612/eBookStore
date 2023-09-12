using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public void DeleteOrderItem(OrderItem OrderItem)
        {
            OrderItemDAO.DeleteOrderItem(OrderItem);
        }

        public OrderItem GetOrderItemById(int OrderItemId)
        {
            var u = OrderItemDAO.GetOrderItemById(OrderItemId);
            return u;
        }

        public List<OrderItem> GetOrderItems()
        {
            List<OrderItem> OrderItems = OrderItemDAO.GetOrderItems();
            return OrderItems;
        }

        public void SaveOrderItem(OrderItem OrderItem)
        {
            OrderItemDAO.SaveOrderItem(OrderItem);
        }

        public void UpdateOrderItem(OrderItem OrderItem)
        {
            OrderItemDAO.UpdateOrderItem(OrderItem);
        }
    }
}
