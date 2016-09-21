using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class PinValidation
{
    public static void Main()
    {
        //const string NamePattern = @"^[A-Z][a-z]+ [A-Z][a-z]+$";
        //const string PinPattern = @"^\d{10}$";

        //int[] checksumMultipliers = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        //string name = Console.ReadLine();
        //string gender = Console.ReadLine();
        //string pin = Console.ReadLine();

        //if (!Regex.IsMatch(name, NamePattern))
        //{
        //    Console.WriteLine("<h2>Incorrect data</h2>");
        //    return;
        //}

        //if (gender != "male" && gender != "female")
        //{
        //    Console.WriteLine("<h2>Incorrect data</h2>");
        //    return;
        //}

        //if (!Regex.IsMatch(pin, PinPattern))
        //{
        //    Console.WriteLine("<h2>Incorrect data</h2>");
        //    return;
        //}

        //int year = int.Parse(pin.Substring(0, 2));
        //int month = int.Parse(pin.Substring(2, 2));
        //int day = int.Parse(pin.Substring(4, 2));

        //int genderNum = pin[8] - '0';

        //if (21 <= month && month <= 32)
        //{
        //    year += 1800;
        //    month -= 20;
        //}
        //else if (41 <= month && month < 52)
        //{
        //    year += 2000;
        //    month -= 40;
        //}
        //else if (1 <= month && month <= 12)
        //{
        //    year += 1900;
        //}
        //else
        //{
        //    Console.WriteLine("<h2>Incorrect data</h2>");
        //    return;
        //}

        //try
        //{
        //    new DateTime(year, month, day);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("<h2>Incorrect data</h2>");
        //    return;
        //}

        //if (gender == "male" && genderNum % 2 != 0)
        //{
        //    Console.WriteLine("<h2>Incorrect data</h2>");
        //    return;
        //}

        //if (gender == "female" && genderNum % 2 == 0)
        //{
        //    Console.WriteLine("<h2>Incorrect data</h2>");
        //    return;
        //}

        //int checksum = 0;

        //for (int i = 0; i < 9; i++)
        //{
        //    checksum += checksumMultipliers[i] * (pin[i] - '0');
        //}

        //int hash = checksum % 11;

        //if (hash == 10)
        //{
        //    hash = 0;
        //}

        //if (hash != pin[9] - '0')
        //{
        //    Console.WriteLine("<h2>Incorrect data</h2>");
        //    return;
        //}

        //Console.WriteLine(
        //    "{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}",
        //    name,
        //    gender,
        //    pin);

        //Ana Ivanova
        //female
        //9912164756
        List<int> numbers = new List<int>() { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        string[] name = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (name.Length < 2)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        char first = name[0].ToCharArray().First();
        char last = name[1].ToCharArray().First();
        if (!char.IsUpper(first) || !char.IsUpper(last))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        string firstName = name[0];
        string lastName = name[1];

        string gender = Console.ReadLine();

        int[] pin = Console.ReadLine().Select(p => int.Parse(p.ToString())).ToArray();
        //99121647 5 6
        int year = pin[0] * 10 + pin[1];
        int month = pin[2] * 10 + pin[3];
        int day = pin[4] * 10 + pin[5];

        if (21 <= month && month <= 32)
        {
            year += 1800;
            month -= 20;
        }
        else if (41 <= month && month < 52)
        {
            year += 2000;
            month -= 40;
        }
        else if (1 <= month && month <= 12)
        {
            year += 1900;
        }
        else
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        try
        {
            new DateTime(year, month, day);
        }
        catch (Exception ex)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        if (pin[8] % 2 == 0 && gender != "male")
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        if (pin[8] % 2 == 1 && gender != "female")
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        int sum = 0;
        for (int i = 0; i < pin.Length - 1; i++)
        {
            sum += pin[i] * numbers[i];

        }
        int checkSum = sum % 11;
        int check = checkSum == 10 ? 0 : checkSum;

        if (check != pin[9])
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        Console.WriteLine(
            $"{{\"name\":\"{firstName} {lastName}\",\"gender\":\"{gender}\",\"pin\":\"{string.Join("", pin)}\"}}");
    }
}