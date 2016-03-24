using System;
class PrimeNumberCheck
{
    static void Main()
    {
        //Write an expression that checks if given positive integer number n (n ≤ 100) is prime 
        //(i.e. it is divisible without remainder only to itself and 1). Examples:
        //n	    Prime?
        //1	    false
        //2	    true
        //3	    true
        //4	    false
        //9	    false
        //97	true
        //51	false
        //-3	false
        //0	    false

        int positiveNum = int.Parse(Console.ReadLine());
        bool isPrime = true;
        if (positiveNum < 2 || positiveNum > 100)
        {
            Console.WriteLine(!isPrime);
            return;
        }
        for (int i = 2; i <= Math.Sqrt(positiveNum); i++)
        {
            if (positiveNum % i == 0)
            {
                Console.WriteLine(!isPrime);
                return;
            }

        }
        Console.WriteLine(isPrime);
    }
}

