using System;

class NullValuesArithmetic
{
    static void Main()
    {
        //Create a program that assigns null values to an integer and to a double variable. 
        //Try to print these variables at the console. Try to add some number or the null literal 
        //to these variables and print the result.
        Nullable<int> i1 = null;
        int? i2 = i1;
        Console.WriteLine(i2);

        Nullable<double> j1 = null;
        double? j2 = j1;
        Console.WriteLine(j2);

        Console.WriteLine(i2 + 5);
        Console.WriteLine(j2 + null);
    }
}

