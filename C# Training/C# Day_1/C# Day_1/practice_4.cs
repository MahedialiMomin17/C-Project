using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1
{
    internal class practice_4
    {
        public void temp()
        {
            Console.WriteLine("Practical-4");
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("Enter the temperature: ");
            int temperature = Convert.ToInt32(Console.ReadLine());

            if(temperature < 0)
            {
                Console.WriteLine("Freezing weather.." +"\n");
            }
            else if(temperature < 10)
            {   
                Console.WriteLine("Very Cold weather.." +"\n");
            }
            else if (temperature < 20)
            {
                Console.WriteLine("Cold weather.." + "\n");
            }
            else if (temperature < 30)
            {
                Console.WriteLine("Normal in temperature.." + "\n");
            }
            else if (temperature < 40)
            {
                Console.WriteLine("Its Hot.." + "\n");
            }
            else
            {
                Console.WriteLine("Its very Hot.." + "\n");
            }
            Console.ReadLine();
        }
    }
}
