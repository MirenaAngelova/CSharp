using System;
class DivBySevenAndFive
{
    static void Main()
    {
        //Write a Boolean expression that checks for given integer if it can be divided (without remainder) 
        //by 7 and 5 in the same time. Examples:
        //n	    Divided by 7 and 5?
        //3	    false
        //0	    false
        //5	    false
        //7	    false
        //35	true
        //140	true

        //int integerNum = int.Parse(Console.ReadLine());
        //bool isDiv7 = integerNum % 7 == 0;
        //bool isDiv5 = integerNum % 5 == 0;
        //if (integerNum == 0)
        //{
        //    isDiv7 = false;
        //}
        //Console.WriteLine(isDiv7 & isDiv5);


        int integerNum = int.Parse(Console.ReadLine());
        bool isDivide = integerNum % 35 == 0;
        if (integerNum == 0)
        {
            isDivide = false; //without else, because of  the zero
        }
        Console.WriteLine(isDivide);
    }
}

