using MathNet.Numerics.Statistics;
using NPOI.XWPF.UserModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Windows.Networking;

namespace ChallengeApp
{
    public class StudentInFile : StudentBase
    {
        private const string fileName = "grades.txt";       
        public List<decimal> grades = new List<decimal>();
        public List<string> FullNames= new List<string>();
        private static string FullName;
        private object fullNamefile = $"{FullName}_grades.txt";
        int index;
        
        public Action<object, EventArgs> GradeAdded { get; internal set; }

        public StudentInFile(string fullName) : base(fullName)
        {
            string fullNamefile = ($"{base.FullName}_{fileName}");
        }

        
        public override void AddGrade(decimal grade)
        {
            using (var writer1 = File.AppendText($"{fullNamefile}"))
            using (var writer = File.AppendText(fileName))
            {
               // using (var writer1 = File.AppendText($"{fullNamefile}"))
                using (var writer2 = File.AppendText($"audit.txt"))
                {
                    writer.WriteLine(grade);
                    writer1.WriteLine($"{FullName} : {grade}");
                    
                    writer2.WriteLine($"{fileName} : {grade}        {DateTime.UtcNow}");
                    if (grade < 3)
                    {
                        CheckEventGradeUnder3();
                    }
                }
            }
        }

        private void CheckEventGradeUnder3()
        {
            Console.WriteLine("This is a bad grade - the parents of student  should be informed!!! ");

        }
       
        public override void AddGrade(char grade)
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
            StringBuilder sb = new StringBuilder($"this.FullName  grades are: ");

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
            var statistics = this.CountStatistics(gradesFromFile);
            return statistics;

        }

        private List<decimal> ReadGradesFromFile()
        {
            var grades = new List<decimal>();
            if (File.Exists($"{fileName}"))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = decimal.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }

        private Statistics CountStatistics(List<decimal> grades)
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;

        }
    }
}
