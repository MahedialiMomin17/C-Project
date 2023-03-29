using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1
{
    internal class practical_1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Practical-1");
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("Enter the number:- ");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number > 0)
                Console.WriteLine("Number is positive: " + number + "\n");

            else if (number < 0)
                Console.WriteLine("Number is negative: " + number + "\n");

            else if (number == 0)
                Console.Write("Number is Zero: " + number + "\n");


            Console.ReadLine();




            practical_2 check = new practical_2();
            check.Week();

            practical_3 maxmin = new practical_3();
            maxmin.numbers();

            practice_4 weather = new practice_4();
            weather.temp();

            practical_5 cal = new practical_5();
            cal.calculator();
        }

    }
}
