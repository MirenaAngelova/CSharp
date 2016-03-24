using System;
class Car
{
    static void Main()
    {
        //You will be given an integer N. The width of the car is (3*N). The height of the car is (3*N/2-1).  
        //The roof height and the body height is exactly (N/2).  The car’s wheels height are (N/2-1). 
        //Check the examples below to understand your task better.
        //Input
        //•	Input data is read from the console.
        //•	The number N stays alone at the first line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data must be printed on the console.
        //•	You must print at the console a car of size N following the formulas above and the examples below.
        //Constraints
        //•	N will be a number between 6 and 36 and will be an even number.
        //•	Time limit: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	    Output		                        Input	Output
        //10	    ..........**********..........      8	    ........********........
        //          .........*..........*.........              .......*........*.......
        //          ........*............*........              ......*..........*......
        //          .......*..............*.......              .....*............*.....
        //          ......*................*......              *****..............*****
        //          ******..................******              *......................*
        //          *............................*              *......................*
        //          *............................*              ************************
        //          *............................*              ....*...*......*...*....
        //          ******************************              ....*...*......*...*....
        //          .....*....*........*....*.....              ....*****......*****....
        //          .....*....*........*....*.....
        //          .....*....*........*....*.....
        //          .....******........******.....		
        //
        //Input	Output
        //6	    ......******......
        //      .....*......*.....
        //      ....*........*....
        //      ****..........****
        //      *................*
        //      ******************
        //      ...*..*....*..*...
        //      ...****....****...

        int n = int.Parse(Console.ReadLine());
        int midPoint = 3 * (n / 2);
        int count = n / 2;
        Console.WriteLine(new string('.', n) + new string('*', n) + new string('.', n));
        for (int i = 0; i < n / 2 - 1 ; i++)
        {
            for (int j = 0; j < (n * 3); j++)
            {
                if ((j == midPoint - 1 - count) | (j == midPoint + count))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            count++;
        }
        Console.WriteLine(new string('*', n / 2 + 1) + new string('.', 2 * n - 2) + new string('*', n / 2 + 1));
        for (int i = 0; i < n / 2 - 2; i++)
        {
            Console.WriteLine("*" + new string('.', n * 3 - 2) + "*");
        }
        Console.WriteLine(new string('*', n * 3));
        for (int i = 0; i < n / 2 - 2; i++)
        {
            Console.WriteLine(new string('.', n / 2) + "*" + new string('.', n / 2 - 1) + "*" + new string('.', n - 2)
                + "*" + new string('.', n / 2 - 1) + "*" + new string('.', n / 2));
        }
        Console.WriteLine(new string('.', n / 2) + new string('*', n / 2 + 1) + new string('.', n - 2) +
            new string('*', n / 2 + 1) + new string('.', n / 2));
    }
}

//using System;

//class Cars
//{
//    static void Main()
//    {
//        int n = int.Parse(Console.ReadLine());
//        int dots = n;
//        int stars = n;
//        int dotsMiddle = stars;

//        Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('*', stars));
//        for (int i = 0; i < n / 2 - 1; i++)
//        {
//            dots--;
//            Console.WriteLine("{0}*{1}*{0}", new string('.', dots), new string('.', dotsMiddle));
//            dotsMiddle += 2;
//        }

//        Console.WriteLine("{0}{1}{0}", new string('*', dots), new string('.', n * 2 - 2));
//        for (int i = 0; i < n / 2 - 2; i++)
//        {
//            Console.WriteLine("*{0}*", new string('.', n * 3 - 2));
//        }

//        int middleDots = (n / 2 + 1) + (n - 6) / 2;
//        Console.WriteLine(new string('*', n * 3));
//        for (int i = 0; i < n / 2 - 2; i++)
//        {
//            Console.WriteLine("{0}*{1}*{2}*{1}*{0}", 
//                new string('.', n / 2), new string('.', n / 2 - 1), new string('.', middleDots));
//        }

//        Console.WriteLine("{0}{1}{2}{1}{0}", 
//            new string('.', n / 2), new string('*', n / 2 + 1), new string('.', middleDots));
//    }
//}
