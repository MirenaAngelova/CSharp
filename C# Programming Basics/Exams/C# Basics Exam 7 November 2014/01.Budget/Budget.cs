using System;
class Budget
{
    static void Main()
    {
        //Kiro is a grown up now. He’s working and he has a certain amount of money available to last the month. 
        //He wants to know if that’s possible. Kiro spends 10lv every weekday when he’s not going out. 
        //He goes out p weekdays in the month. When he goes out he spends 3% of his total budget 
        //(rounded down to the nearest integer. Example: 3% of 608 = 18.24 rounded down to 18) in addition 
        //to his normal daily expense of 10lv. On weekends Kiro spends 20lv per day when he’s not going to his hometown. 
        //Kiro goes to his hometown h weekends per month. When he’s at his hometown he doesn’t spend anything 
        //because he stays with his parents. On top of everything Kiro pays 150lv per month for rent. 
        //We assume that each month has 30 days and 4 weekends.
        //Your task is to write a program that calculates if Kiro can last the month.
        //Input
        //The input data should be read from the console. It consists of three input values, each at separate line:
        //•	The number n – amount of money Kiro has to last the month.
        //•	The number p – number of weekdays Kiro goes out per month.
        //•	The number h – number of weekends that Kiro spends in his hometown.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data must be printed on the console.
        //•	On the only output line you must print “Yes, leftover {0}.” if Kiro has enough to last the month, 
        //or ”No, not enough {0}.” if he can’t.
        //•	Print “Exact Budget.” if Kiro has just enough.
        //Constraints
        //•	The number n is an integer in range [0... 2,147,483,647].
        //•	The number p is an integer in range [0…22] and h is an integer in range [0…4]. 
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	    Output	                    Comments
        //800   	Yes, leftover 110.          30 days total in the month, split into:
        //10                                    •	2 hometown weekends  No expenses
        //2	                                    •	2 normal weekends  4 normal weekend days  80lv expense
        //                                      •	22 weekdays split into 10 going out and 12 normal
        //                                      •	10 weekdays going out 10 * ((3% of 800=24) + 10lv) = 340lv 
        //                                      •	12 normal weekdays times 10lv expense = 120lv 
        //                                      + 150lv rent = Total 690lv
        //
        //Input	Output	                Input	Output		        Input	Output
        //600   No, not enough 40.		608     Exact Budget.		700     Yes, leftover 65.
        //15                            11                          5
        //4	                            3                           0		
       
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        double total = (2.0 * h) * 0.0 + (4.0 - h) * 2.0 * 20.0 + ((30.0 - (4.0 * 2.0)) - p) * 10.0 +
                    p * ((int)((3.0 / 100.0) * n) + 10.0) + 150.0;
        //Console.WriteLine(total);
        if ((n - total) > 0)
        {
            Console.WriteLine("Yes, leftover {0}.", Math.Abs(n - total)); 
        }
        else if ((n - total) < 0)
        {
            Console.WriteLine("No, not enough {0}.", Math.Abs(n - total));
        }
        else 
        {
            Console.WriteLine("Exact Budget.");
        }

        //int totalBudget = int.Parse(Console.ReadLine());
        //int daysGoesOut = int.Parse(Console.ReadLine());
        //int weekendsHome = int.Parse(Console.ReadLine());
        //long expense = (4 - weekendsHome) * 2 * 20 + ((30 - (4 * 2)) - daysGoesOut) * 10 +
        //            daysGoesOut * (10 + (int)(0.03 * totalBudget)) + 150;
        //if (totalBudget - expense < 0)
        //{
        //    Console.WriteLine("No, not enough {0}.", Math.Abs(totalBudget - expense));
        //}
        //else if (totalBudget == expense)
        //{
        //    Console.WriteLine("Exact Budget.");
        //}
        //else
        //{
        //    Console.WriteLine("Yes, leftover {0}.", Math.Abs(totalBudget - expense));
        //}
    }
}

