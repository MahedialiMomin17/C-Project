using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1
{
    internal class practical_5
    {
        public void calculator()
        {
            Console.WriteLine("Practical-5");
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("Enter First number");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter operand(+,-,/,*)");
            string operand = Console.ReadLine();

            Console.WriteLine("Enter Second number");
            int number2 = Convert.ToInt32(Console.ReadLine());

            switch (operand)
            {
                case "+":
                    Console.WriteLine(number1 + number2);
                    break;

                case "-":
                    Console.WriteLine(number1 - number2);
                    break;

                case "/":
                    Console.WriteLine(number1 / number2);
                    break;

                case "*":
                    Console.WriteLine(number1 * number2);
                    break;

                default:
                    Console.WriteLine("Enter valid number");
                    break; 
            }
            Console.ReadLine();


        }
        
    }
}
