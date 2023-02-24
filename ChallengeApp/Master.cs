using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    internal class Master : IStudent
    {
        string IStudent.FullName => throw new NotImplementedException();

        void IStudent.AddAge(int age)
        {
            throw new NotImplementedException();
        }

        void IStudent.AddGrade(string grade)
        {
            throw new NotImplementedException();
        }

        void IStudent.AddGrade(char grade)
        {
            throw new NotImplementedException();
        }

        void IStudent.AddGrade(decimal grade)
        {
            throw new NotImplementedException();
        }

        void IStudent.AddGrade(int grade)
        {
            throw new NotImplementedException();
        }

        void IStudent.ChangeGrade(string inputMark)
        {
            throw new NotImplementedException();
        }

        Statistics IStudent.GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
