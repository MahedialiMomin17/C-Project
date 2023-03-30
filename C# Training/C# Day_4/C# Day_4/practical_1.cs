using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_4
{
    class Student
    {
        private int studentId;
        private string studentName;
        private DateTime studentDOB;
        private string studentRollNo;
        private string studentEmail;
        private double[] studentGPA = new double[5];
        //private string v1;
        //private DateTime dateTime;
        //private int v2;
        //private string v3;
        //private double[] doubles;

        public Student(Student other)
        {
            this.StudentId = other.StudentId;
            this.StudentName = other.StudentName;
            this.StudentDOB = other.StudentDOB;
            this.StudentRollNo = other.StudentRollNo;
            this.StudentEmail = other.StudentEmail;
            this.StudentGPA = new double[5];
            Array.Copy(other.StudentGPA, this.StudentGPA, 5);
        }

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        public DateTime StudentDOB
        {
            get { return studentDOB; }
            set { studentDOB = value; }
        }

        public string StudentRollNo
        {
            get { return studentRollNo; }
            set { studentRollNo = value; }
        }

        public string StudentEmail
        {
            get { return studentEmail; }
            set { studentEmail = value; }
        }

        public double[] StudentGPA
        {
            get { return studentGPA; }
            set { studentGPA = value; }
        }


        //public Student(int id, string name, DateTime dob, string rollNo, string email)
        //{
        //    StudentId = id;
        //    StudentName = name;
        //    StudentDOB = dob;
        //    StudentRollNo = rollNo;
        //    StudentEmail = email;
        //}

        public Student(int id, string name, DateTime dob, string rollNo, string email)
        {
            StudentId = id;
            StudentName = name;
            StudentDOB = dob;
            StudentRollNo = rollNo;
            StudentEmail = email;
            for (int i = 0; i < studentGPA.Length; i++)
            {
                studentGPA[i] = 3.0;
            }
        }

        public Student(string v)
        {
        }

        //public Student(string v, string v1, DateTime dateTime, int v2, string v3, double[] doubles) : this(v)
        //{
        //    this.v1 = v1;
        //    this.dateTime = dateTime;
        //    this.v2 = v2;
        //    this.v3 = v3;
        //    this.doubles = doubles;
        //}

        public Student()
        {
        }

        public double calculateCGPA()
        {
            double sum = 0;
            for (int i = 0; i < StudentGPA.Length; i++)
            {
                sum += StudentGPA[i];
            }
            return sum / StudentGPA.Length;
        }


        public static Student findCR(Student[] students)
        {
            double maxCGPA = 0;
            Student cr = null;
            foreach (Student student in students)
            {
                double cgpa = student.calculateCGPA();
                if (cgpa > maxCGPA)
                {
                    maxCGPA = cgpa;
                    cr = student;
                }
            }
            return cr;
        }

        public static Student operator +(Student s1, Student s2)
        {
            // create a new Student object to store the result
            Student result = new Student();

            // add corresponding data members
            result.StudentId = s1.StudentId + s2.StudentId;
            result.StudentName = s1.StudentName + " " + s2.StudentName;
            result.StudentDOB = s1.StudentDOB.AddYears(s2.StudentDOB.Year - 1);
            result.StudentRollNo = s1.StudentRollNo + " " + s2.StudentRollNo;
            result.StudentEmail = s1.StudentEmail + " " + s2.StudentEmail;

            // add GPAs
            for (int i = 0; i < s1.StudentGPA.Length; i++)
            {
                result.StudentGPA[i] = s1.StudentGPA[i] + s2.StudentGPA[i];
            }

            return result;
        }





        internal class practical_1
        {
          

            static double Add(double number1, double number2)
            {
                return number1 + number2;
            }
            static double Subtract(double number1, double number2)
            {
                return number1 - number2;
            }
            static double Multiply(double number1, double number2)
            {
                return number1 * number2;
            }
            static double Divide(double number1, double number2)
            {
                if (number2 == 0)
                {
                    Console.WriteLine("error: divison by zero");
                    return double.NaN;
                }
                else
                {
                    return number1 / number2;
                }
            }



            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Enter the number");
                    int option = Convert.ToInt32(Console.ReadLine());
                    //Student[] students = new Student[3];
                    switch (option)
                    {
                        case 1:

                            try
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Enter First Number: ");
                                double number1 = Convert.ToDouble(Console.ReadLine());

                                Console.WriteLine("Enter Second Number: ");
                                double number2 = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("");

                                Console.WriteLine("sum of {0} and {1} is  :- {2}", number1, number2, Add(number1, number2));
                                Console.WriteLine("subtract of {0} and {1} is  :- {2}", number1, number2, Subtract(number1, number2));
                                Console.WriteLine("multiply of {0} and {1} is  :- {2}", number1, number2, Multiply(number1, number2));
                                Console.WriteLine("divide of {0} and {1} is  :- {2}", number1, number2, Divide(number1, number2));

                                Console.ReadLine();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            break;


                        case 2:

                            Student[] students = new Student[0];

                            // Loop to get input for each student
                            while (true)
                            {
                                Console.WriteLine("");
                                Console.Write("Enter student ID (or type 'quit' to exit): ");
                                string input = Console.ReadLine();

                                // Check if the user wants to quit
                                if (input.ToLower() == "quit")
                                {
                                    break;
                                }

                                int studentId = int.Parse(input);

                                Console.Write("Enter student name: ");
                                string studentName = Console.ReadLine();

                                Console.Write("Enter student date of birth (yyyy-mm-dd): ");
                                DateTime studentDOB = DateTime.Parse(Console.ReadLine());

                                Console.Write("Enter student roll number: ");
                                string studentRollNo = Console.ReadLine();

                                Console.Write("Enter student email address: ");
                                string studentEmail = Console.ReadLine();

                                double[] studentGPA = new double[5];
                                for (int i = 0; i < studentGPA.Length; i++)
                                {
                                    Console.Write("Enter GPA for semester " + (i + 1) + ": ");
                                    double gpa = double.Parse(Console.ReadLine());

                                    if (gpa > 3.0)
                                    {
                                        Console.WriteLine("GPA cannot be greater than 3.0. Setting GPA to 3.0.");
                                        gpa = 3.0;
                                    }

                                     studentGPA[i] = gpa;
                                }

                                // Create a new student object with the input data
                                Student newStudent = new Student(studentId, studentName, studentDOB, studentRollNo, studentEmail);
                                newStudent.StudentGPA = studentGPA;

                                // Add the new student to the array
                                Array.Resize(ref students, students.Length + 1);
                                students[students.Length - 1] = newStudent;

                            }

                            // Print out the details for each student
                            for (int i = 0; i < students.Length; i++)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Details for student " + (i + 1) + ":");
                                Console.WriteLine("ID: " + students[i].StudentId);
                                Console.WriteLine("Name: " + students[i].StudentName);
                                Console.WriteLine("Date of Birth: " + students[i].StudentDOB.ToString("yyyy-MM-dd"));
                                Console.WriteLine("Roll Number: " + students[i].StudentRollNo);
                                Console.WriteLine("Email: " + students[i].StudentEmail);
                                Console.WriteLine("GPA:");
                                for (int j = 0; j < students[i].StudentGPA.Length; j++)
                                {
                                    Console.WriteLine("  Semester " + (j + 1) + ": " + students[i].StudentGPA[j]);

                                }

                                Console.WriteLine("");
                                Console.WriteLine("Overall CGPA: " + students[i].calculateCGPA());


                                // Find the CR of the class
                                Student cr = findCR(students);

                                // Print the CR's details
                                Console.WriteLine("");
                                Console.WriteLine("CR of the class:");
                                Console.WriteLine("Name: " + cr.StudentName);
                                Console.WriteLine("ID: " + cr.StudentId);
                                Console.WriteLine("CGPA: " + cr.calculateCGPA());

                            }

                            Student s1 = new Student(1, "John", new DateTime(2000, 1, 1), "A001", "john@example.com");
                            s1.StudentGPA = new double[] { 3.5, 3.8, 3.2, 3.7, 3.6 };

                            Student s2 = new Student(2, "Mary", new DateTime(2001, 2, 2), "A002", "mary@example.com");
                            s2.StudentGPA = new double[] { 3.6, 3.9, 3.4, 3.8, 3.7 };

                            Student s3 = s1 + s2;
                            Console.WriteLine("");
                            Console.WriteLine($"Student Id: {s3.StudentId}");
                            Console.WriteLine($"Student Name: {s3.StudentName}");


                            // Create original student object
                            //Student originalStudent = new Student("1234", "John Smith", new DateTime(2000, 1, 1), 1, "johnsmith@example.com", new double[] { 3.5, 4.0, 3.8, 3.9, 4.0 });

                            // Create copy of student using copy constructor
                            //Student copiedStudent = new Student(originalStudent);

                            //// Display copied student information in console
                            //Console.WriteLine("");
                            //Console.WriteLine("Copied Student Information:");
                            //Console.WriteLine("ID: " + copiedStudent.StudentId);
                            //Console.WriteLine("Name: " + copiedStudent.StudentName);
                            break;

                    }
                }

            }
        }
    }
}
