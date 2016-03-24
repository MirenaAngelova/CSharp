using System;
class QuadraticEquation
{
    static void Main()
    {
        //Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 
        //and solves it (prints its real roots). Examples:
        //a	    b	c	 roots
        //2	    5	-3	 x1=-3; x2=0.5
        //-1	3	0	 x1=3; x2=0
        //-0.5	4	-8	 x1=x2=4
        //5	    2	8	 no real roots

        Console.WriteLine("Enter the cofficient a: ");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the cofficient b: ");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the cofficient c: ");
        double c = double.Parse(Console.ReadLine());
        double dDiscriminant = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);

        if (dDiscriminant > 0)
        {
            Console.WriteLine("The quadratic polynomial has two distinct real roots:" +
                        "\nx1={0}; x2={1}", (-b - dDiscriminant) / (2 * a), (-b + dDiscriminant) / (2 * a));
        }
        else if (dDiscriminant == 0)
        {
            Console.WriteLine("The quadratic polynomial has two coincident real roots:" +
                        "\nx1=x2={0}", -b / (2 * a));
        }
        else
        {
            Console.WriteLine("The quadratic polynomial has no real roots.");
        }
    }
}

