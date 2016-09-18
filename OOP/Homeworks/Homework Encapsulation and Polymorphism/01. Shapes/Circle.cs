using System;
using _01.Shapes.Interfaces;

namespace _01.Shapes
{
    public class Circle : IShape
    {
        private double radius;
        public Circle(double raduis)
        {
            this.Radius = raduis;
        }

        public double Radius { get; set; }

        public double CalculateArea()
        {
            double area = Math.PI*this.Radius*this.Radius;
            return area;
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2*Math.PI*this.Radius;
            return perimeter;
        }
    }
}
