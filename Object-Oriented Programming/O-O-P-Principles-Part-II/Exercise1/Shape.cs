namespace Exercise1
{
    using System;

    public abstract class Shape
    {
        private int width;
        private int height;

        protected Shape(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return this.width; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be positive.");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be positive.");
                }

                this.height = value; 
            }
        }

        public abstract double CalculateSurface();
    }
}
