using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BitArray
{
    class Test
    {
        static void Main()
        { 
            Console.WriteLine("Bit Array (Big Integer):");
            BitArrayBigInteger a = new BitArrayBigInteger(50);
            Console.WriteLine("Initial value = {0}", a);
            a[49] = 1;
            a[23] = 1;
            Console.WriteLine("Value after setting #49 to 1 and #23 to 1 = {0}", a);
            Console.WriteLine("Value of position #49 = {0}", a[49]);
            a[49] = 0;
            Console.WriteLine("Value after setting #49 to 0 = {0}", a);
            Console.WriteLine("Value of position #49 = {0}", a[49]);

            Console.WriteLine();
            Console.WriteLine("Bit Array:");
            BitArray b = new BitArray(50);
            Console.WriteLine("Initial value = {0}", b);
            b[49] = 1;
            b[23] = 1;
            Console.WriteLine("Value after setting #49 to 1 and #23 to 1 = {0}", b);
            Console.WriteLine("Value of position #49 = {0}", b[49]);
            b[49] = 0;
            Console.WriteLine("Value after setting #49 to 0 = {0}", b);
            Console.WriteLine("Value of position #49 = {0}", b[49]);
        }
    }
}
