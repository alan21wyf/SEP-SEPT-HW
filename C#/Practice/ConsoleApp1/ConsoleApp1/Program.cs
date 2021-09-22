using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Operations.Factorial(5));
            Console.WriteLine(Operations.IsPrime(s:2));
            Console.WriteLine(Operations.IsLeapYear(1900));
            Console.WriteLine(Operations.LCM(5, 25));
        }
    }
}
