using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Point3D
{
    class Path3D
    {
        private List<Point3D> path = new List<Point3D>();

        public Path3D(params Point3D[] points)
        {
            this.Path = points.ToList();
        }

        public Path3D(List<Point3D> points)
        {
            this.Path = points;
        }
        public List<Point3D> Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var point in this.Path)
            {
                sb.AppendLine(point.ToString());
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}
