using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetOrderItems();
        OrderItem GetOrderItemById(int OrderItemId);
        void SaveOrderItem(OrderItem OrderItem);
        void UpdateOrderItem(OrderItem OrderItem);
        void DeleteOrderItem(OrderItem OrderItem);
    }
}
