namespace ex01
{
    using System;

    class MainClass
    {
        static void Main()
        {
            // Get the data from '3d points_IN.txt'.
            Path path1 = PathStorage.LoadPaths();

            // Print all points from path1.
            foreach (var point in path1.PathOfPoints)
            {
                Console.WriteLine(point);
            }

            // (22, 33, 44)
            Point3D point3d = new Point3D(77, 33, 44);
            point3d.X = 22;

            // Calc distance between 'point3d' and 'path.PathOfPoints[0]'
            // path.PathOfPoints[0] coords are (3, 4, 5)
            double distance = CalcPointsDistance.CalcDistance(
                point3d, path1.PathOfPoints[0]);

            // http://www.calculatorsoup.com/calculators/geometry-solids/distance-two-points.php
            Console.WriteLine("Distance between {0} and {1} is: {2}",
                point3d, path1.PathOfPoints[0], distance);

            // Create path2 containing two 3d points
            Path path2 = new Path();
            path2.PathOfPoints.Add(point3d);
            path2.PathOfPoints.Add(new Point3D(0, 0, 0));

            // Export points
            // Save points from path1 to file '3d points_OUT.txt'.
            // Append: false
            PathStorage.SavePaths(path1, false);

            // Save points from path1 to file '3d points_OUT.txt'.
            // Append: true
            PathStorage.SavePaths(path2, true);
        }
    }
}
