using System;

class QuotesInString
{
    static void Main()
    {
       // Declare two string variables and assign them with following value:
       //The "use" of quotations causes difficulties.
       //Do the above in two different ways: with and without using quoted strings. 
       //Print the variables to ensure that their value was correctly defined.
       //Expected Output
       // The "use" of quotations causes difficulties.
       //The "use" of quotations causes difficulties.

        Console.WriteLine("The \"use\" quotations causes difficulties.");
        Console.WriteLine(@"The ""use"" of quotations causes difficulties.");
    }
}

