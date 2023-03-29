using System;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace C_Day_3
{
    public static class DateTimeExtensions
    {
        public static string DateFormat(this DateTime date, string format)
        {
            return date.ToString(format);
        }

    }

    public static class prac_1
    {

        public static string Encrypt(string email)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(email);
            return Convert.ToBase64String(bytes, Base64FormattingOptions.None);
        }
        public static string Decrypt(string encryptedEmail)
        {
            byte[] bytes = Convert.FromBase64String(encryptedEmail);
            return Encoding.UTF8.GetString(bytes);
        }



        static void Main(String[] args)
        { 
            while (true)
            {
                Console.WriteLine("Enter the number");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        string fileName = @"D:\C# Training\C#Day_3\prac_1.txt";

                        try
                        {
                            if (File.Exists(fileName))
                            {
                                Console.WriteLine("Create a file with text:");
                                string text = Console.ReadLine();

                                using (StreamWriter filewrite = File.CreateText(fileName))
                                { 
                                    filewrite.WriteLine(text);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }   
                        Console.ReadLine();
                        break;



                    case 2:
                        string file = @"D:\C# Training\C#Day_3\prac_2.txt";

                        try
                        {
                            if (File.Exists(file))
                            {
                                Console.WriteLine("Create file and read the file:");

                                using (StreamWriter filewrite = File.CreateText(file))
                                {
                                    filewrite.WriteLine("Mahediali Momin");
                                    filewrite.WriteLine("This is second file");
                                }
                                using (StreamReader fileread = File.OpenText(file))
                                {
                                    string s = "";
                                    while ((s = fileread.ReadLine()) != null)
                                    {
                                        Console.WriteLine(s);
                                    }
                                    Console.ReadLine();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        Console.ReadLine();
                        break;



                    case 3:
                        string file3 = @"D:\C# Training\C#Day_3\prac_3.txt";

                        string[] lines;

                        try
                        {
                            Console.WriteLine("Enter the number of elements:");
                            int n = Convert.ToInt32(Console.ReadLine());

                            lines = new string[n];
                            for (int i = 0; i < n; i++)
                            {
                                Console.Write("Enter element {0}: ", i + 1);
                                lines[i] = Console.ReadLine();
                            }

                            // Write the array of strings to the file
                            File.WriteAllLines(file3, lines);

                            // Read and display the contents of the file
                            using (StreamReader sr = File.OpenText(file3))
                            {
                                Console.WriteLine("The contents of the file are:");
                                Console.WriteLine("----------------------------------");
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        Console.ReadLine();
                        break;



                    case 4:

                        string file4 = @"D:\C# Training\C#Day_3\prac_4.txt";

                        try
                        {
                            if (File.Exists(file4))
                            {
                                Console.WriteLine("Read the file:");

                                using (StreamWriter filewrite = File.CreateText(file4))
                                {
                                    filewrite.WriteLine("Mahediali Momin");
                                    filewrite.WriteLine("This is second file");
                                }

                                using (StreamReader fileread = File.OpenText(file4))
                                {
                                    string s = "";
                                    while ((s = fileread.ReadLine()) != null)
                                    {
                                        Console.WriteLine(s);
                                    }
                                    Console.ReadLine();
                                }

                                using (StreamWriter files = File.AppendText(file4))
                                {
                                    files.WriteLine("This is the line appended at last line.");
                                }

                                Console.WriteLine("After appending:");

                                using (StreamReader fileread = File.OpenText(file4))
                                {
                                    string s = "";
                                    while ((s = fileread.ReadLine()) != null)
                                    {
                                        Console.WriteLine(s);
                                    }
                                    Console.WriteLine(" ");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("File does not exist.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        Console.ReadLine();
                        break;


                    case 5:
                        string file5 = @"D:\C# Training\C#Day_3\prac_5.txt";

                        try
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Read the all lines from a file :");

                            using (StreamWriter filewrite = File.CreateText(file5))
                            {
                                Console.WriteLine("");
                                filewrite.WriteLine("Mahediali Momin");
                                filewrite.WriteLine("Hello and welcome");
                            }
                            using (StreamReader fileread = File.OpenText(file5))
                            {
                                string s = "";
                                while ((s = fileread.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.ReadLine();
                            }

                            Console.WriteLine("The content of the first line of the file is :");

                            if (File.Exists(file5))
                            {
                                string[] line = File.ReadAllLines(file5);
                                Console.WriteLine(line[0]);
                            }
                            Console.WriteLine();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;



                    case 6:
                        string file6 = @"D:\C# Training\C#Day_3\prac_6.txt";
                        int count;

                        try
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Count the number of lines in a file :");

                            using (StreamWriter filewrite = File.CreateText(file6))
                            {
                                Console.WriteLine("");
                                filewrite.WriteLine("Mahediali Momin");
                                filewrite.WriteLine("Hello and welcome");
                            }
                            using (StreamReader fileread = File.OpenText(file6))
                            {
                                string s = "";
                                count = 0;
                                while ((s = fileread.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                    count++;
                                }
                                Console.ReadLine();
                            }
                            Console.Write("Number of lines in file is : {0} \n", count);
                            Console.WriteLine("");
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;


                    case 7:

                        try
                        {
                            int x = 5;
                            int y = 0;
                            int z = x / y;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            Console.WriteLine();
                        }
                        break;


                    case 8:

                        try
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Enter the first value:");
                            int x = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the second value:");
                            int y = int.Parse(Console.ReadLine());

                            int z = x / y;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            Console.WriteLine();
                        }
                        break;


                    case 9:

                        try
                        {
                            Console.WriteLine("Enter date format (e.g. dd/MM/yyyy):");
                            string format = Console.ReadLine();
                            Console.WriteLine("");

                            DateTime today = DateTime.Now;
                            //string format = "dd/MM/yyyy";
                            string formattedDate = today.DateFormat(format);
                            Console.WriteLine(formattedDate);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            Console.WriteLine();
                        }
                        break;



                    case 10:

                        try
                        {
                            string s = null;
                            if (s == null)
                            {
                                throw new ArgumentNullException(nameof(s));
                            }
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            Console.WriteLine();
                        }
                        break;


                    case 11:

                        string nameoffile = @"D:\C# Training\C#Day_3\prac_11.txt";
                        try
                        {
                            Console.Write("Enter the email: ");
                            string email = Console.ReadLine();

                            string encryptedEmail = Encrypt(email); // encrypt the email

                            using (StreamWriter sw = File.CreateText(nameoffile))
                            {
                                sw.WriteLine("EncryptedEmail:- " + encryptedEmail); // write the encrypted email to the file
                            }
                            string decryptedEmail = Decrypt(encryptedEmail);
                            using (StreamWriter sw = File.AppendText(nameoffile))
                            {
                                sw.WriteLine("DecryptedEmail:- " + decryptedEmail); // write the decrypted email to the file
                            }
                            using (StreamReader sr = File.OpenText(nameoffile))
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.ReadLine();
                            }

                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                        }

                        Console.ReadKey();

                        break;



                    case 12:
                        string file1 = @"D:\C# Training\C#Day_3\prac_12.txt";
                        try
                        {
                            string password = ConfigurationManager.AppSettings["UserPassword"];

                            string encryptedEmail = Encrypt(password); // encrypt the email

                            using (StreamWriter sw = File.CreateText(file1))
                            {
                                sw.WriteLine("Encryptedpassword:- " + encryptedEmail); // write the encrypted email to the file
                            }
                            using (StreamReader sr = File.OpenText(file1))
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.ReadLine();
                            }

                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                        }

                        Console.ReadKey();

                        break;
                }
            }
        }
    }
}
