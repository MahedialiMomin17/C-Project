using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace C__Day_8
{
    public enum Designation
    {
        Developer,
        QA,
        Designer,
        Marketing
    }
    public enum Department
    {
        Sales,
        Marketing,
        Development,
        QA,
        SEO
    }

    class Employee
    {
        private static int nextId = 1;

        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Designation Designation { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DateOfJoining { get; set; }
        public string TotalExperience { get; set; }
        public string Remarks { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Department Department { get; set; }
        public decimal MonthlySalary { get; set; }

        //public Employee()
        //{
        //    EmployeeID = nextId;
        //    nextId++;
        //}

    }


    public static class ValidationExtensions
    {
        public static bool IsValidGender(this string gender)
        {
            return Regex.IsMatch(gender, @"^(M|F|Other)$", RegexOptions.IgnoreCase);
        }
        public static bool IsValidPostcode(this string postcode)
        {
            if (postcode.Length != 6)
            {
                return false;
            }

            return int.TryParse(postcode, out int result);
        }
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            int Number;
            return int.TryParse(phoneNumber, out Number) && phoneNumber.Length == 10;
        }
        public static bool IsValidEmail(this string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.com|\.org|\.in)+)$", RegexOptions.IgnoreCase);
        }

        public static bool IsValidSalary(this decimal salary)
        {
            return salary >= 10000 && salary <= 400000;
        }
        public static string DateFormate(this DateTime date)
        {
            string format = "dd-MMM-yyyy";
            return date.ToString(format);
        }


    }

    class Program
    {
        //public static DateTime DateOfJoining { get; private set; }

        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();
            bool continueProgram = true;
            while (continueProgram)
            {
                Console.WriteLine("\nEnter 1 to add a new employee record.");
                Console.WriteLine("Enter 2 to delete an employee record.");
                Console.WriteLine("Enter 3 to exit the application.");

                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Employee employee = new Employee();

                        // Get Employee ID
                        Console.WriteLine("Enter Employee ID (Required, Unique):");
                        int id;
                        while (true)
                        {
                            bool validId = int.TryParse(Console.ReadLine().Trim(), out id);
                            if (!validId || employeeList.Any(e => e.EmployeeID == id))
                            {
                                Console.WriteLine("Invalid input. Employee ID must be a unique integer value.");
                                Console.WriteLine("Please enter a different value:");
                            }
                            else
                            {
                                employee.EmployeeID = id;
                                break;
                            }
                        }
                        Console.WriteLine(" ");


                        Console.WriteLine("Enter Employee name (Required):");
                        string input = Console.ReadLine().Trim();
                        while (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, "^[a-zA-Z]+$"))
                        {
                            Console.WriteLine("Employee name is required and can only contain letters. Please enter a valid name:");
                            input = Console.ReadLine().Trim();
                        }
                        employee.Name = input;
                        Console.WriteLine(" ");


                        Console.WriteLine("Enter Employee Date of Birth (Required, format: dd-MMM-yyyy or dd-MMMM-yyyy) (e.g. 01-Jan-2000):");
                        var enterDOB = Convert.ToDateTime(Console.ReadLine());
                        string DOB = ValidationExtensions.DateFormate(enterDOB);
                        employee.DOB = DOB;
                        Console.WriteLine(DOB);

                        Console.WriteLine(" ");



                        Console.WriteLine("Enter Gender (Required, press M for : Male, F for : Female):");
                        string gender = Console.ReadLine().Trim();
                        while (!gender.IsValidGender())
                        {
                            Console.WriteLine("Invalid input. press M for : Male, F for : Female):");
                            gender = Console.ReadLine().Trim();
                        }
                        if (gender.ToLower() == "m")
                        {
                            gender = "Male";
                        }
                        else if (gender.ToLower() == "f")
                        {
                            gender = "Female";
                        }
                        employee.Gender = gender;

                        Console.WriteLine(" ");


                        //Console.WriteLine("Enter Designation (1: Developer, 2: QA, 3: Designer, 4: Marketing):");
                        //employee.Designation = (Designation)Convert.ToInt32(Console.ReadLine());
                        //Console.WriteLine(" ");

                        Designation designation;
                        bool isValidInput;
                        do
                        {
                            Console.WriteLine("Enter Designation (0: Developer, 1: QA, 2: Designer, 3: Marketing):");

                            isValidInput = Enum.TryParse(Console.ReadLine(), out designation);

                            if (!isValidInput || !Enum.IsDefined(typeof(Designation), designation))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number (1, 2, 3, or 4).");
                            }
                        }
                        while (!isValidInput || !Enum.IsDefined(typeof(Designation), designation));

                        employee.Designation = designation;
                        Console.WriteLine(" ");



                        Console.WriteLine("Enter City (Required):");
                        string city = Console.ReadLine().Trim();
                        while (city == "" || !city.All(char.IsLetter))
                        {
                            Console.WriteLine("City is required and should only contain alphabetic characters. Please enter a valid city:");
                            city = Console.ReadLine().Trim();
                        }
                        employee.City = city;

                        Console.WriteLine(" ");


                        Console.WriteLine("Enter State (Required):");
                        string state = Console.ReadLine().Trim();
                        while (state == "" || !state.All(char.IsLetter))
                        {
                            Console.WriteLine("State is required and should only contain alphabetic characters. Please enter a valid State:");
                            state = Console.ReadLine().Trim();
                        }
                        employee.State = state;

                        Console.WriteLine(" ");


                        Console.WriteLine("Enter Postcode (Required, 6 digits):");
                        string postcode = Console.ReadLine().Trim();
                        while (!postcode.IsValidPostcode())
                        {
                            Console.WriteLine("Invalid input. Postcode should be a 6-digit number. Please enter a valid value:");
                            postcode = Console.ReadLine().Trim();
                        }
                        employee.Postcode = postcode;

                        Console.WriteLine(" ");


                        Console.WriteLine("Enter Phone number (10 digits):");
                        string phoneNumber = Console.ReadLine().Trim();
                        while (!phoneNumber.IsValidPhoneNumber())
                        {
                            Console.WriteLine("Invalid input. Please enter a 10-digit phone number:");
                            phoneNumber = Console.ReadLine().Trim();
                        }
                        employee.Phone = phoneNumber;

                        Console.WriteLine(" ");


                        Console.WriteLine("Enter Email (Required, Must be Valid):");
                        string email = Console.ReadLine().Trim();
                        while (!email.IsValidEmail() || employeeList.Any(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                        {
                            if (!email.IsValidEmail())
                            {
                                Console.WriteLine("Invalid email. Please enter a valid email address:");
                            }
                            else
                            {
                                Console.WriteLine($"An employee with the email {email} already exists.");
                            }
                            email = Console.ReadLine().Trim();
                        }
                        employee.Email = email;

                        Console.WriteLine(" ");


                        Console.WriteLine("Enter Date of Joining (Required, format: dd-MMMM-yyyy) (e.g. 01-Jan-2000):");
                        var enterDOB1 = Convert.ToDateTime(Console.ReadLine());
                        string DateOfJoining = ValidationExtensions.DateFormate(enterDOB1);
                        employee.DateOfJoining = DateOfJoining;
                        Console.WriteLine(DateOfJoining);

                        DateTime dateOfJoining = Convert.ToDateTime(DateOfJoining);
                        TimeSpan experience = DateTime.Now.Subtract(dateOfJoining);

                        int totalMonths = (DateTime.Now.Year - dateOfJoining.Year) * 12 + DateTime.Now.Month - dateOfJoining.Month;
                        int years = totalMonths / 12;
                        int months = totalMonths % 12;

                        Console.WriteLine(" ");
                        Console.WriteLine($"Total Experience: {years} years and {months} months");

                        employee.TotalExperience = $"{years} years and {months} months";

                        Console.WriteLine(" ");



                        Console.WriteLine("Enter Remarks (Required):");
                        string remarks = Console.ReadLine().Trim();
                        while (remarks == "")
                        {
                            Console.WriteLine("Remarks is required. Please enter a valid remarks:");
                            remarks = Console.ReadLine().Trim();
                        }
                        employee.Remarks = remarks;

                        Console.WriteLine(" ");


                        //Console.WriteLine("Enter Department (1: Sales, 2: Marketing, 3: Development, 4: QA, 5: SEO):");
                        //employee.Department = (Department)Convert.ToInt32(Console.ReadLine());
                        //Console.WriteLine(" ");

                        Department department;
                        bool isValidInput1;
                        do
                        {
                            Console.WriteLine("Enter Department (0: Sales, 1: Marketing, 2: Development, 3: QA, 4: SEO):");

                            isValidInput1 = Enum.TryParse(Console.ReadLine(), out department);

                            if (!isValidInput1 || !Enum.IsDefined(typeof(Department), department))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number (1, 2, 3, 4, or 5).");
                            }
                        }
                        while (!isValidInput1 || !Enum.IsDefined(typeof(Department), department));
                        employee.Department = department;
                        Console.WriteLine(" ");



                        Console.WriteLine("Enter Salary:");
                        decimal salary;
                        var validSalary = decimal.TryParse(Console.ReadLine().Trim(), out salary);
                        while (!validSalary || !salary.IsValidSalary())
                        {
                            Console.WriteLine("Invalid input. Salary should be a valid number between 10,000 and 400,000. Please enter a valid value:");
                            validSalary = decimal.TryParse(Console.ReadLine().Trim(), out salary);
                        }
                        employee.MonthlySalary = salary;
                        Console.WriteLine(" ");

                        employeeList.Add(employee);
                        Console.WriteLine("\nEmployee Record created successfully");


                        // Sort the list of employees by monthly salary in descending order
                        employeeList = employeeList.OrderByDescending(e => e.MonthlySalary).ToList();

                        // Sort the list of employees by employee ID in ascending order
                        List<Employee> sortedList = employeeList.OrderBy(e => e.EmployeeID).ToList();

                        // Get the file path from the App.config file
                        //string filePath = ConfigurationManager.AppSettings["FilePath"];

                        string filePath = ConfigurationManager.AppSettings["FilePath"];


                        // Check if the file exists
                        if (File.Exists(filePath))
                        {
                            // If the file exists, read the existing data and deserialize it
                            string existingData = File.ReadAllText(filePath);
                            List<Employee> existingEmployees = JsonConvert.DeserializeObject<List<Employee>>(existingData);

                            // Add the new employee to the existing list
                            existingEmployees.Add(employee);

                            // Serialize the updated list to a JSON string
                            string employeeJson = JsonConvert.SerializeObject(existingEmployees, Formatting.Indented);

                            // Append the JSON string to the existing file
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

                        Console.WriteLine("\nEmployee Record saved to file successfully.");

                        break;


                    case 2:
                        string filePath1 = ConfigurationManager.AppSettings["FilePath"];
                        List<Employee> employeeList1 = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(filePath1));

                        Console.WriteLine("\nEnter the ID of the employee you want to delete:");
                        int employeeID = Convert.ToInt32(Console.ReadLine());
                        Employee employeeToDelete = employeeList1.Find(emp => emp.EmployeeID == employeeID);
                        if (employeeToDelete == null)
                        {
                            Console.WriteLine($"Employee with ID {employeeID} not found.");
                        }
                        else
                        {
                            employeeList1.Remove(employeeToDelete);
                            Console.WriteLine($"Employee with ID {employeeID} deleted successfully.");

                            string jsonToWrite = JsonConvert.SerializeObject(employeeList1, Formatting.Indented);
                            File.WriteAllText(filePath1, jsonToWrite);
                        }
                        break;

                    case 3:
                        continueProgram = false;
                        Console.WriteLine("\nApplication is closing...");
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter 1, 2 or 3.");
                        break;

                }
            }

            Console.ReadLine();

        }
    }
}
