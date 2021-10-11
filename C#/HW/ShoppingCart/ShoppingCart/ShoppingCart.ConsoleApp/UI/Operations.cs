using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.ConsoleApp.UI
{
    enum Operations
    {
        Add = 1,
        Delete,
        Update,
        ListAll,
        ListById,
        Exit
    }

    enum Options
    {
        Shop = 1,
        RemoveFromCart,
        ShowCart,
        CheckOut,
        OrderHistory
    }

}
