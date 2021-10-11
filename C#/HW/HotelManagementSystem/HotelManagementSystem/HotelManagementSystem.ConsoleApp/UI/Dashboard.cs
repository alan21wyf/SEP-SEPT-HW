using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.ConsoleApp.UI
{
    public class Dashboard
    {
        public void ShowDashboard()
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Menu m = new Menu();
                choice = m.Print(typeof(Options));
                switch (choice)
                {
                    case (int)Options.Customer:
                        ManageCustomer manageCustomer = new ManageCustomer();
                        manageCustomer.Run();
                        break;
                    case (int)Options.Room:
                        ManageRoom manageRoom = new ManageRoom();
                        manageRoom.Run();
                        break;
                    case (int)Options.RoomType:
                        ManageRoomType manageRoomType = new ManageRoomType();
                        manageRoomType.Run();
                        break;
                    case (int)Options.Service:
                        ManageService manageService = new ManageService();
                        manageService.Run();
                        break;
                    case (int)Options.Exit:
                        Console.WriteLine("Thank You For Using Our Services! Have A Nice Day!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Please Try Again.");
                        break;
                }

            } while (choice != (int)Options.Exit);

        }
    }
}
