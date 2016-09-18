using System;
using System.Linq;

namespace _04.Software_University_Learning_System
{
    public class Student : Person
    {
        private string studentNumber;
        private double averageGrade;
        public string StudentNumber {
            get { return this.studentNumber; }
            set
            {
                if (value.Length != 9 || value.Any(digit => !Char.IsDigit(digit))) 
                {
                    throw new ArgumentException("Student number must contain only digits and have an exact length of 9.");
                }
                this.studentNumber = value;
            }
        }
        public double AverageGrade {
            get { return this.averageGrade; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Average grade cannot be negative.");
                }
                this.averageGrade = value;
            }
        }
        public Student(string firstName, string lastName, int age, string studentNumber, double averageGrade)
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }
    }
}
