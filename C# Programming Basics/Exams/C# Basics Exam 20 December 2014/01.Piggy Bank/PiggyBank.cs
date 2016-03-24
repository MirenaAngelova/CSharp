using System;
class PiggyBank
{
    static void Main()
    {
        //Anastas wants to buy himself a tank to drive around the streets of Sofia 
        //(he’s a fan of the classic game Carmageddon). He’s saving up and he needs your help to keep track of his progress.
        //Every day in a given month he saves up 2 leva and puts them in his piggy bank. 
        //Unless there is a party that day – he needs 5 leva to buy vodka on a party day, 
        //so he takes them out of the piggy bank.
        //You will be given the tank’s price and the number of party days in a month, each on a separate line. 
        //Assume each month has 30 days and each year has 12 months. Calculate how many years and months Anastas 
        //will need in order to save enough to buy his very own tank and print the result on the console 
        //in the format “X years, Y months”. In case he isn’t saving up at all and is wasting money on cheap alcohol instead, 
        //print “never”.
        //Note that if, for example, Anastas needs 3.1 months, you need to round that up – so you have to print 
        //“0 years 4 months”. The years and months should be integer numbers. 
        //Check out the examples to understand your task better. 
        //Input
        //The input will be read from the console. The input consists of exactly two lines:
        //•	On the first line you will be given an integer – the price of the tank.
        //•	On the second line you will be given the number of party days in a month.
        //The input will always be valid and in the format described, there is no need to check it explicitly.
        //Output
        //The output should be printed on the console.
        //•	On the only output line print the number of years and months Anastas will need to save enough money 
        //in the format “X years, Y months”, or print “never” in case he’s actually wasting money each month.
        //Constraints
        //•	The price of the tank will be an integer in the range [1 … 2 000 000 000].
        //•	The number of party days will be an integer in the range [0 … 30].
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	    Output	            Comments
        //200000    666 years 8 months	There are 30 days in a month => 5 party days and 25 normal days.
        //5	                            On a normal day he saves 2 leva => 25*2 = 50 leva. 
        //                              On a party day he spends 5 leva => 5*5 = 25. 
        //                              On average, he saves 50 – 25 = 25 leva per month.
        //                              200000/25 = 8000 – he needs exactly 8000 months. 
        //                              This is 666 years and 8 months, or 666.(6) years to be exact).
        //                              Not gonna happen in our lifetime, thankfully!
        //
        //Input	    Output
        //12345     never
        //10	

        //Input	    Output
        //24300000  33750 years, 0 months
        //0	        

        //Input	    Output
        //200       4 years, 2 months
        //8	        

        //Input	    Output
        //15999    34  years, 3 months
        //3	      

        int t = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        double saved = (30.0 - p) * 2.0 - p * 5.0;
        int month =(int)Math.Ceiling(t / saved);
        int years = month / 12;
        int totalMonths = month % 12; 
        if (saved < 0)
        {
            Console.WriteLine("never");
        }
        else
        {
            Console.WriteLine("{0} years, {1} months", years, totalMonths);
        }
    }
}

