using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class DirectoryTraversal
{
    private static void Main()
    {
        //Traverse a given directory for all files with the given extension. Search through the first level of the directory 
        //only and write information about each found file in report.txt.
        //The files should be grouped by their extension. Extensions should be ordered by the count of their files 
        //(from most to least). If two extensions have equal number of files, order them by name.
        //Files under an extension should be ordered by their size.
        //report.txt should be saved on the Desktop. Ensure the desktop path is always valid, regardless of the user.
        //Input	        Directory View	report.txt
        //../../	 	                .cs
        //                              --Mecanismo.cs - 0.994kb
        //                              --Program.cs - 1.108kb
        //                              --Nashmat.cs - 3.967kb
        //                              --Wedding.cs - 23.787kb
        //                              --Program - Copy.cs - 35.679kb
        //                              --Salimur.cs - 588.657kb
        //                              .txt
        //                              --backup.txt - 0.028kb
        //                              --log.txt - 6.72kb
        //                              .asm
        //                              --script.asm - 0.028kb
        //                              .config
        //                              --App.config - 0.187kb
        //                              .csproj
        //                              --01. Writing-To-Files.csproj - 2.57kb
        //                              .js
        //                              --controller.js - 1635.143kb
        //                              .php
        //                              --model.php - 0kb

        string[] filePaths = Directory.GetFiles(@"../../");

        List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();

        var sorted =
            files.OrderBy(file => file.Length)
            .GroupBy(file => file.Extension)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key);

        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        StreamWriter writer = new StreamWriter(desktop + "/report.txt");
        foreach (var group in sorted)
        {
            writer.WriteLine(group.Key);

            foreach (var y in group)
            {
                writer.WriteLine("--{0} - {1:F3}kb", y.Name, y.Length / 1024.0);
            }
        }
        writer.Close();

        System.Diagnostics.Process.Start(desktop + "/report.txt");
    }
}