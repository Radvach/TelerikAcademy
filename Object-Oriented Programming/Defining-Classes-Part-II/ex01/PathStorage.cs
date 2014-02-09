namespace ex01
{
    using System;
    using System.IO;
    using System.Text;

    static public class PathStorage
    {
        static public Path LoadPaths()
        {
            Path readPath = new Path();
            
            using (StreamReader reader = new StreamReader(@"..\..\3d points_IN.txt",
                Encoding.GetEncoding(1251)))
            {
                while (! reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] coords = line.Split(new[]{'(',',',')'},
                        StringSplitOptions.RemoveEmptyEntries);
                    int xCoord = int.Parse(coords[0]);
                    int yCoord = int.Parse(coords[1]);
                    int zCoord = int.Parse(coords[2]);

                    readPath.AddPath(new Point3D(xCoord, yCoord, zCoord));
                }
            }

            return readPath;
        }


        static public void SavePaths(Path path, bool append)
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\3d points_OUT.txt",
                append, Encoding.GetEncoding(1251)))
            {
                foreach (var point3D in path.PathOfPoints)
                {
                    writer.WriteLine(String.Format("({0}, {1}, {2})", point3D.X, point3D.Y, point3D.Z));
                }
            }
        }
    }
}
