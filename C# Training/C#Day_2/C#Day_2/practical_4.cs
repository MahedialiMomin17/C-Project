using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day_2
{
    internal class practical_4
    {
        public void maxmin()
        {

            Console.WriteLine("\n");
            Console.WriteLine("Practical-4");
            Console.WriteLine("C# program to find maximum and minimum element in array");
            Console.WriteLine("--------------------------------------------------------------------");

            int i, max, min, n;

            Console.WriteLine("Enter size of the array: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] data = new int[n];

            Console.WriteLine("Enter elements in array: ");
            for (i = 0; i < n; i++)
            {
                data[i] = Convert.ToInt32(Console.ReadLine());
            }
            max = data[0];
            min = data[0];

            for (i = 0; i < n; i++)
            {

                if (data[i] > max)
                {
                    max = data[i];
                }
                if (data[i] < min)
                {
                    min = data[i];
                }
            }

            Console.WriteLine("The number of maximum elements is: " + max);
            Console.WriteLine("The number of minimum elements is: " + min);

            Console.ReadLine();

        }

    }
}
