using System;
class BookOrders
{
    static void Main()
    {
        //Bai NakMan has his own book store business. He often makes orders for new books, but the procedure is kind 
        //of complicated. You will be given the number of orders N. Each order holds, number of packets, 
        //amount of books per packet and price per book. Depending on the number of packets, you get different 
        //discount ranging from 5% to 15%.  If the packets in the order are less than 10, there is no discount. 
        //Otherwise they have the following discounts (10-19 packets = 5% discount, 20-29 = 6%, 30-39 = 7%, ..., 100-109 = 14%). 
        //If the packets are 110 or more, there is 15% discount for all books. Your task is to sum how many books 
        //Bai NakMan has bought and the end price of all books. Check the examples below to understand your task better.
        //Input
        //The input data should be read from the console.
        //•	At the first line you will be given integer number N representing the number or orders.
        //•	At the next 3*N lines you will be given the following inputs:
        //o	Book price
        //o	Number of packets
        //o	Books per packet
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It should consist of exactly 2 lines:
        //•	On the first line print the amount of all bought books
        //•	On the second line print the price of all books bough, rounded to the second number after the decimal point
        //Constraints
        //•	The number of orders, packets and books per packet will all be integers in range [0…10000].
        //•	The book price will always be a floating-point number in range [±5.0 × 10-324 … ±1.7 × 10308].
        //•	Allowed working time for your program: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output	    Comments
        //1     375         1 order with 25 packets, each packet holds 15 books (15*25 = 375 books) costing 10.00.
        //25    3525.00     For the 25 packets we have 6% discount making each book costing 9.4.
        //15                All books cost 375 * 9.4 = 3525.00
        //10.00	
        //	  

        //Input	Output		Input	Output		Input	Output
        //2     15600       2       1716        2       532
        //60    207045.00	100     14537.09    5       4688.29
        //10                4                   4
        //8.00              6.88                7.24
        //150               188                 64
        //100               7                   8
        //15.90	            10.88               9.86
        //	

        //int order = int.Parse(Console.ReadLine());
        //int boughtBooks = 0;
        //double totalPrice = 0;

        //for (int i = 0; i < order; i++)
        //{
        //    int packets = int.Parse(Console.ReadLine());
        //    int books = int.Parse(Console.ReadLine());
        //    double price = double.Parse(Console.ReadLine());
        //    int allBooks = packets * books;
        //    boughtBooks += allBooks;
        //    double discount = 0;
        //    if (packets >= 10 & packets < 110)
        //    {
        //        discount = (packets / 10) + 4;
        //    }
        //    else if (packets >= 110)
        //    {
        //        discount = 15;
        //    }
        //    double middlePrice = (price - ((price * discount) / 100));
        //    totalPrice += middlePrice * allBooks;
        //}
        //Console.WriteLine(boughtBooks);
        //Console.WriteLine("{0:f2}", totalPrice);

        int n = int.Parse(Console.ReadLine());
        int boughtBooks = 0;
        double totalPrice = 0;
        for (int order = 0; order < n; order++)
        {
            int packets = int.Parse(Console.ReadLine());
            int books = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int allBooks = packets * books;
            boughtBooks += allBooks;
            int discount = 0;
            if (packets >= 10 & packets < 110)
            {
                discount = packets / 10 + 4;
            }
            else if (packets >= 110)
            {
                discount = 15;
            }
            totalPrice += allBooks * (price - price * (discount / 100.0));
        }
        Console.WriteLine(boughtBooks);
        Console.WriteLine("{0:f2}", totalPrice);
    }
}

