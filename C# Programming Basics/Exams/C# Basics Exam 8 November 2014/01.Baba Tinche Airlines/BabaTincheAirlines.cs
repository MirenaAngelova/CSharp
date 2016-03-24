using System;
class BabaTincheAirlines
{
    static void Main()
    {
        //Every month Baba Tinche travels to the Republic of Tajikistan to meet her boyfriend. 
        //But the tickets are so expensive that she decides to establish her own airline instead called 
        //Baba Tinche Airlines. There are three travel classes in Baba Tinche Airlines:
        //•	First Class which accommodates 12 passengers. The ticket price is $7000.
        //•	Business Class which accommodates 28 passengers. The ticket price is $3500.
        //•	Economy Class which accommodates 50 passengers. The ticket price is $1000.
        //Please note that some passengers are Frequent Flyers and their tickets are 70% off ($1000 ticket will cost $300).
        //Also some passengers purchase a meal on the flight, which costs 0.5% of the ticket price for the travel class 
        //they are in. Please help Baba Tinche calculate her income and calculate the difference between 
        //her income and the maximum possible income (the maximum possible income being all seats taken, 
        //no Frequent Flyers and everyone purchasing meals). You will be given the number of passengers for each class, 
        //the number of passengers who are Frequent Flyers in that class, and the number of passengers who purchase 
        //a meal in that class.
        //Input
        //The input data should be read from the console. It consists of exactly 3 lines:
        //•	The first line holds the number of all passengers in First Class
        //•	The second line holds the number of all passengers in Business Class
        //•	The third line holds the number of all passengers in Economy Class
        //•	The second and third number on all lines will be the number of Frequent Flyers and the number of passengers 
        //who will purchase a meal in the given class.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It should consist of exactly 2 lines.
        //•	The first line will  hold Baba Tinche’s income cast to an integer
        //•	The second line holding the difference between the maximum possible profit and baba Tinche’s actual profit 
        //cast to an integer
        //Constraints
        //•	The first number in the first line will be in the range [0…12]. 
        //•	The first number in the second line will be in the range [0…28]. 
        //•	The first number in the third line will be in the range [0…50]. 
        //•	The second and third numbers on all lines will be less or equal to the first number.
        //•	Allowed memory: 16 MB. Allowed working time: 0.25 seconds.
        //Examples
        //Input	    Output		Input	    Output		Input	Output		Input	    Output
        //6 1 2     126877      8 2 1       166612      2 0 0   23000       11 4 6      163710
        //21 8 7    106283      26 4 15     66548       2 0 0   210160	    24 6 10     69450
        //44 12 17	            50 16 23                2 0 0               38 2 5	

        int[] passengers = new int[3];
        int income = 0;
        int maxIncome = 0;
        int price = 0;
        int[] prices = { 7000, 3500, 1000 };
        for (int i = 0; i < 3; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            price = prices[i];
            for (int j = 0; j < 3; j++)
            {
                passengers[j] = int.Parse(input[j]);
            }
            income += (int)((passengers[0] - passengers[1]) * price + passengers[1] * 0.3m * price
                + passengers[2] * 0.005m * price);
        }
        maxIncome = (int)((12 * 7000 + 28 * 3500 + 50 * 1000) * 1.005m);
        Console.WriteLine(income);
        Console.WriteLine(maxIncome - income);


        //int[] passengers = new int[3];
        //int[] prices = { 7000, 3500, 1000 };
        //int actualProfit = 0;
        //int maxProfit = 0;
        //int price = 0;
        //for (int i = 0; i < 3; i++)
        //{
        //    string[] classes = Console.ReadLine().Split();
        //    price = prices[i];
        //    for (int j = 0; j < 3; j++)
        //    {
        //        passengers[j] = int.Parse(classes[j]);
        //    }
        //    actualProfit += (int)((passengers[0] - passengers[1]) * price + passengers[1] * price * 0.3m +
        //        passengers[2] * price * 0.005m);
        //}
        //maxProfit = (int)((12 * prices[0] + 28 * prices[1] + 50 * prices[2]) * 1.005m);
        //Console.WriteLine(actualProfit);
        //Console.WriteLine(maxProfit - actualProfit);
    }
}

