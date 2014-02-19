using System;

namespace Exercise1
{
    public class ClassTest
    {
        static void Main()
        {
            Shape[] shapes = new Shape[3];
            shapes[0] = new Rectangle(3, 4);
            shapes[1] = new Triangle(3, 4);
            shapes[2] = new Circle(4);

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0}: {1:F2}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
