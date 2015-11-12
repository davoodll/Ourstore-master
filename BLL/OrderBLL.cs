using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;
using OurStore.DAL;

namespace OurStore.BLL
{
    public class OrderBLL : OurStore.BLL.OrderLogic
    {
        private IOrderRepository db;
        public OrderBLL()
        {
            db = new OrderDAL();
        }
        public OrderBLL(IOrderRepository stub)
        {
            db = stub;
        }
        public IEnumerable<Order> getAllOrders()
        {
            return db.getAllOrders();
        }
        public bool addOrder(Order order)
        {
            var db = new OrderDAL();
            return db.addOrder(order);
        }

        public bool save()
        {
            var db = new OrderDAL();
            return db.save();
        }

        public Order getOrder(int? id)
        {
            var db = new OrderDAL();
            return db.getOrder(id);
        }

        public bool editOrder(Order order)
        {
            return db.editOrder(order);
        }
        public bool deleteOrder(int? id)
        {
            return db.deleteOrder(id);
        }

        public IEnumerable<Order> getOrderHistory(string id)
        {
            var db = new OrderDAL();
            return db.getOrderHistory(id);
        }

        public bool validateUserPurchase(int id, string user)
        {
            var db = new OrderDAL();
            return db.validateUserPurchase(id, user);
        }
        public bool dispose()
        {
            return db.dispose();
        }
    }
}
