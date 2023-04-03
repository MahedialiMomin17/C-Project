using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_7
{
    internal class practical_1
    {

        //static List<string> GroupNumbers(List<int> numbers)
        //{
        //    List<string> result = new List<string>();
        //    if (numbers == null || numbers.Count == 0)
        //    {
        //        return result;
        //    }

        //    numbers.Sort();
        //    int start = numbers[0];
        //    int end = start;

        //    for (int i = 1; i < numbers.Count; i++)
        //    {
        //        if (numbers[i] == end + 1)
        //        {
        //            end = numbers[i];
        //        }
        //        else
        //        {
        //            if (start == end)
        //            {
        //                result.Add(start.ToString());
        //            }
        //            else
        //            {
        //                result.Add(start + "-" + end);
        //            }

        //            start = end = numbers[i];
        //        }
        //    }

        //    if (start == end)
        //    {
        //        result.Add(start.ToString());
        //    }
        //    else
        //    {
        //        result.Add(start + "-" + end);
        //    }

        //    return result;
        //}

 
        static string FormatGroup(int start, int end)
        {
            return start == end ? start.ToString() : string.Format("{0}-{1}", start, end);
        }




        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter the number");
                int caseSwitch = Convert.ToInt32(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:

                        List<int> originalList = new List<int>() { 1, 2, 3, 4, 0 };

                        List<int> modifiedList = new List<int>();

                        // Loop through the original list and modify each value
                        foreach (int value in originalList)
                        {
                            int newValue = (value + 2) * 5;
                            modifiedList.Add(newValue);
                        }


                        // Print out the original and modified lists
                        Console.WriteLine("Original List: ");
                        foreach (int value in originalList)
                        {
                            Console.Write(value + " ");
                        }
                        Console.WriteLine();


                        Console.WriteLine("Modified List: ");
                        foreach (int value in modifiedList)
                        {
                            Console.Write(value + " ");
                        }
                        Console.WriteLine();
                        break;


                    case 2:
                        //Console.Write("Enter a list of numbers (comma-separated): ");
                        //string input1 = Console.ReadLine();

                        //List<int> numbers = new List<int>();
                        //foreach (string str in input1.Split(','))
                        //{
                        //    if (int.TryParse(str.Trim(), out int num))
                        //    {
                        //        numbers.Add(num);
                        //    }
                        //}

                        //List<string> groups = GroupNumbers(numbers);

                        //Console.WriteLine("Result: " + string.Join(", ", groups));




                        //Console.Write("Enter a list of numbers (comma-separated): ");
                        //string input1 = Console.ReadLine();

                        //List<int> numbers = new List<int>();
                        //foreach (string str in input1.Split(','))
                        //{
                        //    if (int.TryParse(str.Trim(), out int num))
                        //    {
                        //        numbers.Add(num);
                        //    }
                        //}

                        //numbers.Sort();

                        //List<string> result = new List<string>();

                        //int start = numbers[0];
                        //int end = start;

                        //for (int i = 1; i < numbers.Count; i++)
                        //{
                        //    if (numbers[i] == end + 1)
                        //    {
                        //        end = numbers[i];
                        //    }
                        //    else
                        //    {
                        //        result.Add(start == end ? start.ToString() : $"{start}-{end}");

                        //        start = end = numbers[i];
                        //    }
                        //}

                        //result.Add(start == end ? start.ToString() : $"{start}-{end}");

                        //Console.WriteLine("Result: " + string.Join(", ", result));



                        {
                            Console.WriteLine("Enter a comma-separated list of page numbers:");
                            string inputvalue = Console.ReadLine();

                            int[] pages = inputvalue.Split(',').Select(p => int.Parse(p.Trim())).ToArray();
                            var groups = new List<string>();
                            for (int i = 0; i < pages.Length; i++)
                            {
                                int start = pages[i];
                                while (i < pages.Length - 1 && pages[i + 1] == pages[i] + 1)
                                {
                                    i++;
                                }
                                groups.Add(FormatGroup(start, pages[i]));
                            }
                            Console.WriteLine("Original: {0}", string.Join(", ", pages.Select(p => p.ToString())));
                            Console.WriteLine("Grouped:  {0}", string.Join(", ", groups.ToArray()));
                            Console.ReadKey();
                        }
                        break;


                    case 3:

                        List<string> students = new List<string>();
                        int numStudents = 0;
                       

                        while (true)
                        {
                            Console.Write("Enter your name (or 'quit' to exit): ");
                            Console.WriteLine("");
                            string name = Console.ReadLine();

                            if (name.ToLower() == "quit")
                            {
                                break;
                            }

                            Console.Write("Enter your age: ");
                            int age = int.Parse(Console.ReadLine());

                            Console.Write("Enter your GPA: ");
                            double gpa = double.Parse(Console.ReadLine());

                            if (age >= 18)
                            {
                                Console.WriteLine("Congratulations, " + name + "!");
                                Console.WriteLine("");
                                students.Add(name);
                                numStudents++;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, " + name + ",");
                                Console.WriteLine("");

                            }
                        }

                        Console.WriteLine("Total number of students admitted: " + numStudents);
                        Console.WriteLine("");



                        // Remove students
                        Console.Write("Enter the name of a student to remove (or 'done' to continue): ");
                        string input = Console.ReadLine();
                        while (input.ToLower() != "done")
                        {
                            if (students.Remove(input))
                            {
                                Console.WriteLine("Removed " + input + " from the college.");
                                Console.WriteLine("");
                                numStudents--;
                            }
                            else
                            {
                                Console.WriteLine("Could not find " + input + " in the college.");
                            }

                            Console.Write("Enter the name of a student to remove (or 'done' to continue): ");
                            Console.WriteLine("");
                            input = Console.ReadLine();
                        }

                        Console.WriteLine("Total number of students remaining: " + numStudents);
                        Console.WriteLine("");


                        // Print best students
                        Console.Write("Enter the name of the best student(s) to print (separated by commas): ");
                        string inputprint = Console.ReadLine();

                        string[] names = inputprint.Split(',');

                        Console.WriteLine("Best students:");

                        foreach (string name in names)
                        {
                            if (students.Contains(name.Trim()))
                            {
                                Console.WriteLine("- " + name.Trim());
                                Console.WriteLine("");

                            }
                            else
                            {
                                Console.WriteLine("- " + name.Trim() + " is not found in the student list.");
                            }
                        }


                        // Print award-winning students
                        Console.WriteLine("Enter the names of the award-winning students (or 'done' to continue): ");
                        string inputval = Console.ReadLine();
                        while (inputval.ToLower() != "done")
                        {
                            if (students.Contains(inputval))
                            {
                                Console.WriteLine(inputval + " is an award-winning student!");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("Could not find " + inputval + " in the college.");
                            }

                            Console.WriteLine("Enter the name of an award-winning student (or 'done' to continue): ");
                            inputval = Console.ReadLine();
                        }

                        Console.WriteLine("Thanks for using the admission program!");
                        Console.ReadLine();

                        break;

                }

            }
        }

    }
}
