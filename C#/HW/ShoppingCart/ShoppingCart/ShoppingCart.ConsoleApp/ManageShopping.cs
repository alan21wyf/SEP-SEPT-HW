using ShoppingCart.ConsoleApp.UI;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.ConsoleApp
{
    public class ManageShopping
    {
        ShoppingService shoppingService;
        OrderService orderService;
        public ManageShopping()
        {
            shoppingService = new ShoppingService();
            orderService = new OrderService();
        }

        public void Run()
        {
            int choice = 0;
            do
            {
                Menu m = new Menu();
                choice = m.Print(typeof(Options));
                switch (choice)
                {
                    case (int)Options.Shop:
                        shoppingService.Shop();
                        Console.ReadLine();
                        break;
                    case (int)Options.RemoveFromCart:
                        shoppingService.Remove();
                        Console.ReadLine();
                        break;
                    case (int)Options.ShowCart:
                        shoppingService.ShowCart();
                        Console.ReadLine();
                        break;
                    case (int)Options.CheckOut:
                        decimal total = shoppingService.CheckOut();
                        Console.WriteLine($"Your Total is {total} Dollars. Thank You For Shopping With Us!");
                        break;
                    case (int)Options.OrderHistory:
                        orderService.GetOrderHistory();
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Please Try Again.");
                        break;
                }
            } while (choice != (int)Options.CheckOut);
        }
    }
}
