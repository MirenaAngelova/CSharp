using System;
class Tables
{
    static void Main()
    {
        //Gosho is very good table maker. He has 4 bundles full of table legs. Every bundle holds packets. 
        //The first bundle holds packets with 1 leg, the second bundle holds packets with 2 legs 
        //and the other 2 bundles hold packets with 3 and 4 legs respectively. 
        //Example: (bundle3 = 5 packets * 3 legs = 15 legs). He also has T amount of table tops and 
        //N amount of tables that need to be made. Your task is to calculate how many tables can Goshko make 
        //and whether he has made more, less or equal amount of the needed tables. 
        //Every table is made from 4 legs and 1 table top.  Check the examples below to understand your task better.
        //Input
        //The input data should be read from the console.
        //•	At the first four lines you will be given integer numbers  representing how many packets each bundle has
        //•	At the fifth line an integer number T specifying the amount of table tops.
        //•	At the sixth line an integer number N specifying the amount of tables to be made.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It should consist of 1 or 2 lines:
        //•	Print “more: {0}” on the first line, if the tables made are more than the tables needed.
        //o	Print the materials left on the second line: “table tops left: {0}, legs left: {1}”
        //•	Print “less: {0} “, if the tables made are less than the tables needed. 
        //o	Print the materials needed  to create all needed tables: “tops needed: {0}, legs needed {1}”
        //•	Print “Just enough tables made: {0}”, if the tables made are equal with the tables needed.
        //Constraints
        //•	The inputs will be an integers in the range [0…999 999 999].
        //•	Allowed working time for your program: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output	                            Comments
        //1     less: -1                            Bundle1+Bundle2+Bundle3+Bundle4 = (1*1) + (1*2) + (1*3) + (2*4) = 14 legs,
        //1     tops needed: 1, legs needed: 0      2 table tops and 3 tables to be made.
        //1                                         To make 3 tables Gosho needs 12 legs and 3 table tops.
        //2                                         He can’t make enough tables. He has enough legs but needs 1 more table top.
        //2
        //3	
        //Input	Output		                    Input	Output
        //2     more: 2                         1       Just enough tables made: 1
        //3     tops left: 2, legs left: 8      1
        //4                                     1   
        //5                                     1
        //10                                    1
        //8	                                    1	

        long first = long.Parse(Console.ReadLine());
        long second = long.Parse(Console.ReadLine());
        long third = long.Parse(Console.ReadLine());
        long fourth = long.Parse(Console.ReadLine());
        long tops = long.Parse(Console.ReadLine());
        long needed = long.Parse(Console.ReadLine());

        long legs = first * 1 + second * 2 + third * 3 + fourth * 4;
        long made = Math.Min(tops, legs / 4);

        if (made > needed)
        {
            long moreTops = tops - needed;
            long moreLegs = legs - needed * 4;
            Console.WriteLine("more: {0}", made - needed);
            Console.WriteLine("tops left: {0}, legs left: {1}", moreTops, moreLegs);

        }
        else if (needed > made)
        {
            long lessTops = needed >= tops ? needed - tops : 0;
            long lessLegs = needed * 4 >= legs ? needed * 4 - legs : 0;
            Console.WriteLine("less: {0}", made - needed);
            Console.WriteLine("tops needed: {0}, legs needed: {1}", lessTops, lessLegs);
        }
        else
        {
            Console.WriteLine("Just enough tables made: {0}", made);
        }




        //long sumLegs = 0;
        //for (int i = 1; i <= 4; i++)
        //{
        //    long packets = long.Parse(Console.ReadLine());
        //    sumLegs += packets * i;
        //}
        //long legs = sumLegs / 4;
        //long tops = long.Parse(Console.ReadLine());
        //long neededTables = long.Parse(Console.ReadLine());
        //long topLegs = tops <= legs ? tops : legs;
        //if (topLegs > neededTables)
        //{
        //    Console.WriteLine("more: {0}", topLegs - neededTables);
        //    Console.WriteLine("tops left: {0}, legs left: {1}", tops - neededTables, sumLegs - neededTables * 4);
        //}
        //else if (topLegs == neededTables)
        //{
        //    Console.WriteLine("Just enough tables made: {0}", neededTables);
        //}
        //else
        //{
        //    Console.WriteLine("less: {0}", topLegs - neededTables);
        //    Console.WriteLine("tops needed: {0}, legs needed: {1}", neededTables - tops,
        //        (neededTables * 4 - sumLegs) <= 0 ? 0 : (neededTables * 4 - sumLegs));
        //}
    }
}





