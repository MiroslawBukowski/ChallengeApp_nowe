namespace ChallengeApp
{
    public class Statistics
    {
        public decimal Min { get; private set; }
        public decimal Max { get; private set; }
        public decimal Sum { get; private set; }
        public int Count { get; private set; }
        public decimal Average 
        { get
            {
                return this.Sum / this.Count;
            }
        }
        public char AverageLetter 
        { get
            {
                switch (this.Average)
                {
                    case var average when average >= 5:
                        return 'A';

                    case var average when average >= 4:
                        return 'B';

                    case var average when average >= 3:
                        return 'C';

                    case var average when average >= 2:
                        return 'D';

                    case var average when average >= 1:
                        return 'E';

                    default:
                        throw new Exception(" Wrong letter");
                }
            }
        }
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = decimal.MinValue;
            this.Min = decimal.MaxValue;
        }
        public void AddGrade(decimal grade) 
        {
            this.Count++;
            this.Sum += grade;
            this.Min = Math.Min(grade, this.Min);
            this.Max = Math.Max(grade, this.Max);


        }
    }

    //public  Statistics CountStatistics(List<decimal> gradesFromFile)
    //{
    //    var statistics = new Statistics();
    //    this.Average = 0;
    //    this.Max = decimal.MinValue;
    //    this.Min = decimal.MaxValue;

    //    foreach (var grade in this.gradesFromFile)
    //    {
    //        if (grade >= 0)
    //        {
    //            this.Max = Math.Max(this.Max, grade);
    //            this.Min = Math.Min(this.Min, grade);
    //            this.Average += grade;
    //        }
    //    }
    //    this.Average /= gradesFromFile.Count;
    //    switch (this.Average)
    //    {
    //        case var average when average >= 5:
    //            return 'A';
                
    //        case var average when average >= 4:
    //            statistics.AverageLetter = 'B';
    //            break;
    //        case var average when average >= 3:
    //            statistics.AverageLetter = 'C';
    //            break;
    //        case var average when average >= 2:
    //            statistics.AverageLetter = 'D';
    //            break;
    //        case var average when average >= 1:
    //            statistics.AverageLetter = 'E';
    //            break;
    //        default:
    //            throw new Exception(" Wrong letter");
    //    }
    //}
}
