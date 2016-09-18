using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Generic_List
{
    class Program
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Remove(3);
            list.Insert(3, 3);
            Console.WriteLine(list.Access(1));
            Console.WriteLine(list.FindIndexOf(2));
            Console.WriteLine(list.Contains(111));
            list.ShowVersion();
        }
    }
}
