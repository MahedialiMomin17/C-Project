using System;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;

enum Gender
{
    Male = 1,
    Female = 2,
    Other = 3
}

public class AdmissionDetails
{
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}

public static class Program
{
    public static bool IsValidEmail(this string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public static bool IsValidPhoneNumber(this string phoneNumber)
    {
        int Number;
        return int.TryParse(phoneNumber, out Number) && phoneNumber.Length == 10;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Admission Portal\n");

        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        string fullName = $"{firstName} {lastName}";

        Console.WriteLine("\nSelect your gender:");
        Console.WriteLine("1. Male");
        Console.WriteLine("2. Female");
        Console.WriteLine("3. Other");
        Gender gender = (Gender)int.Parse(Console.ReadLine());

        Console.Write("Enter your email address: ");
        string email = Console.ReadLine();

        while (!IsValidEmail(email))
        {
            Console.WriteLine("Invalid email address. Please enter a valid email address: ");
            email = Console.ReadLine();
        }

        Console.Write("Enter your phone number: ");
        string phoneNumber = Console.ReadLine();

        while (!IsValidPhoneNumber(phoneNumber))
        {
            Console.WriteLine("Invalid phone number. Please enter a valid 10-digit phone number: ");
            phoneNumber = Console.ReadLine();
        }

        Console.Write("Enter your address (optional): ");
        string address = Console.ReadLine();

        Console.WriteLine("\nAdmission Details:");
        Console.WriteLine($"Name: {fullName}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Phone: {phoneNumber}");
        Console.WriteLine($"Address: {address}");

        // Create admission details object and set properties
        AdmissionDetails admissionDetails = new AdmissionDetails
        {
            FullName = fullName,
            Gender = gender,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address
        };

        // Serialize admission details object to XML
        XmlSerializer serializer = new XmlSerializer(typeof(AdmissionDetails));
        string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];
        using (TextWriter writer = new StreamWriter(xmlFilePath))
        {
            serializer.Serialize(writer, admissionDetails);
        }

        Console.WriteLine("\nAdmission details saved to XML file.");
    }
}
