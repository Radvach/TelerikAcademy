namespace ex01
{
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> pathOfPoints = new List<Point3D>();

        public List<Point3D> PathOfPoints
        {
            get { return this.pathOfPoints; }
            set { this.pathOfPoints = value; }
        }

        public void AddPath(Point3D point3D)
        {
            this.PathOfPoints.Add(point3D);
        }
    }
}
