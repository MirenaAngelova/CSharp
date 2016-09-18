using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Shapes
{
    public class Rhombus : BasicShape
    {
        public Rhombus(double width, double height) : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            double area = this.Width*this.Height;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 4*this.Width;
            return perimeter;
        }
    }
}
