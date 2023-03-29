using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day_2
{
    internal class practical_3
    {

        public void negative()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Practical-3");
            Console.WriteLine("C# program to count negative elements in array");
            Console.WriteLine("--------------------------------------------------------------------");

           
            int i, num, count = 0;

            Console.WriteLine("Enter size of the array: ");
            num = Convert.ToInt32(Console.ReadLine());
            Double[] data = new Double[num];

            Console.WriteLine("Enter elements in array: ");
            for (i = 0; i < num; i++)
            {
                data[i] = Convert.ToDouble(Console.ReadLine());
            }

            for (i = 0; i < num; i++)
            {

                if (data[i] < 0)
                {
                    count++;
                }
            }

            Console.WriteLine("The number of negative elements is: " + count);

            Console.ReadLine();

        }
    }
}
