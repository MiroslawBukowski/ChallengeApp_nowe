using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Student : Person
    {
        public List<decimal> grades = new List<decimal>();
        public List<string> FullNames = new List<string>();
        //public List<int> ages = new List<int>();

       // public string Name { get; set; }

        public Student(string FullName)
           : base(FullName)
        {
            this.fullName = FullName;   
        }

        public Student(int age)
            : base(age)
        {
            this.age = age;
        }

        public void AddGrade(string inputMark)
        {
            if (decimal.TryParse(inputMark, out decimal grade))
            {
                if (grade >= 1 && grade <= 6)
                {
                    this.grades.Add(grade);
                    Console.WriteLine($"Grade added to Student's grades list: {grade} ");
                }
                else
                {
                    throw new ArgumentException("Grade is out of range!");
                }
            }
            else
            {
                throw new Exception("Grade Conversion failed!");               
            }
        }
        public void ChangeGrade(string inputMark)
        {
            switch (inputMark)
            {
                case "1+":
                    this.grades.Add(1.5M);
                    break;
                case "2+":
                    this.grades.Add(2.5M);
                    break;
                case "3+":
                    this.grades.Add(3.5M);
                    break;
                case "4+":
                    this.grades.Add(4.5M);
                    break;
                case "5+":
                    this.grades.Add(5.5M);
                    break;
                case "6-":
                    this.grades.Add(5.75M);
                    break;
                case "5-":
                    this.grades.Add(4.75M);
                    break;
                case "4-":
                    this.grades.Add(3.75M);
                    break;
                case "3-":                   
                    this.grades.Add(2.75M);
                    break;
                case "2-":
                    this.grades.Add(1.75M);
                    break;

                default:

                    var converter = decimal.TryParse(inputMark, out decimal grade);
                    if (converter)
                    {
                        if (grade >= 1 && grade <= 6)
                        {
                            this.grades.Add(grade);
                        }
                        else
                        {
                            throw new ArgumentException("Grade is out of range!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Grade is not a number! Cobversion failed");
                    }
                    break;
            }
        }
        public void AddGrade(decimal grade)
        {
            this.grades.Add(grade);
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
        }

        public object age { get; internal set; }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }
    }
}
