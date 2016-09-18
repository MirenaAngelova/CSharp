using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Generic_List_Version
{
    [System.AttributeUsage(
        System.AttributeTargets.Struct |
        System.AttributeTargets.Class |
        System.AttributeTargets.Interface |
        System.AttributeTargets.Method)
    ]
    public class VersionAttribute : System.Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; set; }

        public int Minor { get; set; }

        public override string ToString()
        {
            return this.Major + "." + this.Minor;
        }
    }
}
