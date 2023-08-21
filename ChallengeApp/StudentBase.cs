﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    public abstract class StudentBase :  IStudent
    {
        public StudentBase(string fullName)
        {
            this.SetFullName(fullName);
        }

        public string? FullName;

        public string? GetFullName()
        {
            return FullName;
        }

        private void SetFullName(string? value)
        {
            FullName = value;
        }

        public void AddAge(int age)
        {
            throw new NotImplementedException();
        }

        public abstract void AddGrade(string grade);
        

        public abstract void AddGrade(char grade);
        

        public abstract void AddGrade(decimal grade);


        public abstract void AddGrade(int grade);


        //public abstract void ChangeGrade(string inputMark);

        public abstract void ShowGrades();
        public abstract Statistics GetStatistics();
        //public abstract Statistics CountStatistics();
        //public abstract Statistics CountStatistics(List<decimal> grades);
    }
}