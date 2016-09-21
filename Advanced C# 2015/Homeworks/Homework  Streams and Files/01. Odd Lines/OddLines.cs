using System;
using System.IO;
using System.Text;
class OddLines
{
    static void Main()
    {
        //Write a program that reads a text file and prints on the console its odd lines. Line numbers starts from 0. 
        //Use StreamReader.

        try
        {
            StreamReader reader = new StreamReader(@"..\..\OddLines.cs", Encoding.GetEncoding("windows-1251"));

            string s;
            int lineNumber = 0;
            using (reader)
            {
                do
                {
                    s = reader.ReadLine();
                    lineNumber++;
                    s = reader.ReadLine();
                    Console.WriteLine("Line {0, 2}: {1}", lineNumber, s);
                    lineNumber++;
                } while (s != null);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
    }
}


