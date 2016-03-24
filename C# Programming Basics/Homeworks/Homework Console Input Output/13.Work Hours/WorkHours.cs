using System;
class WorkHours
{
    static void Main()
    {
        //Lelia Vanche is a very keen freelance developer. She is well known for her outstanding skills, 
        //but she is also known for being pretty moody, which often affects her productivity. 
        //She also has a passion for bicycles and 10% of the normal work days she goes mountain-biking instead of working.
        //You are asked to calculate whether Lelia Vanche can finish a project on time. You will be given 
        //the number of hours required to finish the project, the days that Lelia Vanche has available for working 
        //(mind that she goes to biking in 10% of this time) and her average productivity during the given period. 
        //Assume that a normal work day for Lelia Vanche has 12 hours. Note that only the whole hours are taken 
        //(e.g. 6.98 hours is rounded down to 6 hours).
        //Input
        //Input data should be read from the console. 
        //•	The number h (the required work hours to finish the project) is on the first input line.
        //•	The number d (the days available to finish the project) is on the second input line.
        //•	The number p (the productivity in percent) is on the third input line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data must be printed on the console.
        //•	On the first output line you should print ‘Yes’ or ‘No’ if Lelya Vanche can complete the project.
        //•	On the second output line you should print the difference, between the project hours and the work hours.
        //Constraints
        //•	The number h will be an integer between 0 and 2 147 483 647, inclusive.
        //•	The number d will be an integer between 0 and 89 478 485, inclusive.
        //•	The number p will be an integer between 0 and 100, inclusive.
        //•	Allowed working time for your program: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	  Output	Comments
        //60      No        The project requires 60 hours. Lelia Vanche has 6 days, of which 10% she will be biking, 
        //6       -12       so she will work 5.4 days * 12 hours = 64.8 hours * 75% productivity = 48.6 efficient work hours, 
        //75                which is rounded down to 48. She will be unable to complete the project. 
        //                  The difference is 60 - 48 = -12 (she needs more 12 hours).
        //Input	Output		Input	Output		Input	Output		Input	Output
        //1     Yes         240     No          10      Yes         21      No
        //1     9           10      -132        10      0		    10      -11
        //100	            100                 10                  10

        int h = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        double project = (((d - ((10.0 / 100.0) * d)) * 12.0) * (p / 100.0));
        int completeProject = (Int32)project - h;
        if (completeProject >= 0)
        {
            Console.WriteLine("Yes \n{0}", completeProject);
        }
        else
        {
            Console.WriteLine("No \n{0}", completeProject);
        }
    }
}

