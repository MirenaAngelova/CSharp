using System;
class Sunglasses
{
    static void Main()
    {
        //Do you know that the next solar eclipse will occur on April 29, 2014? It will be observable from South Asia, 
        //Australia, the Pacific and the Indian Oceans and Antarctica. Spiro is an entrepreneur who wants to cash in 
        //on this natural phenomenon. Help him produce protective sunglasses of different sizes. You will get 5% of the profit.
        //Input
        //•	The input data should be read from the console.
        //•	You have an integer number N (always an odd number) specifying the height of sunglasses.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console.
        //You should print the sunglasses on the console. The sunglasses consist of three parts: frames, lenses and 
        //a bridge (the connection between the two frames). Each frame's width is double the height N and should be printed 
        //using the character '*' (asterisk). Print the lenses with the character '/'. Finally, connect the two frames 
        //with a bridge that is of size N, using the character '|'. Leave the rest of the space between the frames blank.
        //Constraints
        //•	The number N will be a positive odd integer number in range [3…101].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input  Output		        Input	  Output
        //3	     ******   ******    5	      **********     **********
        //       *////*|||*////*              *////////*     *////////*
        //       ******   ******	          *////////*|||||*////////*
        //                                    *////////*     *////////*
        //                                    **********     **********
                  
	


        int numberRow = int.Parse(Console.ReadLine());
        string eyes = new string('/', (numberRow * 2) - 2);
        string nose = new string ('|', numberRow);
        string nothing = new string(' ', numberRow);
        string eyelids = string.Format("{0}{1}{0}", '*', eyes);
        string cilia = new string('*', 2 * numberRow);

        for (int i = 0; i < numberRow; i++)
        {
            if (i == 0 || i == numberRow - 1)
            {
                Console.WriteLine("{0}{1}{0}", cilia, nothing);
            }
            else if (i == numberRow / 2)
            {
                Console.WriteLine("{0}{1}{0}", eyelids, nose);
            }
            else
            {
                Console.WriteLine("{0}{1}{0}", eyelids, nothing);
            }
        }
    }
}