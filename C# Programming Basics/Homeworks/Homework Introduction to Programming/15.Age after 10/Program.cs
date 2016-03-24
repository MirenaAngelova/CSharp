using System;
class AgeAfterTen
{
    static void Main()
    {
        //Write a program to read your birthday from the console and print
        //how old you are now and how old you will be after 10 years.

        Console.WriteLine("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        DateTime ageNow = new DateTime(age, 11, 23);
        ageNow = ageNow.AddYears(10);
        Console.WriteLine(ageNow.Year);

        //string text = Console.ReadLine();
        //int age = int.Parse(text);
        //Console.WriteLine("Your age after ten years will be {0}!", age + 10);

    }
}

