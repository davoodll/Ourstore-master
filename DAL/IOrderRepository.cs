using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;

namespace OurStore.DAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> getAllOrders();
        bool addOrder(Order order);
        bool save();
        Order getOrder(int? id);
        bool editOrder(Order order);
        bool deleteOrder(int? id);
        IEnumerable<Order> getOrderHistory(string id);
        bool validateUserPurchase(int id, string user);
        bool dispose();
    }
}
