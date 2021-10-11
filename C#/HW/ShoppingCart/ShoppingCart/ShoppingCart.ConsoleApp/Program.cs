using ShoppingCart.ConsoleApp.UI;
using System;
using System.Collections.Generic;

namespace ShoppingCart.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDashboard();
            Console.ReadLine();

        }
    }
}
