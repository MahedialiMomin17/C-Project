using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day_2
{
    internal class practical_7
    {
        public void method(int num1 , int num2)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Practical-7");
            Console.WriteLine("c# program to sum of two integer value, three integer value and three double values - use same method name ");
            Console.WriteLine("--------------------------------------------------------------------");

            int sum = num1 + num2;
            Console.WriteLine(sum); 
            Console.ReadLine();
        }

        public void method(int num1, int num2 , int num3)
        {
            int sum = num1 + num2 + num3;
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        public void method(double num1, double num2, double num3)
        {
            double sum = num1 + num2 + num3;
            Console.WriteLine(sum);
            Console.ReadLine();

        }




    }
}
