using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.ConsoleApp.UI
{
    enum Operations
    {
        Add = 1,
        Update,
        Delete,
        ListAll,
        ListById,
        Exit
    }

    enum Options
    {
        Customer = 1,
        Room,
        RoomType,
        Service,
        Exit
    }
}
