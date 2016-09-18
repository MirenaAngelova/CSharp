using System;

namespace _01.Point3D
{
    class Test
    {
        static void Main()
        {
            Point3D test1 = new Point3D(2, -3, 5);
            Point3D test2 = new Point3D(2, 5, 5);

            Console.WriteLine(Point3D.StartingPoint.ToString());
            Console.WriteLine(test1);
            Console.WriteLine(test2);

            Console.WriteLine(DistanceCalculator.Distance(test1, test2));

            Path3D points = new Path3D(test1, test2);
            Storage.Write("file", points);
            Path3D testList = Storage.Read("file");

            Console.WriteLine(testList);
        }
    }
}
