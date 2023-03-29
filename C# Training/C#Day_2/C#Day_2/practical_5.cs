using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day_2
{
    internal class practical_5
    {
        public void oddEven()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Practical-5");
            Console.WriteLine("C# program to count even and odd elements in array");
            Console.WriteLine("--------------------------------------------------------------------");

            int i, even, odd, num;

            Console.WriteLine("Enter size of the array: ");
            num = Convert.ToInt32(Console.ReadLine());
            int[] data = new int[num];

            Console.WriteLine("Enter elements in array: ");
            for (i = 0; i < num; i++)
            {
                data[i] = int.Parse(Console.ReadLine());
            }
            even = 0;
            odd = 0;

            for (i = 0; i < num; i++)
            {

                if (data[i] % 2 == 0)
                {
                    even++;
                }
                else 
                {
                    odd++;
                }
            }

            Console.WriteLine("Total even number: " + even);
            Console.WriteLine("Total odd number: " + odd);

            Console.ReadLine();
        }
    }
}
