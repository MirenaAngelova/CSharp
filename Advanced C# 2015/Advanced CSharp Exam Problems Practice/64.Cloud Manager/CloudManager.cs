using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _64.Cloud_Manager
{
    class CloudManager
    {
        static void Main(string[] args)
        {
            //sentinel .exe 15MB
            //zoomIt.msi 3MB
            //skype.exe 45MB
            //trojanStopper.bat 23MB
            //kindleInstaller.exe 120MB
            //setup.msi 33.4MB
            //winBlock.bat 1MB

            SortedDictionary<string, List<string>> extensions = 
                new SortedDictionary<string, List<string>>();//ext, file
            SortedDictionary<string, double> memories = new SortedDictionary<string, double>();
           StringBuilder sb = new StringBuilder();//ext, memory
            string input = Console.ReadLine().Replace(" ", String.Empty);
            while (input != String.Empty)
            {
                sb.Append(input);
                input = Console.ReadLine().Replace(" ", String.Empty);
            }
            
            string pattern = "([A-Za-z]+)([\\.a-z]+)([\\.\\d]+)MB";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(sb.ToString());

            foreach (Match match in matches)
            {
                string extension = match.Groups[2].Value;
                string file = match.Groups[1].Value;
                double memory = double.Parse(match.Groups[3].ToString());

                if (!extensions.ContainsKey(extension))
                {
                    extensions.Add(extension, new List<string>());
                }

                if (!memories.ContainsKey(extension))
                {
                    memories.Add(extension, 0);
                }

                memories[extension] += memory;
                if (!extensions[extension].Contains(file))
                {
                    extensions[extension].Add(file);
                }
                
            }
            //{".bat":{"files":["trojanStopper","winBlock"],"memory":"24.00"},
                //".exe":{"files":["kindleInstaller","sentinel","skype"],"memory":"180.00"},
                //".msi":{"files":["setup","zoomIt"],"memory":"36.40"}}
                foreach (var extension in extensions)
                {
                    Console.Write($"{{\"{extension.Key}\":{{files[");
                    int count = 0;
                    extension.Value.Sort();
                    foreach (var file in extension.Value)
                    {
                        count++;
                        Console.Write(file);
                        if (extension.Value.Count != count)
                        {
                            Console.Write(",");
                        }
                        else
                        {
                            Console.Write("],memory:");
                            //Console.Write("],memory:");
                       // Console.Write($"{file.Value:F2}");
                            
                        }
                    }
                    foreach (var memory in memories)
                    {
                        if (memory.Key == extension.Key)
                        {
                            Console.Write($"{memory.Value:F2}");
                        }
                        
                    }
                    Console.WriteLine();
                }
            
        }
    }
}
