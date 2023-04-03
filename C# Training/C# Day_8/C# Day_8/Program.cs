using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C__Day_8
{
    enum Designation
    {
        Developer,
        QA
    }

    class Employee
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Designation Designation { get; set; }
        public decimal Salary { get; set; }
    }

    public static class ValidationExtensions
    {
        public static bool IsValidGender(this string gender)
        {
            return Regex.IsMatch(gender, @"^(Male|Female|Other)$", RegexOptions.IgnoreCase);
        }
        public static bool IsValidEmail(this string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            int Number;
            return int.TryParse(phoneNumber, out Number) && phoneNumber.Length == 10;
        }
        public static bool IsValidSalary(this decimal salary)
        {
            return salary >= 10000 && salary <= 50000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();
            bool continueProgram = true;
            while (continueProgram)
            {
                Console.WriteLine("\nEnter 1 to add a new employee record.");
                Console.WriteLine("Enter 2 to display all employee records.");
                Console.WriteLine("Enter 3 to exit the application.");

                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Employee employee = new Employee();

                        Console.WriteLine("Enter First name (Required):");
                        employee.FirstName = Console.ReadLine().Trim();
                        while (employee.FirstName == "")
                        {
                            Console.WriteLine("First name is required. Please enter a valid name:");
                            employee.FirstName = Console.ReadLine().Trim();
                        }


                        Console.WriteLine("Enter Last name (Required):");
                        employee.LastName = Console.ReadLine().Trim();
                        while (employee.LastName == "")
                        {
                            Console.WriteLine("Last name is required. Please enter a valid name:");
                            employee.LastName = Console.ReadLine().Trim();
                        }


                        Console.WriteLine("Enter Gender (Required, Must be 'Male', 'Female', or 'Other'):");
                        string gender = Console.ReadLine().Trim();
                        while (!gender.IsValidGender())
                        {
                            Console.WriteLine("Invalid input. Please enter 'Male', 'Female', or 'Other':");
                            gender = Console.ReadLine().Trim();
                        }
                        employee.Gender = gender;



                        Console.WriteLine("Enter Email (Required, Must be Valid):");
                        string email = Console.ReadLine().Trim();
                        while (!email.IsValidEmail())
                        {
                            Console.WriteLine("Invalid email. Please enter a valid email address:");
                            email = Console.ReadLine().Trim();
                        }
                        employee.Email = email;



                        Console.WriteLine("Enter Phone number (10 digits):");
                        string phoneNumber = Console.ReadLine().Trim();
                        while (!phoneNumber.IsValidPhoneNumber())
                        {
                            Console.WriteLine("Invalid input. Please enter a 10-digit phone number:");
                            phoneNumber = Console.ReadLine().Trim();
                        }
                        employee.PhoneNumber = phoneNumber;


                        Console.WriteLine("Enter Designation (1: Developer, 2: QA,):");
                        employee.Designation = (Designation)Convert.ToInt32(Console.ReadLine());


                        Console.WriteLine("Enter Salary (Min 10,000 & Max 50,000):");
                        decimal salary;
                        var validSalary = decimal.TryParse(Console.ReadLine().Trim(), out salary);
                        while (!validSalary || !salary.IsValidSalary())
                        {
                            Console.WriteLine("Invalid input. Salary should be a number between 10,000 and 50,000. Please enter a valid value:");
                            validSalary = decimal.TryParse(Console.ReadLine().Trim(), out salary);
                        }
                        employee.Salary = salary;


                        employeeList.Add(employee);

                        Console.WriteLine("\nEmployee Record created successfully");
                        //Console.WriteLine($"ID:  {employee.Id}, \nFirst Name: {employee.FirstName}, \nLast Name: {employee.LastName}, \nGender: {employee.Gender}, \nEmail: {employee.Email}, \nPhone Number: {employee.PhoneNumber}, \nDesignation: {employee.Designation}, \nSalary: {employee.Salary}");
                        break;


                    case 2:
                        Console.WriteLine("\nEmployee Records:");
                        foreach (Employee emp in employeeList)
                        {
                            Console.WriteLine("--------------------------------------------------------");
                            Console.WriteLine($"\nFirst Name: {emp.FirstName}, \nLast Name: {emp.LastName}, \nGender: {emp.Gender}, \nEmail: {emp.Email}, \nPhone Number: {emp.PhoneNumber}, \nDesignation: {emp.Designation}, \nSalary: {emp.Salary}\n");
                            Console.WriteLine("--------------------------------------------------------");
                        }
                        break;

                    case 3:
                        continueProgram = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter 1, 2 or 3.");
                        break;

                }
            }

            //foreach (Employee employee in employees)
            //{
            //    Console.WriteLine($"ID:  {employee.Id}, \nFirst Name: {employee.FirstName}, \nLast Name: {employee.LastName}, \nGender: {employee.Gender}, \nEmail: {employee.Email}, \nPhone Number: {employee.PhoneNumber}, \nDesignation: {employee.Designation}, \nSalary: {employee.Salary}\n");
            //}
            //Console.WriteLine($"ID:  {employee.Id}, \nFirst Name: {employee.FirstName}, \nLast Name: {employee.LastName}, \nGender: {employee.Gender}, \nEmail: {employee.Email}, \nPhone Number: {employee.PhoneNumber}, \nDesignation: {employee.Designation}, \nSalary: {employee.Salary}");


            //json file
            //string employeeJson = JsonConvert.SerializeObject(employeeList, Formatting.Indented);
            //string filePath = @"D:\GIT_C#_Training\C# Training\C# Day_8\employee.json";

            //using (StreamWriter file = File.CreateText(filePath))
            //{
            //    file.Write(employeeJson);
            //}

            //Console.WriteLine("\nEmployee Record saved to file successfully!");
            //Console.ReadLine();


            string filePath = @"D:\GIT_C#_Training\C# Training\C# Day_8\employee.json";

            // Check if the file already exists
            if (File.Exists(filePath))
            {
                // If the file exists, read the existing data and deserialize it
                string existingData = File.ReadAllText(filePath);
                List<Employee> existingEmployees = JsonConvert.DeserializeObject<List<Employee>>(existingData);

                // Add the new employees to the existing list
                existingEmployees.AddRange(employeeList);

                // Serialize the updated list and overwrite the existing file
                string employeeJson = JsonConvert.SerializeObject(existingEmployees, Formatting.Indented);
                File.WriteAllText(filePath, employeeJson);
            }
            else
            {
                // If the file doesn't exist, create a new file and write the data to it
                string employeeJson = JsonConvert.SerializeObject(employeeList, Formatting.Indented);
                using (StreamWriter file = File.CreateText(filePath))
                {
                    file.Write(employeeJson);
                }
            }

            Console.WriteLine("\nEmployee Record saved to file successfully!");
            Console.ReadLine();

        }
    }
}
