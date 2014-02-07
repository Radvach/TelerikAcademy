namespace MobilePhoneDevice
{
    using System;

    public class Display
    {
        // Field.
        private decimal? size;
        // Prop.
        public string Colors { get; set; }

        public Display(decimal? size = null, string colors = null)
        {
            this.Size = size;
            this.Colors = colors;
        }

        // Propfull.
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
    }
}