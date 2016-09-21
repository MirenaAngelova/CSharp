using System;
using System.IO;
class CopyBinaryFile
{
    const string NImagePath = "../../text.txt";
    const string DestinationPath = "../../result.txt";
    static void Main()
    {
        //Write a program that copies the contents of a binary file (e.g. image, video, etc.) to another using FileStream.
        //You are not allowed to use the File class or similar helper classes.

        using (var source = new FileStream(NImagePath, FileMode.Open))
        {
            using (var destination = new FileStream(DestinationPath, FileMode.Create))
            {
                byte[] buffer = new byte[source.Length];
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    destination.Write(buffer, 0, readBytes);
                }
            }
        }
        System.Diagnostics.Process.Start(@"..\..\jpg");
    }
}