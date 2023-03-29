using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day_2
{
    internal class p_6
    {

        public void printt(int num1)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Practical-6");
            Console.WriteLine("c# program to print int, string and int, string value by function overloading - use same method name");
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine(num1);
            Console.ReadLine();
      
        }
        public void printt(string num2)
        {
           
            Console.WriteLine(num2);
            Console.ReadLine();

        }
        public void printt(int num4, string num5)
        {
            Console.WriteLine(num4 + num5);
        }
    }
}
