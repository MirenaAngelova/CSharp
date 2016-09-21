using System;
using System.IO;
using System.Text;
class LineNumbers
{
    static void Main()
    {
        //Write a program that reads a text file and inserts line numbers in front of each of its lines. 
        //The result should be written to another text file. Use StreamReader in combination with StreamWriter.

        StreamReader reader = null;
        StreamWriter writer = null;

        try
        {
            reader = new StreamReader(@"..\..\LineNumbers.cs", Encoding.GetEncoding("windows-1251"));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not fount!");
        }

        try
        {
            writer = new StreamWriter(@"..\..\LineNumbers.txt");
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to create output file.");
        }

        string s;
        int lineNumber = 1;
        using (reader)
        using(writer)
        {
            do
            {
                s = reader.ReadLine();
                writer.WriteLine("{0} {1}", lineNumber, s);
                lineNumber++;
            } while (s != null);
        }
        Console.WriteLine("Task complete:\n");
        string fileContents = File.ReadAllText(@"..\..\LineNumbers.txt");
        Console.WriteLine(fileContents);
    }
}