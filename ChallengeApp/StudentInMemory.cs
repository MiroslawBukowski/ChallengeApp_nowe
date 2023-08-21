namespace ChallengeApp
{
    public class StudentInMemory : StudentBase
    {
        public StudentInMemory(string fullname) : base(fullname)
        {
        }
        public List<decimal> grades = new List<decimal>();

        public Action<object, EventArgs> GradeAdded { get; internal set; }

        public override void AddGrade(char grade)
        {
            this.grades.Add(grade);
        }

        public override void AddGrade(decimal grade)
        {
            this.grades.Add(grade);
            if (grade < 3)
            {
                CheckEventGradeUnder3();
            }
        }
        private void CheckEventGradeUnder3()
        {
            Console.WriteLine("This is a bad grade - the parents of student  should be informed!!! ");
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
                            if (grade < 3)
                            {
                                CheckEventGradeUnder31();
                            }
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

        private static void CheckEventGradeUnder31()
        {
            Console.WriteLine("This is a bad grade - the parents of student  should be informed!!! ");
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach(var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }
            
            return statistics;
        }

        public override void ShowGrades()
        {
            throw new NotImplementedException();
        }
    }
}
