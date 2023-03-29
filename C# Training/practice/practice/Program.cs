using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string NAME = "mahediali";

            int myInt = 5;
            double myDouble = 10.5;
            bool myBool = true;


            Console.WriteLine("Enter fullname:");
            Console.WriteLine("Enter Age:");
            string firstname = "mahediali";
            string lastname = "momin";
            string fullname = Console.ReadLine();
            //int age = Console.ReadLine();

            Console.WriteLine("hello" + " " + NAME + "\n");

            Console.WriteLine(Convert.ToString(myInt));
            Console.WriteLine(Convert.ToString(myInt));
            Console.WriteLine(Convert.ToInt32(myDouble));
            Console.WriteLine(Convert.ToString(myBool +"\n"));

            Console.WriteLine("Username is: " + fullname + "\n");
            //Console.WriteLine("your age is: " + age);

            Console.ReadLine();
        }
    }
}
