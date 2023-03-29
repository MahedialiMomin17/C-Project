using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1
{
    internal class practical_3
    {
        public void numbers()
        {
            Console.WriteLine("Practical-3");
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("Enter the first Number");
            int firstnumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number");
            int secondnumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter maximum or minimum");
            string maxmin = Console.ReadLine().ToLower();

            if(maxmin == "max")
            {
                if (firstnumber > secondnumber)
                {
                    Console.WriteLine("Maximum:" + firstnumber);
                }
                else
                {
                    Console.WriteLine("Maximum:" + secondnumber);

                }
            }

            else if(maxmin == "min")
            {
                if (firstnumber < secondnumber)
                {
                    Console.WriteLine("Minimum:" + firstnumber);
                }
                else
                {
                    Console.WriteLine("Mimimum:" + secondnumber);

                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }

                Console.ReadLine();

        }
    }
}
