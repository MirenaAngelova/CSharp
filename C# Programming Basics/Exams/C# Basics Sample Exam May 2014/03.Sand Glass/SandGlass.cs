using System;
class SandGlass
{
    static void Main()
    {
        //Once upon a time a powerful wizard was born. His name was Gwenogfryn and soon he became a great sorcerer. 
        //Kind-hearted he was. He would only use his magic to protect humans from the evil witches that would come at night. 
        //Gwenogfryn, however was a pacifist and did not want to fight or hurt the witches, so he came up 
        //with another solution. He would catch the witches and throw them into a sand-glass 
        //(the only prison a witch cannot escape from). Unfortunately, he is running out of sand-glasses. 
        //Help Gwenogfryn catch all witches by making your own sand-glasses.
        //Input
        //•	The input data should be read from the console.
        //•	You have an integer number N (always odd number) showing the height of the sand clock.
        //•	The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output should be printed on the console.
        //•	You should print the hourglass on the console. Each row can contain only the following characters:
        //“.” (dot) and “*” (asterisk). As shown in the example: the middle row must contain only one ‘*’ 
        //and all other symbols must be “.”. Every next row (up or down from the middle one) must contain 
        //the same number of ‘*’ as the previous one plus two. You should only use “.” to fill-in the rows, where necessary.
        //Constraints
        //•	The number N will be a positive integer number between 3 and 101, inclusive.
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output		Input	Output		Input	Output
        //3	    ***         5	    *****       7	    *******
        //      .*.                 .***.               .*****.  
        //      ***		            ..*..               ..***..
        //                          .***.               ...*...
        //                          *****	            ..***..
        //                                              .*****.
        //                                              *******	
        //      
        //Attribution: this work may contain portions from the "C# Part I" course by Telerik Academy under CC-BY-NC-SA license.

        int n = int.Parse(Console.ReadLine());
        int midPoint = n / 2; 
        int countAsterisk = n / 2;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if ((j >= midPoint - countAsterisk) & (j <= midPoint + countAsterisk))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            if (i < midPoint)
            {
                countAsterisk--;
            }
            else
            {
                countAsterisk++;
            }
        }
    }
}

