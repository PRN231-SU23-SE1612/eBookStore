using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listOrders = context.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrders;
        }

        public static Order GetOrderById(int OrderId)
        {
            var Order = new Order();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Order = context.Orders.FirstOrDefault(x => x.OrderId == OrderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Order;
        }

        public static void SaveOrder(Order Order)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Orders.Add(Order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrder(Order Order)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Order>(Order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrder(Order Order)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var a = context.Orders.SingleOrDefault(x => x.OrderId == Order.OrderId);
                    context.OrderItems.RemoveRange(context.OrderItems.Where(x => x.OrderId == a.OrderId).ToList());
                    context.Orders.Remove(a);
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
