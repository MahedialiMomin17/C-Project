using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ROI_Calculator_Day_10
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the initial investment amount:");
            double initialInvestment = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the final investment amount:");
            double finalInvestment = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of years:");
            double years = double.Parse(Console.ReadLine());

            double roi = (finalInvestment - initialInvestment) / initialInvestment * 100 / years;

            Console.WriteLine("The ROI is: {0}%", roi);
            Console.ReadLine();

        }
    }
}
