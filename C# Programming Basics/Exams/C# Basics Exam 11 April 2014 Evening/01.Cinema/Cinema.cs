using System;
class Cinema
{
    static void Main()
    {
        //Most people like going to the cinema. If you are such person, help the cinema director Kircho solve his 
        //financial task.
        //Kircho is trying to calculate how much his incomes are for a single projection, if the movie hall is completely full. 
        //He knows the type of projection (and how much a ticket for each type costs), the number of rows and the number 
        //of columns in the hall (the cimena hall is rectangular).
        //There are three types of movies projected in Kircho’s cinema:
        //•	Premiere projection – 12.00 leva
        //•	Normal projection – 7.50 leva
        //•	Discount projection for kids, students and retirees – 5.00 leva
        //Your task is to calculate the incomes Kircho gets for a single projection full of people. You need to calculate 
        //how many people are watching the movie depending on the rows and columns in the hall and find the incomes in levas 
        //depending on the type of projection.
        //Input
        //•	The input data is read from the console. 
        //•	A string representing the type of projection stays at the first input line. It can be one of the following: 
        //“Premiere”, “Normal”, “Discount” (without the quotes).
        //•	The number of rows stays at the second input line.
        //•	The number of columns stays at the third input line.
        //•	The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data must be printed on the console.
        //•	On the only output line you must print the incomes with two digits after the decimal point with “leva” appended
        //at the end (see the example tests). Use "." as decimal separator.
        //Constraints
        //•	The rows and columns are numbers between 1 and 100, inclusively.
        //•	Time limit: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	        Output		        Input	    Output
        //Premiere      1440.00 leva		Normal      2047.50 leva
        //10                                21
        //12                                13	
        //
        //	

        string typeOfprojection = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());
        int tickets = rows * columns;
        double incomes = 0;


        switch (typeOfprojection)
        {
            case "Premiere":
                incomes = tickets * 12.00;
                break;
            case "Normal":
                incomes = tickets * 7.50;
                break;
            case "Discount":
                incomes = tickets * 5.00;
                break;
        }
        Console.WriteLine("{0:f2} leva", incomes);



        //if (typeOfprojection == "Premiere")
        //{
        //    incomes = tickets * 12.00;
        //    Console.WriteLine("{0:f2} leva", incomes);
        //}
        //else if(typeOfprojection == "Normal")
        //{
        //    incomes = tickets * 7.50;
        //    Console.WriteLine("{0:f2} leva", incomes);
        //}
        //else
        //{
        //    incomes = tickets * 5.00;
        //    Console.WriteLine("{0:f2} leva", incomes);
        //}
    }
}

