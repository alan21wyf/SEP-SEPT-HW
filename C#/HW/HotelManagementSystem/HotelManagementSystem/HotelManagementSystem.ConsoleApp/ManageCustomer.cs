using HotelManagementSystem.ConsoleApp.UI;
using HotelManagementSystem.Data.Model;
using HotelManagementSystem.Data.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.ConsoleApp
{
    public class ManageCustomer
    {
        IRepository<Customer> customerRepository;
        IRepository<Room> roomRepository;
        public ManageCustomer()
        {
            customerRepository = new CustomerRepository();
            roomRepository = new RoomRepository();
        }

        void PrintAll()
        {
            var collection = customerRepository.GetAll();
            if (collection.Count() != 0)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.ID} \t {item.RoomNo} \t {item.CName} \t {item.Address} \t {item.Phone} \t {item.Email} \t {item.CheckIn} \t {item.TotalPersons} \t {item.BookingDays} \t {item.Advance}");
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
            Customer item = customerRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.ID} \t {item.RoomNo} \t {item.CName} \t {item.Address} \t {item.Phone} \t {item.Email} \t {item.CheckIn} \t {item.TotalPersons} \t {item.BookingDays} \t {item.Advance}");
            }
            else
            {
                Console.WriteLine("No Record Found.");
            }
        }

        void AddCustomer()
        {
            // printing available rooms
            var collection = roomRepository.GetAll();
            string status;
            Console.WriteLine("\nCurrent Rooms Availability: \nRoomID \t RoomType \t Availability");
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
                Console.WriteLine("No Room Information. Please Wait Until Rooms Are Added.");
                return;
            }
            bool occupied = false;
            Customer c = new Customer();
            while (!occupied)
            {
                Console.WriteLine("Enter Room ID: ");
                int roomId = Convert.ToInt32(Console.ReadLine());
                Room room = roomRepository.GetById(roomId);
                if (room.Status == true)
                {
                    Console.WriteLine("This Room Is Already Booked. Please Try Another Room");
                    continue;
                }
                else
                {
                    c.RoomNo = roomId;
                    Room updated = roomRepository.GetById(roomId);
                    updated.Status = true;
                    roomRepository.Update(updated);
                    occupied = true;
                }
            }
            Console.WriteLine("Enter the Customer's Name: ");
            c.CName = Console.ReadLine();
            Console.WriteLine("Enter the Customer's Address: ");
            c.Address = Console.ReadLine();
            Console.WriteLine("Enter the Customer's Phone Number: ");
            c.Phone = Console.ReadLine();
            Console.WriteLine("Enter the Customer's Email Address: ");
            c.Email = Console.ReadLine();
            Console.WriteLine("Enter Check-In Time (Format: yyyy-mm-dd hh:mm): ");
            string str = Console.ReadLine();
            c.CheckIn = DateTime.ParseExact(str,
                                            "yyyy-MM-dd HH:mm",
                                            CultureInfo.InvariantCulture);
            Console.WriteLine("Enter the Total Number of Person of this Stay: ");
            c.TotalPersons = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter The Number of Booked Days: ");
            c.BookingDays = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Amount of Advance: ");
            c.Advance = Convert.ToDecimal(Console.ReadLine());
            int result = customerRepository.Insert(c);
            if (result > 0)
            {
                Console.WriteLine("Customer Added Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error has Occured.");
            }

        }

        void DeleteCustomer()
        {
            Console.WriteLine("Enter Customer ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            int result = customerRepository.Delete(id);
            if (result > 0)
            {
                Console.WriteLine("Customer Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error Has Occurred.");
            }
        }

        void UpdateCustomer()
        {
            Customer c = new Customer();
            Console.WriteLine("Enter Customer ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var rt = customerRepository.GetById(id);
            if (rt != null)
            {
                c.ID = rt.ID;
                int oldRoomId = (int)rt.RoomNo;
                bool occupied = false;
                while (!occupied)
                {
                    Console.WriteLine("Enter Room ID: ");
                    int newRoomId = Convert.ToInt32(Console.ReadLine());
                    Room room = roomRepository.GetById(newRoomId);
                    if (room.Status == true)
                    {
                        Console.WriteLine("This Room Is Already Booked. Please Try Another Room");
                        continue;
                    }
                    else
                    {
                        c.RoomNo = newRoomId;
                        Room newRoom = roomRepository.GetById(newRoomId);
                        Room oldRoom = roomRepository.GetById(oldRoomId);
                        newRoom.Status = true;
                        oldRoom.Status = false;
                        roomRepository.Update(newRoom);
                        roomRepository.Update(oldRoom);
                        occupied = true;
                    }
                }
                Console.WriteLine("Enter the Customer's Name: ");
                c.CName = Console.ReadLine();
                Console.WriteLine("Enter the Customer's Address: ");
                c.Address = Console.ReadLine();
                Console.WriteLine("Enter the Customer's Phone Number: ");
                c.Phone = Console.ReadLine();
                Console.WriteLine("Enter the Customer's Email Address: ");
                c.Email = Console.ReadLine();
                Console.WriteLine("Enter Check-In Time (Format: yyyy-mm-dd hh:mm): ");
                string str = Console.ReadLine();
                c.CheckIn = DateTime.ParseExact(str,
                                               "yyyy-MM-dd HH:mm",
                                               CultureInfo.InvariantCulture);
                Console.WriteLine("Enter the Total Number of Person of this Stay: ");
                c.TotalPersons = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter The Number of Booked Days: ");
                c.BookingDays = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Amount of Advance: ");
                c.Advance = Convert.ToDecimal(Console.ReadLine());
                int result = customerRepository.Update(c);
                if (result > 0)
                {
                    Console.WriteLine("Customer Updated Successfully.");
                }
                else
                {
                    Console.WriteLine("Some Error Has Occurred.");
                }
            }
            else
            {
                Console.WriteLine($"Customer With ID = {id} Does Not Exist.");
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
                        AddCustomer();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Delete:
                        DeleteCustomer();
                        Console.ReadLine();
                        break;
                    case (int)Operations.Update:
                        UpdateCustomer();
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
