using System;
class MagicString
{
    static void Main()
    {
        //You are given a number diff. Write a program to generate all sequences of 8 letters, 
        //each from the set { 's', 'n', 'k', 'p' }, such that the weight of the first 4 letters differs 
        //from the weight of the second 4 letters exactly by diff. These sequences are called “magic strings”. 
        //Print them in alphabetical order.
        //The weight of a single letter is calculated as follows:  
        //weight('s') = 3; weight('n') = 4;  weight('k') = 1;  weight('p') = 5. 
        //The weight of a sequence of 4 letters is the calculated as sum of the weights of these 4 individual letters.
        //Input
        //•	The input data should be read from the console
        //•	The number diff stays at the first line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console as a sequence of strings in alphabetical order. 
        //Each string should stay on a separate line. In case no magic strings exist, print “No”.
        //Constraints
        //•	The number diff will be an integer number in the range [0…100].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	    Output	    Comments
        //16	    kkkkpppp    weight('kkkk') = 4; weight('pppp') = 20; diff = 16
        //          ppppkkkk    weight('pppp') = 20; weight('kkkk') = 4; diff = 16	
        //                      
        //Input	    Output	    Comments
        //15	    kkkknppp    weight('kkkk') = 4; weight('nppp') = 19; diff = 15
        //          kkkkpnpp    weight('kkkk') = 4; weight('pnpp') = 19; diff = 15
        //          kkkkppnp    weight('kkkk') = 4; weight('ppnp') = 19; diff = 15
        //          kkkkpppn    weight('kkkk') = 4; weight('pppn') = 19; diff = 15
        //          npppkkkk    weight('nppp') = 19; weight('kkkk') = 4; diff = 15
        //          pnppkkkk    weight('pnpp') = 19; weight('kkkk') = 4; diff = 15
        //          ppnpkkkk    weight('ppnp') = 19; weight('kkkk') = 4; diff = 15
        //          pppnkkkk    weight('pppn') = 19; weight('kkkk') = 4; diff = 15	
        //                      
        //Input	    Output	    Comments                      
        //20	    No	        No magic strings match the specified difference diff  

        int diff = int.Parse(Console.ReadLine());
        char[] letters = { 'k', 'n', 'p', 's' };
        int sum = 0;
        for (int a = 0; a < letters.Length; a++)
        {
            for (int b = 0; b < letters.Length; b++)
            {
                for (int c = 0; c < letters.Length; c++)
                {
                    for (int d = 0; d < letters.Length; d++)
                    {
                        string first = "" + letters[a] + letters[b] + letters[c] + letters[d];
                        int weightFirst = SumWeight(first);
                        for (int e = 0; e < letters.Length; e++)
                        {
                            for (int f = 0; f < letters.Length; f++)
                            {
                                for (int g = 0; g < letters.Length; g++)
                                {
                                    for (int h = 0; h < letters.Length; h++)
                                    {
                                        string second = "" + letters[e] + letters[f] + letters[g] + letters[h];
                                        int weightSecond = SumWeight(second);
                                        if (Math.Abs(weightFirst - weightSecond) == diff)
                                        {
                                            Console.WriteLine(first + second);
                                            sum++;
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (sum == 0)
        {
            Console.WriteLine("No");
        }
    }

    private static int SumWeight(string str)
    {
        int weight = 0;
        foreach (var ch in str)
        {
            switch (ch)
            {
                case 's': weight += 3; break;
                case 'n': weight += 4; break;
                case 'k': weight += 1; break;
                case 'p': weight += 5; break;
            }
        }
        return weight;
    }
}


       
        
    


