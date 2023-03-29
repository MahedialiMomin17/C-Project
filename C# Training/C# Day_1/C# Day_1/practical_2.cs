using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1
{
    internal class practical_2
    {

        public void Week()
        {
           
            Console.WriteLine("Practical-2");
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("Enter the week number (1 to 7):");
            int week = Convert.ToInt32(Console.ReadLine());

            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (week >= 1 && week <= 7)
            {
                Console.WriteLine(daysOfWeek[week - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Input !");
            }
            Console.ReadLine();
          
        } 
    }
}
