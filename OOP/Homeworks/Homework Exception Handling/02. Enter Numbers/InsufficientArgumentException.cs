using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Enter_Numbers
{
    class InsufficientArgumentException : ArgumentException
    {
        public InsufficientArgumentException(string msg) : base(msg)
        {
        }
    }
}
