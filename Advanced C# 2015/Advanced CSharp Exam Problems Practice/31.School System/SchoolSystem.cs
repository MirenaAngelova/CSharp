using System;
using System.Collections.Generic;
using System.Linq;
class SchoolSystem
{
    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());

        //SortedDictionary<string, SortedDictionary<string, List<double>>> students =
        //    new SortedDictionary<string, SortedDictionary<string, List<double>>>();

        //for (int i = 0; i < n; i++)
        //{
        //    string input = Console.ReadLine();
        //    var inputLine = input.Split(' ');

        //    string firstName = inputLine[0];
        //    string lastName = inputLine[1];
        //    string subject = inputLine[2];
        //    double score = double.Parse(inputLine[3]);

        //    string fullName = firstName + " " + lastName;

        //    if (students.ContainsKey(fullName))
        //    {
        //        if (students[fullName].ContainsKey(subject))
        //        {
        //            students[fullName][subject].Add(score);
        //        }
        //        else
        //        {
        //            List<double> scores = new List<double>();
        //            scores.Add(score);
        //            students[fullName].Add(subject, scores);
        //        }
        //    }
        //    else
        //    {
        //        List<double> scores = new List<double>();
        //        scores.Add(score);

        //        SortedDictionary<string, List<double>> subjects = new SortedDictionary<string, List<double>>();
        //        subjects.Add(subject, scores);

        //        students.Add(fullName, subjects);
        //    }
        //}

        //foreach (var student in students)
        //{
        //    var outputData = student.Value.Select(x => x.Key + " " + "-" + " " + x.Value.Average().ToString("0.00"))
        //        .Aggregate((x, y) => x + ", " + y);

        //    Console.WriteLine("{0}: [{1}]", student.Key, outputData);
        //}

        //Ivan Ivanov history 5
        //Ivan Ivanov math 3
        //Ivan Ivanov math 4
        //Peter Petrov physics 2
        int n = int.Parse(Console.ReadLine());
        SortedDictionary<string, SortedDictionary<string, List<double>>> students =
            new SortedDictionary<string, SortedDictionary<string, List<double>>>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string student = input[0] + " " + input[1];
            string subject = input[2];
            double score = double.Parse(input[3]);

            if (!students.ContainsKey(student))
            {
                students.Add(student, new SortedDictionary<string, List<double>>());
            }

            if (!students[student].ContainsKey(subject))
            {
                students[student].Add(subject, new List<double>());
            }

            students[student][subject].Add(score);
        }

        foreach (var student in students)
        {
            Console.Write($"{student.Key}: [");
            int count = 0;
            foreach (var subject in student.Value)
            {
                count++;
                Console.Write($"{subject.Key} - {subject.Value.Average():F2}");
                if (student.Value.Count != count)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
        //Ivan Ivanov: [history – 5.00, math – 3.50]
        //Peter Petrov: [physics – 2.00]
    }
}

