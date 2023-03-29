using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day_2
{
    internal class practical_2
    {
        public void Even()
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Practical-2");
                Console.WriteLine("Write a method that returns a string of even numbers greater than 0 and less than 50");
                Console.WriteLine("--------------------------------------------------------------------");

                for (int i = 0; i < 50; i += 2)
                {
                    if (i != 2 && i != 12 && i != 22 && i != 32 && i != 42)
                    {
                        Console.Write(i +" ");
                    }
                }
                Console.ReadLine();
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("invalid");
            }
           
        }
    }
}
