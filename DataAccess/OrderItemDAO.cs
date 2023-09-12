using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderItemDAO
    {
        public static List<OrderItem> GetOrderItems()
        {
            var listOrderItems = new List<OrderItem>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listOrderItems = context.OrderItems.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrderItems;
        }

        public static OrderItem GetOrderItemById(int OrderItemId)
        {
            var OrderItem = new OrderItem();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    OrderItem = context.OrderItems.FirstOrDefault(x => x.OrderItemId == OrderItemId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderItem;
        }

        public static void SaveOrderItem(OrderItem OrderItem)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.OrderItems.Add(OrderItem);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrderItem(OrderItem OrderItem)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<OrderItem>(OrderItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrderItem(OrderItem OrderItem)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var a = context.OrderItems.SingleOrDefault(x => x.OrderItemId == OrderItem.OrderItemId);
                    context.OrderItems.Remove(a);
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
