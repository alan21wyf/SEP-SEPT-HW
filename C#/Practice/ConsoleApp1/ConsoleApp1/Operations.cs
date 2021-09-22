using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Operations
    {
        public static int Factorial(int s)
        {
            if (s <= 1)
            {
                return 1;
            }
            return s * Factorial(s - 1);
        }

        public static bool IsPrime(int s)
        {
            if (s <= 2)
            {
                return true;
            }
            else
            {
                for (int i = 2; i < (s/2)+1; i++)
                {
                    if (s % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static bool IsLeapYear(int s)
        {
            if (s%4 != 0)
            {
                return false;
            }
            else
            {
                if (s%100 == 0)
                {
                    if (s%400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        public static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        public static int GCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            return GCD(b % a, a);
        }
    }
}
