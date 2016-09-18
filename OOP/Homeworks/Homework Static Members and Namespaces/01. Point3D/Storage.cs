using System;
using System.Collections.Generic;
using System.IO;

namespace _01.Point3D
{
    class Storage
    {
        public static Path3D Read(string fileName)
        {
            List<Point3D> points = new List<Point3D>();
            string readPath = "../../" + fileName + ".txt";
            using (var reader = new StreamReader(readPath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] currentPoint = line.Split(new char[] {' ', ',', '(', ')'},
                        StringSplitOptions.RemoveEmptyEntries);
                    int x = int.Parse(currentPoint[0]);
                    int y = int.Parse(currentPoint[1]);
                    int z = int.Parse(currentPoint[2]);
                    Point3D newPoint = new Point3D(x, y, z);
                    points.Add(newPoint);
                    line = reader.ReadLine();
                }
            }
            Path3D path = new Path3D(points);
            return path;
        }

        public static void Write(string fileName, Path3D path)
        {
            List<Point3D> points = new List<Point3D>(path.Path);
            string writePath = "../../" + fileName + ".txt";
            using (var writer = new StreamWriter(writePath))
            {
                int row = 0;
                while (row < points.Count)
                {
                    Point3D currentPoint = points[row];
                    string line = string.Format("({0},{1},{2})", currentPoint.X, currentPoint.Y, currentPoint.Z);
                    writer.WriteLine(line);
                    row++;
                }
            }
        }
    }
}
