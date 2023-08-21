using NPOI.HSSF.Record.Chart;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.Devices.PointOfService;

namespace ChallengeApp
{
    class Program
    {
        public string inputMark;
        public decimal grade;
        public int age;
        public static decimal result;
        private static object grades;
        private static string unsignedMark;
        private static string markwithsign;

        public static string FullName { get; private set; }

        public static void Main(string[] args)
        {
            Console.WriteLine("* Welcome in program Student Index*");
            Console.WriteLine("*************************************");            

            bool CloseApp = false;

            while (!CloseApp)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "1 - Add student's grades to the program memory and show statistics\n" +
                    "2 - Add student's grades to the .txt file and show statistics\n" +
                    "X - Close app\n");

                Console.WriteLine("What you want to do? \nPress key 1, 2 or X: ");
           
                switch (Console.ReadLine())
                {
                    case "1":
                        StudentInMemory(FullName); //Adds GradesTo Memory and get statistics
                        break;

                    case "2":
                        StudentInFile(FullName); //Adds grades to a file and show statistics
                                                 
                        break;

                    case "X":
                        CloseApp = true;
                        break;

                    default:
                        Console.WriteLine( "Invalid operation.\n");
                        continue;
                }
            }
            Console.WriteLine( "\n\nBye Bye! Press any key to leave.");
            Console.ReadKey();
        }

        private static void StudentInMemory(string fullName)
        {
            var studentinmemory = new StudentInMemory(FullName);
            
            while (true)
            {
                Console.WriteLine("Give FullName of student in the following format and then press enter key  (first letters should be capital, name and surname separated by space char) :");
                string FullName = Console.ReadLine();
                Regex checkFullName = new(@"^[A-Z]{1}[a-z\u00c0-\u017e]{2,}\s[A-Z]{1}[a-z\u00c0-\u017e]{2,}$");
                if (!checkFullName.IsMatch(FullName) | FullName == null)
                {
                    Console.WriteLine($"Student's FullName can not be empty, contain digits or is in incorect format, try agian!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Student's FullName is: {FullName}\n");
                }

                Console.WriteLine("Input age of student in the following format: dd");
                string? a = Console.ReadLine();
                Regex checkage = new(@"^[1-9]{1,}[0-9]{1,}$");
                if (!checkage.IsMatch(input: a))
                {
                    Console.WriteLine("Entered age is missing, in incorrect format or out of range - conversion failed!");
                    break;
                }
                else
                {
                    if (int.TryParse(a, out int age))
                    {
                        var ages = new List<int>();
                        ages.Add(age);
                        Console.WriteLine(value: $"Student {FullName} is at age : {age} ");
                    }
                    else
                    {
                        throw ArgumentException("Invalid argument!");
                    }
                }

                for (int i = 0; i <= 3; i++)
                {
                    Console.WriteLine("Input grade achived by student in the following format: d,dd");
                    var inputMark = Console.ReadLine();

                    Regex check_inputMark = new(@"^[1-6]{1}(\,)[0-9]{2,} $");
                    Regex check_markwithsign = new(pattern: @"^[1-5]{1}\+ $ | ^[2-6]{1}\-$");

                    if (!(check_markwithsign.IsMatch(input: inputMark) || inputMark is not null))
                    {
                        Console.WriteLine("Entered grade with sign is in incorect format!");
                        break;
                    }
                    else
                    {
                        try
                        {
                            studentinmemory.AddGrade(inputMark);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Exception catched: {e.Message}");
                        }
                    }
                    studentinmemory.GradeAdded += StudentGradeAdded;


                    void StudentGradeAdded(object sender, EventArgs args)
                    {
                        Console.WriteLine("New grade added");
                    }

                    if (inputMark == "q")
                    {
                        break;
                    }
                    else
                    {
                        var statistics = studentinmemory.GetStatistics();
                        Console.WriteLine(value: $"Grades achived by student {FullName}  are: \n ");
                        Console.WriteLine($"The Min value of these grades  is : {statistics.Min:N2}");
                        Console.WriteLine($"The Max value of these grades  is : {statistics.Max:N2}");
                        Console.WriteLine($"The Average of these grades  is : {statistics.Average:N2}");
                        Console.WriteLine($"Total grade is: {statistics.AverageLetter} ");
                    }

                }

            }
        }



        private static void StudentInFile(string fullName)
        {
            var studentinfile = new StudentInFile(FullName);

            while (true)
            {
                Console.WriteLine("Give FullName of student in the following format and then press enter key  (first letters should be capital, name and surname separated by space char) :");
                string FullName = Console.ReadLine();
                Regex checkFullName = new(@"^[A-Z]{1}[a-z\u00c0-\u017e]{2,}\s[A-Z]{1}[a-z\u00c0-\u017e]{2,}$");
                if (!checkFullName.IsMatch(FullName) | FullName == null)
                {
                    Console.WriteLine($"Student's FullName can not be empty, contain digits or is in incorect format, try agian!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Student's FullName is: {FullName}\n");
                    studentinfile.FullNames.Append(FullName);
                }

                Console.WriteLine("Input age of student in the following format: dd");
                string? a = Console.ReadLine();
                Regex checkage = new(@"^[1-9]{1,}[0-9]{1,}$");
                if (!checkage.IsMatch(input: a))
                {
                    Console.WriteLine("Entered age is missing, in incorrect format or out of range - conversion failed!");
                    break;
                }
                else
                {
                    if (int.TryParse(a, out int age))
                    {
                        var ages = new List<int>();
                        ages.Add(age);
                        Console.WriteLine(value: $"Student {FullName} is at age : {age} ");
                    }
                    else
                    {
                        throw ArgumentException("Invalid argument!");
                    }
                }

                for (int i = 0; i <= 3; i++)
                {
                    Console.WriteLine("Input grade achived by student in the following format: d,dd");
                    var inputMark = Console.ReadLine();

                    Regex check_inputMark = new(@"^[1-6]{1}(\,)[0-9]{2,} $");
                    Regex check_markwithsign = new(pattern: @"^[1-5]{1}\+ $ | ^[2-6]{1}\-$");

                    if (!(check_markwithsign.IsMatch(input: inputMark) || inputMark is not null))
                    {
                        Console.WriteLine("Entered grade with sign is in incorect format!");
                        break;
                    }
                    else
                    {
                        try
                        {
                            studentinfile.AddGrade(inputMark);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Exception catched: {e.Message}");
                        }
                    }
                    studentinfile.GradeAdded += StudentGradeAdded;


                    void StudentGradeAdded(object sender, EventArgs args)
                    {
                        Console.WriteLine("New grade added");
                    }                    

                    if (inputMark == "q")
                    {
                        break;
                    }
                    else
                    {
                        var statistics = studentinfile.GetStatistics();
                        Console.WriteLine(value: $"Grades achived by student {FullName}  are: \n ");
                        Console.WriteLine($"The Min value of these grades  is : {statistics.Min:N2}");
                        Console.WriteLine($"The Max value of these grades  is : {statistics.Max:N2}");
                        Console.WriteLine($"The Average of these grades  is : {statistics.Average:N2}");
                        Console.WriteLine($"Total grade is: {statistics.AverageLetter} ");
                    }

                }

            }
        }

        private static Exception ArgumentException(string v)
        {
            throw new NotImplementedException();
        }
    }
}