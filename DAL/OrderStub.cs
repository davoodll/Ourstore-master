using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;

namespace OurStore.DAL
{
    public class OrderStub : OurStore.DAL.IOrderRepository
    {
        public IEnumerable<Order> getAllOrders()
        {
            return null;
        }
        public bool addOrder(Order order)
        {
            if(order != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool save()
        {
            return true;
        }

        public Order getOrder(int? id)
        {
            if(id == 0)
            {
                var order = new Order();
                order.OrderId = 0;
                return order;
            }
            else
            {
                var ord = new Order()
                {
                    OrderId = 1,
                    Address = "Los",
                    City = "Angeles",
                    FirstName = "Hellloooo",
                    LastName = "Bellooooo",
                    Email = "portobello@go.hol",
                    OrderDate = DateTime.Now,
                    Phone = "123456",
                    PostalCode = "123",
                    Total = 1234,
                    UserId = "1",
                    Username = "konga"
                };
                return ord;
            }
        }

        public bool editOrder(Order order)
        {
            if(order != null)
            {
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Order> getOrderHistory(string id)
        {
            if(!id.Equals(String.Empty))
            {
                var oh = new List<Order>();
                var ord = new Order()
                {
                    OrderId = 1,
                    Address = "Los",
                    City = "Angeles",
                    FirstName = "Hellloooo",
                    LastName = "Bellooooo",
                    Email = "portobello@go.hol",
                    OrderDate = DateTime.Now,
                    Phone = "123456",
                    PostalCode = "123",
                    Total = 1234,
                    UserId = "1",
                    Username = "konga"
                };
                oh.Add(ord);
                oh.Add(ord);
                return oh;
            }
            else
            {
                return null;
            }
        }

        public bool validateUserPurchase(int id, string user)
        {
            if(id != 0 && !user.Equals(String.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool dispose()
        {
            return true;
        }
    }
}
