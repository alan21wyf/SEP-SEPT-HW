using HotelManagementSystem.ConsoleApp.UI;
using System;

namespace HotelManagementSystem.ConsoleApp
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
