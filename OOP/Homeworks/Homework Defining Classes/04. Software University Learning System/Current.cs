using System;

namespace _04.Software_University_Learning_System
{
    public class Current : Student
    {
        private string currentCourse;

        public string CurrentCourse {
            get { return this.currentCourse; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Current course cannot be empty.");
                }
                this.currentCourse = value;
            }
        }

        public Current(string firstName, string lastName, int age, string studentNumber, double averageGrade, 
            string currentCourse) :
            base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        public override string ToString()
        {
            return string.Format("Student name: {0} {1}, Age: {2}, Student number: {3}, Average grade: {4}, " +
                                 "Current course: {5}",
                                 this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade,
                                 this.CurrentCourse);
        }
    }
}
