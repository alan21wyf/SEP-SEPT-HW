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
    public class ManageRoomType
    {
        IRepository<RoomType> roomTypeRepository;
        public ManageRoomType()
        {
            roomTypeRepository = new RoomTypeRepository();
        }

        void PrintAll()
        {
            var collection = roomTypeRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.ID} \t {item.RTDesc} \t {item.Rent}");
            }
        }

        void PrintById()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            RoomType item = roomTypeRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.ID} \t {item.RTDesc} \t {item.Rent}");
            }
            else
            {
                Console.WriteLine("No Record Found.");
            }
        }

        void AddRoomType()
        {
            RoomType r = new RoomType();
            Console.WriteLine("Enter RoomType Description: ");
            r.RTDesc = Console.ReadLine();
            Console.WriteLine("Enter RoomType Rent: ");
            r.Rent = Convert.ToDecimal(Console.ReadLine());
            int result = roomTypeRepository.Insert(r);
            if (result > 0)
            {
                Console.WriteLine("RoomType Added Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error has Occured.");
            }
        }

        void DeleteRoomType()
        {
            Console.WriteLine("Enter RoomType ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            int result = roomTypeRepository.Delete(id);
            if (result > 0)
            {
                Console.WriteLine("RoomType Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error Has Occurred.");
            }
        }

        void UpdateRoomType()
        {
            RoomType r = new RoomType();
            Console.WriteLine("Enter RoomType ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var rt = roomTypeRepository.GetById(id);
            if (rt != null)
            {
                r.ID = rt.ID;
                Console.WriteLine("Enter RoomType Description: ");
                r.RTDesc = Console.ReadLine();
                Console.WriteLine("Enter RoomType Rent: ");
                r.Rent = Convert.ToDecimal(Console.ReadLine());
                int result = roomTypeRepository.Update(r);
                if (result > 0)
                {
                    Console.WriteLine("RoomType Updated Successfully.");
                }
                else
                {
                    Console.WriteLine("Some Error Has Occurred.");
                }
            }
            else
            {
                Console.WriteLine($"RoomType With ID = {id} Does Not Exist.");
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
                        AddRoomType();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Delete:
                        DeleteRoomType();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Update:
                        UpdateRoomType();
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
