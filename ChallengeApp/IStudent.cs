using System;
using System.Collections.Generic;
namespace ChallengeApp
{
    public interface IStudent
    {
        string FullName { get; }

        void AddAge(int age);

        void AddGrade(string grade);

        void AddGrade(char grade); 

        void AddGrade(decimal grade);

        void AddGrade(int grade);

        void ChangeGrade(string inputMark);

        Statistics GetStatistics();


    }
}
