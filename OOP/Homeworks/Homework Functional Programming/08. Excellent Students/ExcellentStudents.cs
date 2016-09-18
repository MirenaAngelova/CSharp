using Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExcellentStudents
{
   // Print all students that have at least one mark Excellent (6).
   //Using LINQ first select them into a new anonymous class that holds { FullName + Marks}.
    static void Main(string[] args)
    {
        var students = new List<Student>
            {
                new Student("Richard", "Edwards", 19, 126414, "+359 2 77 777 888", "agibson2@house.gov",
                    new List<int> {5, 2, 5, 4}, 2),
                new Student("Margaret", "Peterson", 32, 133513, "0885 777 666", "petpet@abv.bg",
                    new List<int> {6, 6, 6, 6}, 3),
                new Student("Jonathan", "Gibson", 38, 163613, "0868 902 456", "ananaa@abv.bg",
                    new List<int> {6, 6, 6, 4}, 2),
                new Student("Daniel", "Ferguson", 38, 143714, "+359 0888 345 789", "ivan@abv.bg",
                    new List<int> {6, 6, 5, 4}, 1),
                new Student("Jane", "Romero", 22, 163813, "0888 999 788", "email@qpp.com", new List<int> {5, 2, 2, 5}, 2),
                new Student("Billy", "Castillo", 22, 153913, "02 234 567 789", "etaka@qpp.com", new List<int> {5, 2, 5,},
                    2)
            };
        var excellentStudents = students
            .Select(s => new { FullName = s.FirstName + " " + s.LastName, Marks = s.Marks })
            .Where(s => s.Marks.IndexOf(6) >= 0);
        foreach (var student in excellentStudents)
        {
            Console.WriteLine("{0} {1}", student.FullName, string.Join(" ", student.Marks));
        }
    }
}

