namespace Exercise1
{
    public class Circle : Shape
    {
        public Circle(int radius)
            : base(radius, radius)
        {

        }

        public override double CalculateSurface()
        {
            return System.Math.PI * base.Width * base.Width;
        }
    }
}
