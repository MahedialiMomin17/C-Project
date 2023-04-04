using System;
using System.Collections.Generic;

namespace OfficeManagementSystem
{
    // Base class
    public class Employee
    {
        // Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }

        // Constructor
        public Employee(string name, int age, string department, string position)
        {
            Name = name;
            Age = age;
            Department = department;
            Position = position;
        }

        // Virtual method
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Position: {Position}");
        }
    }

    // Inherited class from Employee
    public class Developer : Employee
    {
        // Properties
        public string ProgrammingLanguage { get; set; }

        // Constructor
        public Developer(string name, int age, string department, string position, string programmingLanguage)
            : base(name, age, department, position)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        // Overriding method
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
        }
    }


    public class Designer : Employee
    {
        public string DesignSoftware { get; set; }

        public Designer(string name, int age, string department, string position, string designSoftware)
            : base(name, age, department, position)
        {
            DesignSoftware = designSoftware;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Design Software: {DesignSoftware}");
        }
    }


    public class Marketing : Employee
    {
   
        public string MarketingCampaign { get; set; }

        public Marketing(string name, int age, string department, string position, string marketingCampaign)
            : base(name, age, department, position)
        {
            MarketingCampaign = marketingCampaign;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Marketing Campaign: {MarketingCampaign}");
        }
    }

    public class Content : Employee
    {

        public string WritingType { get; set; }

        public Content(string name, int age, string department, string position, string writingType)
            : base(name, age, department, position)
        {
            WritingType = writingType;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Writing Type: {WritingType}");
        }
    }

    // Office management system class
    public class OfficeManagementSystem
    {
        static void Main(string[] args)
        {
            // List of employees
            List<Employee> employees = new List<Employee>();

            employees.Add(new Developer("Soham bhai", 30, "IT", "Developer", "C#"));
            employees.Add(new Designer("Mahediali", 25, "Design", "Designer", "Adobe Photoshop"));
            employees.Add(new Marketing("Krinal", 35, "Marketing", "Marketing Manager", "Email"));
            employees.Add(new Content("Amit", 28, "Content", "Content Writer", "Blog"));

            foreach (Employee employee in employees)
            {
                employee.DisplayInfo();
                Console.WriteLine("----------------------------------");
            }
            Console.ReadLine();
        }
    }

}