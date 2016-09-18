
using System;

namespace _04.Software_University_Learning_System
{
    public class Dropout : Student
    {
        private string dropoutReason;

        public string DropoutReason
        {
            get { return this.dropoutReason; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Dropout Reason cannot be empty.");
                }
                this.dropoutReason = value;
            }
        }

        public Dropout(string firstName, string lastName, int age, string studentNumber, double averageGrade,
            string dropoutReason) :
                base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        public void Reapply()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return string.Format("Student name: {0} {1}, Age: {2}, Student number: {3}, Average grade: {4}, " +
                                 "Dropout reason: {5}",
                                 this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade, 
                                 this.DropoutReason);
        }
    }
}
