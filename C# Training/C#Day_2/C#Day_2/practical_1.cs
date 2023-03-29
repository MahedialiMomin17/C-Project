using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Day_2
{
    internal class practical_1
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Practical-1");
                Console.WriteLine("C# program to write your name 5 times.");
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Enter your name:");
                string myname = Console.ReadLine();
                Console.WriteLine("-----------------");


                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(myname);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid");
            }
            




            practical_2 even = new practical_2();
            even.Even();

            practical_3 negativenumber = new practical_3();
            negativenumber.negative();

            practical_4 maxminnumber = new practical_4();
            maxminnumber.maxmin();

            practical_5 oddEvennumber = new practical_5();
            oddEvennumber.oddEven();

            p_6 data = new p_6();
            data.printt(5);
            data.printt("mahediali");
            data.printt(10, "mahediali");


            practical_7 methods = new practical_7();
            methods.method(5,7);
            methods.method(5, 8 ,9);
            methods.method(5.1, 8.2, 9.7);



        }


    }
}
