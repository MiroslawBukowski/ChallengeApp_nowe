//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ChallengeApp
//{
//    internal class Master : IStudent
//    {
//        public List<decimal> grades = new List<decimal>();
//        string IStudent.FullName // {get;} // => throw new NotImplementedException();
//       //public string FullName { get; private set; }
//        {
//            this.FullName = FullName;   
//        }
//        public int age { get; private set; }

//        public string? FullName { get; private set; } //=> throw new NotImplementedException();

//        // public object grades { get; private set; }

//        void IStudent.AddAge(int age)
//        {
//            this.age = age;
//        }

//         void IStudent.AddGrade(string inputmark)
//        {
//            ReadOnlySpan<char> inputMark = default;
//            if (decimal.TryParse(inputMark, out decimal grade))
//            {
//                if (grade >= 1 && grade <= 6)
//                {
//                    this.grades.Add(grade);
//                    Console.WriteLine($"Grade added to Student's grades list: {grade} ");
//                }
//                else
//                {
//                    throw new ArgumentException("Grade is out of range!");
//                }
//            }
//            else
//            {
//                throw new Exception("Grade Conversion failed!");
//            }
//        }

//        void IStudent.AddGrade(char grade)
//        {
//            this.grades.Add(grade);
//        }

//        void IStudent.AddGrade(decimal grade)
//        {
//            this.grades.Add(grade);
//        }

//        void IStudent.AddGrade(int grade)
//        {
//            this.grades.Add(grade); 
//        }

//        public int IStudent.ChangeGrade(string inputMark)
//        {
//            switch (inputMark)
//            {
//                case "6":
//                    //object value = this.grades.Add(100); //=>100;
//                    this.grades.Add(100);
//                    break;
//                case "6-": // => 95;
//                    this.grades.Add(95);
//                    break;
//                case "-6": //=>95;
//                    this.grades.Add(95);
//                    break;
//                case "5+": // => 85;
//                    this.grades.Add(85);
//                    break;
//                case "+5": // =>85;
//                    this.grades.Add(85);
//                    break;
//                case "5": // =>80;
//                    this.grades.Add(80);
//                    break;
//                case "-5": //=>75;
//                    this.grades.Add(75);
//                    break;
//                case "5-": //-=> 75;
//                    this.grades.Add(75);
//                    break;
//                case "+4": // =>65;
//                    this.grades.Add(65);
//                    break;
//                case "4+": // => 65;
//                    this.grades.Add(65);
//                    break;
//                case "4": // =>60;
//                    this.grades.Add(60);
//                    break;
//                case "-4": // =>55;
//                    this.grades.Add(55);
//                    break;
//                case "4-": // => 55;
//                    this.grades.Add(55);
//                    break;
//                case "+3": // =>45;
//                    this.grades.Add(45);
//                    break;
//                case "3+": // => 45;
//                    this.grades.Add(45);
//                    break;
//                case "3": // =>40;
//                    this.grades.Add(40);
//                    break;
//                case "-3": // =>35;
//                    this.grades.Add(35);
//                    break;
//                case "3-": //=> 35;
//                    this.grades.Add(35);
//                    break;
//                case "+2": // =>25;
//                    this.grades.Add(25);
//                    break;
//                case "2+": // => 25;
//                    this.grades.Add(25);
//                    break;
//                case "2": // =>20;
//                    this.grades.Add(20);
//                    break;
//                case "-2": // =>15;
//                    this.grades.Add(15);
//                    break;
//                case "2-": // -=> 15;
//                    this.grades.Add(15);
//                    break;
//                case "+1": // =>5;
//                    this.grades.Add(5);
//                    break;
//                case "1+": // => 5;
//                    this.grades.Add(5);
//                    break;
//                case "1": // =>0;
//                    this.grades.Add(0);
//                    break;

//                default:

//                    var converter = decimal.TryParse(inputMark, out decimal grade);
//                    if (converter)
//                    {
//                        if (grade >= 1 && grade <= 6)
//                        {
//                            this.grades.Add(grade);
//                        }
//                        else
//                        {
//                            throw new ArgumentException("Grade is out of range!");
//                        }
//                    }
//                    else
//                    {
//                        throw new ArgumentException("Grade is not a number! Cobversion failed");
//                    }
//                    break;
//            }
//        }

//        Statistics IStudent.GetStatistics()
//        {
//            var result = new Statistics();
//            result.Average = 0.0M;
//            result.High = decimal.MinValue;
//            result.Low = decimal.MaxValue;

//            foreach (var grade in this.grades)
//            {
//                result.Low = Math.Min(grade, result.Low);
//                result.High = Math.Max(grade, result.High);
//                result.Average += grade;
//            }
//            result.Average /= grades.Count;

//            switch (result.Average)
//            {
//                case var average when average >= 5:
//                    result.AverageLetter = 'A';
//                    break;
//                case var average when average >= 4:
//                    result.AverageLetter = 'B';
//                    break;
//                case var average when average >= 3:
//                    result.AverageLetter = 'C';
//                    break;
//                case var average when average >= 2:
//                    result.AverageLetter = 'D';
//                    break;
//                case var average when average >= 1:
//                    result.AverageLetter = 'E';
//                    break;
//                default:
//                    throw new Exception(" Wrong letter");
//            }
//            return result;
//        }

//        public void ChangeGrade(string inputMark)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
