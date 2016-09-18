using System;

namespace _04.Software_University_Learning_System
{
    public class Onsite : Current
    {
        private int numberOfVisits;

        public int NumberOfVisits
        {
            get { return this.numberOfVisits; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of visits cannot be negative.");
                }
                this.numberOfVisits = value;
            }
        }

        public Onsite(string firstName, string lastName, int age, string studentNumber, double averageGraduate,
            string currentCourse, int numberOfVisits) :
            base(firstName, lastName, age, studentNumber, averageGraduate, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }
    }
}
