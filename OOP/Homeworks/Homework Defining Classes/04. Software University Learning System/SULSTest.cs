
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Software_University_Learning_System
{
    public class SULSTest
    {
        static void Main()
        {
            List<Person> students = new List<Person>()
            {
                new Person("Ivan", "Petrov", 18),
                new Trainer("Ivan", "Ivanov", 19),
                new Senior("Ivan", "Angelov", 20),
                new Junior("Ivan", "Krumov", 21),
                new Student("Georgi", "Petrov", 22, "111111111", 22.5),
                new Current("Georgi", "Simeonov", 23, "111111116", 135.99, "OOP"),
                new Online("Georgi", "Ivanov", 23, "111111112", 23.00, "C# Advanced"),
                new Onsite("Georgi", "Angelov", 24, "111111113", 23.55, "Java Fundamentals", 9),
                new Graduate("Georgi", "Krumov", 25, "111111114", 24.00),
                new Dropout("Georgi", "Georgiev", 26, "111111115", 2.2, "C# Basic")
            };
            var result = students
                .Where(student => student is Current)
                .Cast<Current>()
                .OrderBy(student => student.AverageGrade).ToList();
            Console.WriteLine(string.Join("\n", result));
        }
    }
}
