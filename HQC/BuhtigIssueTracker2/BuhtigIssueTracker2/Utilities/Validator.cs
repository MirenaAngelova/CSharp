using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuhtigIssueTracker2.Interfaces;

namespace BuhtigIssueTracker2.Utilities
{
    public static class Validator
    {
        public static void ValidateMinLength(string value, string name, int minValue)
        {
            if (string.IsNullOrEmpty(value) || value.Length < minValue)
            {
                throw new ArgumentException($"The {name} must be at least {minValue} symbols long");
            }
        }
    }
}
