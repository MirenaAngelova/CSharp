using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Human__Student_and_Worker
{
    class HumanStudentAndWorker
    {
        static void Main()
        {
            var students = new List<Student>()
            {
                new Student("Ceco", "Cacov", "234abcd"),
                new Student("Asen", "Asenov", "1234ab"),
                new Student("Bobi", "Bobev", "12345a"),
                new Student("Bubi", "Bubev", "123456"),
                new Student("Dido", "Dudev", "23456ab"),
                new Student("Dani", "Danev", "2345abc"),
                new Student("Dan", "Kolov", "123abcd"),
                new Student("Dinko", "Dinev", "234567a"),
                new Student("Emil", "Emilov", "2345678"),
                new Student("Angel", "Angelov", "123abc"),
            };

            var workers = new List<Worker>()
            {
                new Worker("Filip", "Filipov", 400, 5),
                new Worker("Georgi", "Georgiev", 420, 6),
                new Worker("Vili", "Velikov", 700, 8),
                new Worker("Vani", "Vankov", 650, 9),
                new Worker("Vlado", "Vladov", 735, 7),
                new Worker("Ali", "Baba", 705, 12),
                new Worker("Petar", "Petrov", 845, 11),
                new Worker("Kiro", "Kirov", 666, 6),
                new Worker("Nani", "Nanev", 975, 10),
                new Worker("Pisna", "Mi", 787, 8),
            };

            var sortedStudents = students.OrderBy(s => s.FacultyNum)
                .Select(s => new {FirstName = s.FirstName, LastName = s.LastName, FacultyNum = s.FacultyNum});
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
                
            }
            Console.WriteLine();

            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour())
                .Select(w => new
                {
                    FirstName = w.FirstName,
                    LastName = w.LastName,
                    MoneyPerHour = w.MoneyPerHour()
                });
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine();

            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);

            var sortedHumans = humans.OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName)
                .Select(h => new {FirstName = h.FirstName, LastName = h.LastName});

            foreach (var human in sortedHumans)
            {
                Console.WriteLine(human);
            }
        }
    }
}
