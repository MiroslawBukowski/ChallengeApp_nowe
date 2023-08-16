using System;
using System.Collections.Generic;
namespace ChallengeApp
{
    public interface IStudent
    {
        string GetFullName();
        void AddAge(int age);

        void AddGrade(string grade);

        void AddGrade(char grade); 

        void AddGrade(decimal grade);

        void AddGrade(int grade);

        //void ChangeGrade(string inputMark);

        Statistics GetStatistics();
        public abstract Statistics CountStatistics();
        Statistics CountStatistics(List<decimal> grades);
    }
}
