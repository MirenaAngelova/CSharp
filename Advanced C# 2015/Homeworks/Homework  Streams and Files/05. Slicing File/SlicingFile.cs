﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
internal class SlicingFiles
{
    private static List<string> files = new List<string>();
    private static MatchCollection matches;
    private static void Main()
    {
        //Write a program that takes any file and slices it to n parts. Write the following methods:
        //•	Slice(string sourceFile, string destinationDirectory, int parts) - slices the given source file into n parts 
        //and saves them in destinationDirectory.
        //Source File	Destination Directory
        //•	Assemble(List<string> files, string destinationDirectory) - combines all files into one, in the order they 
        //are passed, and saves the result in destinationDirectory.
        //Source Files	Destination Directory
        //Use FileStreams. You are not allowed to use the File class or similar helper classes.

        string inputFile = @"../../text.txt";
        string folderPath = @"../../";
        int numberOfParts = 4;

        Slice(inputFile, folderPath, numberOfParts);

        Assemble(files, folderPath);
    }
    private static void Assemble(List<string> files, string destinationDirectory)
    {
        string fileOutputPath = destinationDirectory + "asembled" + "." + matches[0].Groups[2];
        var fsSource = new FileStream(fileOutputPath, FileMode.Create);

        fsSource.Close();
        using (fsSource = new FileStream(fileOutputPath, FileMode.Append))
        {
            foreach (var filePart in files)
            {
                using (var partSource = new FileStream(filePart, FileMode.Open))
                {
                    Byte[] bytePart = new byte[4096];
                    while (true)
                    {
                        int readBytes = partSource.Read(bytePart, 0, bytePart.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        fsSource.Write(bytePart, 0, readBytes);
                    }
                }
            }
        }
    }
    private static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        using (var source = new FileStream(sourceFile, FileMode.Open))
        {
            long partSize = (long)Math.Ceiling((double)source.Length / parts);

            long fileOffset = 0;

            string currPartPath;

            FileStream fsPart;

            long sizeRemaining = source.Length;

            string pattern = @"(\w+)(?=\.)\.(?<=\.)(\w+)";
            Regex pairs = new Regex(pattern);
            matches = pairs.Matches(sourceFile);

            for (int i = 0; i < parts; i++)
            {
                currPartPath = destinationDirectory + string.Format(@"Part-{0}", i) + "." + matches[0].Groups[2];
                files.Add(currPartPath);

                using (fsPart = new FileStream(currPartPath, FileMode.Create))
                {
                    long currentPieceSize = 0;
                    byte[] buffer = new byte[4096];
                    while (currentPieceSize < partSize)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        fsPart.Write(buffer, 0, readBytes);
                        currentPieceSize += readBytes;
                    }
                }
                sizeRemaining = (int)source.Length - (i * partSize);

                if (sizeRemaining < partSize)
                {
                    partSize = sizeRemaining;
                }
                fileOffset += partSize;
            }
        }
    }
}
