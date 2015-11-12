using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;
using System.Data.Entity;

namespace OurStore.DAL
{
    public class OrderDAL : OurStore.DAL.IOrderRepository
    {
        private ProductContext db = new ProductContext();

        public IEnumerable<Order> getAllOrders()
        {
            return db.Orders.ToList();
        }
        public bool addOrder(Order order)
        {
            var db = new ProductContext();
            if(order != null)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool save()
        {
            var db = new ProductContext();
            db.SaveChanges();
            return true;
        }

        public Order getOrder(int? id)
        {
            var db = new ProductContext();
            return db.Orders.Include("OrderDetails").Single(c => c.OrderId == id);
        }

        public bool editOrder(Order order)
        {
            if(order != null)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteOrder(int? id)
        {
            if (id != 0)
            {
                Order order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Order> getOrderHistory(string id)
        {
            var db = new ProductContext();
            return db.Orders.Where(o => o.UserId == id).ToList();
        }

        public bool validateUserPurchase(int id, string user)
        {
            var db = new ProductContext();
            return db.Orders.Any(o => o.OrderId == id && o.Username == user);
        }

        public bool dispose()
        {
            db.Dispose();
            return true;
        }
    }
}
