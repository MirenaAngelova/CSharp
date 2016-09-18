using System;

namespace _04.Software_University_Learning_System
{
    public class Senior : Trainer
    {
        public Senior(string firstName, string lastName, int age) :
            base(firstName, lastName, age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public static void DeleteCourse(string courseName)
        {
            Console.WriteLine("Course {0} has been deleted.", courseName);
        }
    }
}
