using HotelManagementSystem.ConsoleApp.UI;
using HotelManagementSystem.Data.Model;
using HotelManagementSystem.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HotelManagementSystem.ConsoleApp
{
    public class ManageService
    {
        IRepository<Service> serviceRepository;
        public ManageService()
        {
            serviceRepository = new ServiceRepository();
        }

        void PrintAll()
        {
            var collection = serviceRepository.GetAll();
            if (collection.Count() != 0)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.ID} \t {item.RoomNo} \t {item.SDesc} \t {item.Amount} \t {item.ServiceDate}");
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
            Service item = serviceRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.ID} \t {item.RoomNo} \t {item.SDesc} \t {item.Amount} \t {item.ServiceDate}");
            }
            else
            {
                Console.WriteLine("No Record Found.");
            }
        }

        void AddService()
        {
            Service s = new Service();
            Console.WriteLine("Enter Room ID: ");
            s.RoomNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Service Description: ");
            s.SDesc = Console.ReadLine();
            Console.WriteLine("Enter The Service Price: ");
            s.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the Date of the Service (Format: yyyy-mm-dd hh:mm): ");
            string str = Console.ReadLine();
            s.ServiceDate = DateTime.ParseExact(str,
                                           "yyyy-MM-dd HH:mm",
                                           CultureInfo.InvariantCulture);
            int result = serviceRepository.Insert(s);
            if (result > 0)
            {
                Console.WriteLine("Service Added Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error has Occured.");
            }
        }

        void DeleteService()
        {
            Console.WriteLine("Enter Service ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            int result = serviceRepository.Delete(id);
            if (result > 0)
            {
                Console.WriteLine("Service Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error Has Occurred.");
            }
        }

        void UpdateService()
        {
            Service s = new Service();
            Console.WriteLine("Enter Room ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var rt = serviceRepository.GetById(id);
            if (rt != null)
            {
                s.ID = rt.ID;
                Console.WriteLine("Enter Room ID: ");
                s.RoomNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Service Description: ");
                s.SDesc = Console.ReadLine();
                Console.WriteLine("Enter The Service Price: ");
                s.Amount = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter the Date of the Service (Format: yyyy/mm/dd hh:mm:ss): ");
                string str = Console.ReadLine();
                s.ServiceDate = DateTime.ParseExact(str,
                                               "yyyy-MM-dd HH:mm",
                                               CultureInfo.InvariantCulture);
                int result = serviceRepository.Update(s);
                if (result > 0)
                {
                    Console.WriteLine("Service Updated Successfully.");
                }
                else
                {
                    Console.WriteLine("Some Error Has Occurred.");
                }
            }
            else
            {
                Console.WriteLine($"Serivce With ID = {id} Does Not Exist.");
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
                        AddService();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Delete:
                        DeleteService();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Update:
                        UpdateService();
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
