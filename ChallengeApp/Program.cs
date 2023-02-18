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

        public static string FullName { get; private set; }

        public static void Main(string[] args)
        {
            Console.WriteLine("* Welcome in program Student Index*");
            Console.WriteLine("*************************************");

            var student = new Student(FullName);

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
                Regex checkage = new(@"^[1-9]{2,}$");
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
                    Student: student.ChangeGrade(inputMark);
                    }

                    if (!(check_inputMark.IsMatch(input: inputMark) || inputMark is not null))
                    {
                        Console.WriteLine("Entered grade is missing, in incorrect format or out of range - conversion failed!");
                        break;
                    }
                    else

                     if (check_markwithsign.IsMatch(inputMark) && !decimal.TryParse(inputMark, out decimal grade))
                    {
                        student.AddGrade(grade);
                    }

                    if (inputMark == "q")
                    {
                        break;
                    }
                    else
                    {                       
                        var stat = student.GetStatistics();
                        Console.WriteLine(value: $"Grades achived by student {FullName}  are: \n ");
                        Console.WriteLine($"The Min value of these grades  is : {stat.Low:N2}");
                        Console.WriteLine($"The Max value of these grades  is : {stat.High:N2}");
                        Console.WriteLine($"The Average of these grades  is : {stat.Average:N3}");
                        Console.WriteLine($"Total grade is: {stat.AverageLetter} ");
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