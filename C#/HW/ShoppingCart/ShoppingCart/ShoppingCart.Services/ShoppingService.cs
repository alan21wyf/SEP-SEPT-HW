using ShoppingCart.Data.Model;
using ShoppingCart.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class ShoppingService
    {
        IRepository<Product> productRepository;
        IRepository<Order> orderRepository;
        IRepository<OrderDetail> orderDetailRepository;
        Dictionary<int, int> cart;
        public ShoppingService()
        {
            productRepository = new ProductRepository();
            orderDetailRepository = new OrderDetailRepository();
            orderRepository = new OrderRepository();
            cart = new Dictionary<int, int>();
        }

        void AddToCart(int id, int amount)
        {
            try
            {
                Product p = productRepository.GetById(id);
                if (!cart.ContainsKey(p.ID))
                {
                    cart[p.ID] = amount;
                }
                else
                {
                    cart[p.ID] += amount;
                }
                Console.WriteLine($"{amount} of {p.ProductName} Added To the Cart.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Product with ID = {id} Does Not Exist. Please Try Another Item.");
            }
        }


        void DeleteFromCart(int id, int amount)
        {
            try
            {
                Product p = productRepository.GetById(id);
                if (cart.ContainsKey(p.ID))
                {
                    cart[p.ID] -= amount;
                    Console.WriteLine($"You Have Deleted {amount} of {p.ProductName} From Your Cart. ");
                }
                else
                {
                    Console.WriteLine($"You Do Not Have Any {p.ProductName} In Your Cart. ");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Product with ID = {id} Does Not Exist. Please Try Another Item.");
            }
        }

        void ShowProducts()
        {
            var collection = productRepository.GetAll();
            Console.WriteLine("Products Information: ");
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.ID} \t {item.ProductName} \t {item.UnitPrice}");

            }

        }



        public void ShowCart()
        {
            Console.WriteLine("Your Shopping Cart: ");
            Console.WriteLine("PID\tAmount");
            foreach (var item in cart)
            {
                Console.WriteLine($"{item.Key} \t {item.Value}");
            }
        }

        public decimal CheckOut()
        {
            decimal total = 0;
            Order o = new Order();
            OrderDetail od = new OrderDetail();
            o.OrderDate = DateTime.Now;
            orderRepository.Insert(o);
            foreach (var item in cart)
            {
                Product p = productRepository.GetById(item.Key);
                var collection = orderRepository.GetAll();
                Order last = collection.Last();
                od.OrderID = last.ID;
                od.ProductID = item.Key;
                od.Quantity = item.Value;
                od.UnitPrice = p.UnitPrice;
                orderDetailRepository.Insert(od);
                int quant = 0;
                if (p.ProductName == "Apple")
                {
                    quant = (item.Value / 2) + item.Value % 2;
                }
                else
                {
                    quant = (item.Value / 3) * 2 + item.Value % 3;
                }
                total += quant * p.UnitPrice;
            }
            return total;
        }

        public void Shop()
        {
            ShowProducts();
            Console.WriteLine("Enter The ProductID You Want To Buy: ");
            int pID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            AddToCart(pID, amount);
            //Product p = productRepository.GetById(pID);
            //if (cart.ContainsKey(pID))
            //{
            //    cart[pID] += amount;
            //}
            //else
            //{
            //    cart[pID] = amount;
            //}
        }

        public void Remove()
        {
            ShowCart();
            Console.WriteLine("Enter The ProductID You Want To Remove From Your Cart: ");
            int pID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            DeleteFromCart(pID, amount);
        }

    }
}
