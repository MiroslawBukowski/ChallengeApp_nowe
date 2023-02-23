using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Student : Person
    {
        public List<decimal> grades = new List<decimal>();
        public List<string> FullNames = new List<string>();
        public List<int> ages = new List<int>();

       // public string Name { get; set; }

        public Student(string FullName)
           : base(FullName)
        {
            this.FullNames.Add(FullName);
        }

        public Student(int age)
            : base(age)
        {
            this.ages.Add(age);
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
                return this.Name;
            }
        }

        public object age { get; internal set; }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0M;
            result.High = decimal.MinValue;
            result.Low = decimal.MaxValue;

            foreach (var grade in this.grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var average when average >= 5:
                    result.AverageLetter = 'A';
                    break;
                case var average when average >= 4:
                    result.AverageLetter = 'B';
                    break;
                case var average when average >= 3:
                    result.AverageLetter = 'C';
                    break;
                case var average when average >= 2:
                    result.AverageLetter = 'D';
                    break;
                case var average when average >= 1:
                    result.AverageLetter = 'E';
                    break;
                default:
                    throw new Exception(" Wrong letter");
                    //.Average = 0;
            }
            return result;
        }

        public int AddAge(int age)
        {
            var ages = new List<int>();
            ages.Add(age);
            return age;          
        }
    }
}
