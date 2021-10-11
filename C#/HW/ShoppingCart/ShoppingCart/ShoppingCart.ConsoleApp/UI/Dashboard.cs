using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.ConsoleApp.UI
{
    public class Dashboard
    {
        public void ShowDashboard()
        {
            ManageShopping manageShopping = new ManageShopping();
            manageShopping.Run();

        }
    }
}
