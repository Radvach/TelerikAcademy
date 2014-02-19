namespace Exercise1
{
    public class Triangle : Shape
    {
        public Triangle(int width, int height)
            : base(width, height)
        {

        }

        public override double CalculateSurface()
        {
            return (base.Height * base.Width) / 2.0;
        }
    }
}
