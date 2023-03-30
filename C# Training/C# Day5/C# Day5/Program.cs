using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace C__Day5
{
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public City() { }

        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public override string ToString()
        {
            return $"City name: {Name}, Population: {Population}";
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public City City { get; set; }

        public Person() { }

        public Person(string name, int age, City city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, {City.ToString()}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the person's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the person's age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter the city's name: ");
            string cityName = Console.ReadLine();

            Console.Write("Enter the city's population: ");
            int cityPopulation = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            City city = new City(cityName, cityPopulation);
            Person person = new Person(name, age, city);

            Console.WriteLine(person.ToString());


            // Serialize the object to a JSON file
            string filePath = @"D:\C# Training\C# Day5\prac1.json";
            string jsonString = JsonConvert.SerializeObject(person, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);

            // Deserialize the object from the JSON file and print it
            string jsonFromFile = File.ReadAllText(filePath);
            Person bsObj = JsonConvert.DeserializeObject<Person>(jsonFromFile);

            Console.WriteLine("  ");
            Console.WriteLine(bsObj.Name);
            Console.WriteLine(bsObj.Age);
            Console.WriteLine(bsObj.City);

            SerializeXML(person);

            Console.ReadLine();
        }
        static public void SerializeXML(Person person)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (TextWriter writer = new StreamWriter(@"D:\C# Training\C# Day5\prac1.xml"))
            {
                serializer.Serialize(writer, person);
            }

            // Deserialize the object from the XML file and print it
            XmlSerializer serializer1 = new XmlSerializer(typeof(Person));
            using (TextReader reader = new StreamReader(@"D:\C# Training\C# Day5\prac1.xml"))
            {
                Person xmlObj = (Person)serializer.Deserialize(reader);
                Console.WriteLine("");
                Console.WriteLine(xmlObj.Name);
                Console.WriteLine(xmlObj.Age);
                Console.WriteLine(xmlObj.City);
            }

        }
    }
}
