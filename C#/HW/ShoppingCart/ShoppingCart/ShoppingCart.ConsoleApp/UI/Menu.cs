using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.ConsoleApp.UI
{
    public class Menu
    {
        public int Print(Type t)
        {
            string[] names = Enum.GetNames(t);
            int[] values = (int[])Enum.GetValues(t);
            int length = values.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Print {values[i]} for {names[i]}");
            }
            Console.WriteLine("Enter your choice = ");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;

        }
    }
}
