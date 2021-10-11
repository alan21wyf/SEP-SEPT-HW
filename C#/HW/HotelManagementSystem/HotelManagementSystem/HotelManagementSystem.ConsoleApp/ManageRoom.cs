using HotelManagementSystem.ConsoleApp.UI;
using HotelManagementSystem.Data.Model;
using HotelManagementSystem.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.ConsoleApp
{
    public class ManageRoom
    { 
        IRepository<Room> roomRepository;
        public ManageRoom()
        {
            roomRepository = new RoomRepository();
        }

        void PrintAll()
        {
            var collection = roomRepository.GetAll();
            string status;
            if (collection.Count() != 0)
            {
                foreach (var item in collection)
                {
                    if (item.Status == true)
                    {
                        status = "Booked";
                    }
                    else
                    {
                        status = "Available";
                    }
                    Console.WriteLine($"{item.ID} \t {item.RTCode} \t {status}");
                }
            }
            else
            {
                Console.WriteLine("No Record Found. ");
            }

        }

        void PrintById()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Room item = roomRepository.GetById(id);
            if (item != null)
            {
                string status;
                if (item.Status == true)
                {
                    status = "Booked";
                }
                else
                {
                    status = "Available";
                }
                Console.WriteLine($"{item.ID} \t {item.RTCode} \t {status}");
            }
            else
            {
                Console.WriteLine("No Record Found.");
            }
        }

        void AddRoom()
        {
            Room r = new Room();
            Console.WriteLine("Enter Room Type Code: ");
            r.RTCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Room Status(true for occupied, false for available): ");
            r.Status = Convert.ToBoolean(Console.ReadLine());
            int result = roomRepository.Insert(r);
            if (result > 0)
            {
                Console.WriteLine("Room Added Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error has Occured.");
            }
        }

        void DeleteRoom()
        {
            Console.WriteLine("Enter Room ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            int result = roomRepository.Delete(id);
            if (result > 0)
            {
                Console.WriteLine("Room Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error Has Occurred.");
            }
        }

        void UpdateRoom()
        {
            Room r = new Room();
            Console.WriteLine("Enter Room ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var rt = roomRepository.GetById(id);
            if (rt != null)
            {
                r.ID = rt.ID;
                Console.WriteLine("Enter Room Type Code: ");
                r.RTCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Room Status(true for occupied, false for available): ");
                r.Status = Convert.ToBoolean(Console.ReadLine());
                int result = roomRepository.Update(r);
                if (result > 0)
                {
                    Console.WriteLine("Room Updated Successfully.");
                }
                else
                {
                    Console.WriteLine("Some Error Has Occurred.");
                }
            }
            else
            {
                Console.WriteLine($"Room With ID = {id} Does Not Exist.");
            }
        }

        public void Run()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\n\n");
                Menu m = new Menu();
                choice = m.Print(typeof(Operations));
                switch (choice)
                {
                    case (int)Operations.Add:
                        AddRoom();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Delete:
                        DeleteRoom();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Update:
                        UpdateRoom();
                        Console.ReadLine();
                        break;
                    case (int)Operations.ListAll:
                        PrintAll();
                        Console.ReadLine();
                        break;
                    case (int)Operations.ListById:
                        PrintById();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Exit:
                        Console.WriteLine("Return to the Main Menu...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Please Try Again.");
                        Console.ReadLine();
                        break;
                }
            } while (choice != (int)Operations.Exit);

        }
}
}
