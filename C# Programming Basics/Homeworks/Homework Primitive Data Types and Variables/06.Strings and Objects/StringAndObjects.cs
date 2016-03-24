using System;

class StringAndObjects
{
    static void Main()
    {
        //Declare two string variables and assign them with “Hello” and “World”. 
        //Declare an object variable and assign it with the concatenation 
        //of the first two variables (mind adding an interval between).
        //Declare a third string variable and initialize it with the value 
        //of the object variable (you should perform type casting).

        string first = "Hello";
        string second = "World";
        object concatenation = first + " " + second + "!";
        Console.WriteLine(concatenation);
    }
}

