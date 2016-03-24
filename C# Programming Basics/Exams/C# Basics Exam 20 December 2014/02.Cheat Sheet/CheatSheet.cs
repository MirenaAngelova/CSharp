using System;
class CheatSheet
{
    static void Main()
    {
        //Goshko is a great singer, but he sucks at math - multiplication table is the thing he hates the most. 
        //Help him by generating a cheat sheet with the multiplication table for him. Goshko should be able 
        //to enter the following things:
        //•	The numbers of rows and columns of the output table
        //•	The start number vertically
        //•	The start number horizontally
        //For example, if he enters 9 rows, 9 columns, vertical and horizontal start numbers 1, the generated cheat sheet 
        //should look like this:
        //  1	2	3	4	5	6	7	8	9
        //1	1	2	3	4	5	6	7	8	9
        //2	2	4	6	8	10	12	14	16	18
        //3	3	6	9	12	15	18	21	24	27
        //4	4	8	12	16	20	24	28	32	36
        //5	5	10	15	20	25	30	35	40	45
        //6	6	12	18	24	30	36	42	48	54
        //7	7	14	21	28	35	42	49	56	63
        //8	8	16	24	32	40	48	56	64	72
        //9	9	18	27	36	45	54	63	72	81
        //If he enters 3 rows, 5 columns, vertical start number 4, horizontal start numbers 8, the generated cheat sheet 
        //should look like this:
        //  8	9	10	11	12
        //4	32	36	40	44	48
        //5	40	45	50	55	60
        //6	48	54	60	66	72
        //Input
        //The input data should be read from the console.
        //•	The first line will contain the number of rows R. The second line will contain the number of c columns C. 
        //The third line will contain the vertical start number V. The fourth line will contain the horizontal start number H.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data should be printed on the console.
        //The output should contain exactly R lines with exactly C numbers per line – representing each line of the cheat sheet. 
        //Numbers should be separated by exactly one whitespace (" "), and there shouldn't be any whitespaces after 
        //the last number on a line.
        //Constraints
        //•	0 ≤ R ≤ 100.
        //•	0 ≤ C ≤ 100.
        //•	Any number N in the cheat sheet will be in the range [-9223372036854775808…9223372036854775807].
        //•	Allowed working time for your program: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	    Output		                    Input	Output
        //9         1 2 3 4 5 6 7 8 9               3       32 36 40 44 48
        //9         2 4 6 8 10 12 14 16 18          5       40 45 50 55 60
        //1         3 6 9 12 15 18 21 24 27         4       48 54 60 66 72
        //1         4 8 12 16 20 24 28 32 36	    8
        //          5 10 15 20 25 30 35 40 45
        //          6 12 18 24 30 36 42 48 54
        //          7 14 21 28 35 42 49 56 63
        //          8 16 24 32 40 48 56 64 72
        //          9 18 27 36 45 54 63 72 81

        int r = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        long v = long.Parse(Console.ReadLine());
        long h = long.Parse(Console.ReadLine());
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                Console.Write((v + i) * (h + j) + " ");
            }
            Console.WriteLine();
        }
    }
}

