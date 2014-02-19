namespace Exercise1
{
    using System;

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(int radius)
            : base(radius, radius)
        {
            this.Radius = radius;
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
}
