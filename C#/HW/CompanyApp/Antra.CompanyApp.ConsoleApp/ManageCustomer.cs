using Antra.CompanyApp.Data.Model;
using Antra.CompanyApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CompanyApp.ConsoleApp
{
    class ManageCustomer
    {
        IRepository<Customers> custRepository;
        public ManageCustomer()
        {
            custRepository = new CustRepository();
        }

        void AddCustomer()
        {
            Customers c = new Customers();
            Console.WriteLine("Enter First Name of the Customer: ");
            c.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name of the Customer: ");
            c.LastName = Console.ReadLine();
            Console.WriteLine("Enter Mobile Number: ");
            c.Mobile = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            c.EmailId = Console.ReadLine();
            Console.WriteLine("Enter City: ");
            c.City = Console.ReadLine();
            Console.WriteLine("Enter State: ");
            c.State = Console.ReadLine();
            if (custRepository.Insert(c) > 0)
            {
                Console.WriteLine("Customer Added Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error Has Occured.");
            }
        }


        void PrintCustomers()
        {
            var collection = custRepository.GetAll();
            foreach (var c in collection)
            {
                Console.WriteLine($"{c.ID} \t {c.FirstName} \t {c.LastName} \t {c.Mobile} \t {c.EmailId} \t {c.City} \t {c.State}");
            }
        }

        void PrintCustomerById()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Customers c = custRepository.GetById(id);
            if (c != null)
            {
                Console.WriteLine($"{c.ID} \t {c.FirstName} \t {c.LastName} \t {c.Mobile} \t {c.EmailId} \t {c.City} \t {c.State}");
            }
            else
            {
                Console.WriteLine("No Record Found.");
            }
        }

        public void Run()
        {
            //AddCustomer();
            PrintCustomers();
        }
    }
}
