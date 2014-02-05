namespace MobilePhoneDevice
{
    using System;

    public class Display
    {
        private decimal? size;
        private string colors;

        public Display()
            : this(null)
        {
        }

        public Display(decimal? size)
            : this(size, null)
        {
        }

        public Display(decimal? size, string colors)
        {
            this.size = size;
            this.colors = colors;
        }

        public decimal? Size
        {
            get { return this.size; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid size: " + value);
                }
                this.size = value;
            }
        }

        public string Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }
    }
}