using MathNet.Numerics.Statistics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Windows.Networking;

namespace ChallengeApp
{
    public class StudentInFile : StudentBase
    {
        private const string fileName = "grades.txt";
        private object fullNameFile;

        public StudentInFile(string fullName) : base(fullName)
        {
             string fullNameFile = ($"{base.fullName}_{fileName}");
        }

        //public StudentInFile(string fullname) : base(fullname)
        //{
        //    using (var writer = File.AppendText(fileName))
        //    {
        //        writer.WriteLine($" Student's {fullname} grades are : \n");
        //    }
        //}
        //public StudentInFile(string fulltName ) : base(fullName)
        //{
            
        //}
        //public override void AddGrade(string grade)
        //{
        //    using (var writer = File.AppendText(fileName))
        //    {
        //        writer.WriteLine(grade);
        //    }
        //}

        public override void AddGrade(char grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
            }
        }

        public override void AddGrade(decimal grade)
        {
            using (var writer = File.AppendText(fileName))
            {
               // using (var writer1 = File.AppendText($"{fullNameFile}"))
                using (var writer2 = File.AppendText($"audit.txt"))
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"{fullNameFile} - {grade}        {DateTime.UtcNow}");
                    //if (grade < 3)
                    //{
                    //    CheckEventGradeUnder3();
                    //}
                }
            }
        }

        public override void AddGrade(int grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
            }
        }

        public override void AddGrade(string inputMark)
        {
            switch (inputMark)
            {
                case "1+":
                    // this.grades.Add(1.5M);
                    this.AddGrade(1.5M);
                    break;
                case "2+":
                    this.AddGrade(2.5M);
                    break;
                case "3+":
                    this.AddGrade(3.5M);
                    break;
                case "4+":
                    this.AddGrade(4.5M);
                    break;
                case "5+":
                    this.AddGrade(5.5M);
                    break;
                case "6-":
                    this.AddGrade(5.75M);
                    break;
                case "5-":
                    this.AddGrade(4.75M);
                    break;
                case "4-":
                    this.AddGrade(3.75M);
                    break;
                case "3-":
                    this.AddGrade(2.75M);
                    break;
                case "2-":
                    this.AddGrade(1.75M);
                    break;

                default:

                    var converter = decimal.TryParse(inputMark, out decimal grade);
                    if (converter)
                    {
                        if (grade >= 1 && grade <= 6)
                        {
                            this.AddGrade(grade);
                        }
                        else
                        {
                            throw new ArgumentException("Grade is out of range!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Grade is not a number! Conversion failed");
                    }
                    break;
            }
        }
          public override void ShowGrades()
        {
            StringBuilder sb = new StringBuilder($"{this.fullName}  grades are: ");

            using (var reader = File.OpenText(($"{fileName}")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sb.Append($"{line}; ");
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine($"\n{sb}");
        }
        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }

        public override Statistics CountStatistics(List<decimal> gradesFromFile)
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Max = decimal.MinValue;
            statistics.Min = decimal.MaxValue;

            foreach (var grade in grades)
            {
                if(grade>=0)
                {
                    statistics.Max = Math.Max(statistics.Max, grade);
                    statistics.Min = Math.Min(statistics.Min, grade);
                    statistics.Average += grade;
                }
            }
            statistics.Average /= gradesFromFile.Count;
            switch (statistics.Average)
            {
                case var average when average >= 5:
                    statistics.AverageLetter = 'A';
                    break;
                case var average when average >= 4:
                    statistics.AverageLetter = 'B';
                    break;
                case var average when average >= 3:
                    statistics.AverageLetter = 'C';
                    break;
                case var average when average >= 2:
                    statistics.AverageLetter = 'D';
                    break;
                case var average when average >= 1:
                    statistics.AverageLetter = 'E';
                    break;
                default:
                    throw new Exception(" Wrong letter");
            }
        }
        return Statistics;
        private List<decimal>ReadGradesFromFile()
        {
            var grades=new List<decimal>();
            var result = new Statistics();
            if (File.Exists($"{fileName}"))
            {
                //
                //result.Average = 0.0M;
                //result.High = decimal.MinValue;
                //result.Low = decimal.MaxValue;
                int count = 0;
                //statistics.Average = 0.0M;
                //statistics.High = decimal.MinValue;
                //statistics.Low = decimal.MaxValue;
                //int count = 0;
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();

                    while (line != null) ;
                    {
                        var grade = decimal.Parse(line);
                        // foreach (var grade in this.grades)
                        // {
                        grades.Add(grade); //grades.AddGrade();
                        //result.Low = Math.Min(grade, result.Low);
                        //result.High = Math.Max(grade, result.High);
                        //result.Average += grade;
                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;       //result.Average /= count;
        }
        

        public override Statistics CountStatistics()
        {
            throw new NotImplementedException();
        }
        
    }
     /*result;*/ //grades; //result;
}

        //return result;
    


