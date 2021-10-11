using ShoppingCart.Data.Model;
using ShoppingCart.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class OrderService
    {
        IRepository<Order> orderRepository;
        IRepository<OrderDetail> orderDetailRepository;
        IRepository<Product> productRepository;
        public OrderService()
        {
            orderRepository = new OrderRepository();
            orderDetailRepository = new OrderDetailRepository();
            productRepository = new ProductRepository();
        }

        public IEnumerable<OrderDetail> GetOrderDetail(int orderID)
        {
            List<OrderDetail> ods = new List<OrderDetail>();
            var col = orderDetailRepository.GetAll();
            foreach (var item in col)
            {
                if (item.OrderID == orderID)
                {
                    ods.Add(item);
                }
            }

            return ods;
        }

        public void GetOrderHistory()
        {
            var collection = orderRepository.GetAll();
            if (collection.Count() != 0)
            {
                foreach (var item in collection)
                {
                    string print = $"{item.ID} \t {item.OrderDate}";
                    var ods = GetOrderDetail(item.ID);
                    decimal total = 0;
                    foreach (var od in ods)
                    {
                        Product p = productRepository.GetById(od.ProductID);
                        print += $"\t {p.ProductName}:{od.Quantity}";
                        total += od.UnitPrice * od.Quantity;
                    }
                    print += $"\t Total Cost: {total}";
                    Console.WriteLine(print);
                }
            }
            else
            {
                Console.WriteLine("No Order History.");
            }

        }
    }
}
