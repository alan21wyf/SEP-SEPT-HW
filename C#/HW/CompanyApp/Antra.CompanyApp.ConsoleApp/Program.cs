using System;

namespace Antra.CompanyApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageProduct manageProduct = new ManageProduct();
            manageProduct.Run();
            //ManageCustomer manageCustomer = new ManageCustomer();
            //manageCustomer.Run();
        }
    }
}
