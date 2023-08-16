namespace ChallengeApp
{
    public class StudentInMemory : StudentBase
    {
        public StudentInMemory(string fullname) : base(fullname)
        {
        }
        public List<decimal> grades = new List<decimal>();
        ////public override void AddGrade(string inputMark)
        ////{
        ////    if (decimal.TryParse(inputMark, out decimal grade))
        ////    {
        ////        if (grade >= 1 && grade <= 6)
        ////        {
        ////            this.grades.Add(grade);
        ////            Console.WriteLine($"Grade added to Student's grades list: {grade} ");
        ////        }
        ////        else


        ////        {
        ////            throw new ArgumentException("Grade is out of range!");
        ////        }

        ////    }
        ////    else if(inputMark.Length==2)
        //////    {
        //////        AddGradeWithSign(inputMark);
        //////    }
        ////        else
        //    {
        //        throw new Exception("Grade Conversion failed!");
        //    }
        //}

        public override void AddGrade(char grade)
        {
            this.grades.Add(grade);
        }

        public override void AddGrade(decimal grade)
        {
            this.grades.Add(grade);
        }

        public override void AddGrade(int grade)
        {
            this.grades.Add(grade);
        }

        public override void AddGrade(string inputMark)
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

        public override Statistics GetStatistics()
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

            switch (result.Average)
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
            }
            return result;
        }

        public override void ShowGrades()
        {
            throw new NotImplementedException();
        }

        public override Statistics CountStatistics()
        {
            throw new NotImplementedException();
        }

        public override Statistics CountStatistics(List<decimal> grades)
        {
            throw new NotImplementedException();
        }
    }
}
