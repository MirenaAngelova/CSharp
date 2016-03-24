using System;
class DifferenceBetweenDates
{
    static void Main()
    {
        //Write a program that enters two dates in format dd.MM.yyyy and returns the number of days between them. 
        //Examples:
        //First date    Days between
        //Second date	
        //17.03.2014    44
        //30.04.2014
	    //
        //17.03.2014    0
        //17.03.2014
	    //
        //14.06.1980    12317
        //5.03.2014	
        //
        //5.03.2014     -2
        //3.03.2014	

        //DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", null);
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        DateTime secondDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine((secondDate - firstDate).TotalDays);
    }
}

