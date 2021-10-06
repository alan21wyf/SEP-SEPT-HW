using Antra.CompanyApp.Data.Model;
using Antra.CompanyApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CompanyApp.ConsoleApp
{
    class ManageProduct
    {
        IRepository<Products> productRepository;
        public ManageProduct()
        {
            productRepository = new ProductRepository();
        }

        void AddProduct()
        {
            Products p = new Products();
            Console.WriteLine("Enter Product Name: ");
            p.ProductName = Console.ReadLine();
            Console.WriteLine("Enter Product Unit Price: ");
            p.UnitPrice = Convert.ToDecimal(Console.ReadLine());
            if (productRepository.Insert(p) > 0)
            {
                Console.WriteLine("Product Added Successfully.");
            }
            else
            {
                Console.WriteLine("Some Error Has Occured.");
            }
        }

        void PrintProducts()
        {
            var collection = productRepository.GetAll();
            foreach (var p in collection)
            {
                Console.WriteLine($"{p.ProductID} \t {p.ProductName} \t {p.UnitPrice}");
            }
        }

        void PrintProductById()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Products p = productRepository.GetById(id);
            if (p != null)
            {
                Console.WriteLine($"{p.ProductID} \t {p.ProductName} \t {p.UnitPrice}");
            }
            else
            {
                Console.WriteLine("No Record Found.");
            }
        }

        public void Run()
        {
            AddProduct();
            PrintProducts();
        }
    }
}
