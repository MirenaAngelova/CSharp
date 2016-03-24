using System;
class PlayWithInDoubleAndString
{
    static void Main()
    {
        //Write a program that, depending on the user’s choice, inputs an int, double or string variable. 
        //If the variable is int or double, the program increases it by one. If the variable is a string, 
        //the program appends "*" at the end. Print the result at the console. Use switch statement. Example:
        //program	                user		program	                user
        //Please choose a type:      3	        Please choose a type:   2
        //1 --> int                             1 --> int
        //2 --> double                          2 --> double
        //3 --> string	           	            3 --> string	
        //
        //Please enter a string:	hello       Please enter a double:	1.5
        //hello*                                2.5	
        //		
        //			

        Console.WriteLine("Please choose a type: \n1 --> int\n2 --> double\n3 --> string");
        ConsoleKeyInfo k = Console.ReadKey();
        Console.WriteLine();
        if (k.KeyChar == '1')
        {
            Console.WriteLine("Please enter an integer: ");
            int iVariable = int.Parse(Console.ReadLine());
            Console.WriteLine(iVariable + 1);
        }
        if (k.KeyChar == '2')
        {
            Console.WriteLine("Please enter a double: ");
            double dVariable = double.Parse(Console.ReadLine());
            Console.WriteLine(dVariable + 1);
        }
        if (k.KeyChar == '3')
        {
            Console.WriteLine("Please enter a string: ");
            string sVariable = Console.ReadLine();
            Console.WriteLine(sVariable + "*");
        }
    }
}

