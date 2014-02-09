namespace ex01
{
    static public class CalcPointsDistance
    {
        static public double CalcDistance(Point3D point1, Point3D point2)
        {
            int distanceX = point1.X - point2.X;
            int distanceY = point1.Y - point2.Y;
            int distanceZ = point1.Z - point2.Z;

            int squareX = distanceX * distanceX;
            int squareY = distanceY * distanceY;
            int squareZ = distanceZ * distanceZ;

            double result = System.Math.Sqrt(squareX + squareY + squareZ);

            return result;
        }
    }
}
