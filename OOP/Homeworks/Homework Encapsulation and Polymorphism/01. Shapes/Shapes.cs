using System;
using _01.Shapes.Interfaces;

namespace _01.Shapes
{
    class Shapes
    {
        static void Main()
        {
            IShape[] shapes =
            {
                new Circle(2.5),
                new Rectangle(3.5, 4.5),
                new Rhombus(1.5, 2),
            };
            foreach (var shape in shapes)
            {
                Console.WriteLine("Shape: {0}, Area: {1:F2}, Perimeter: {2:f2}", 
                    shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
