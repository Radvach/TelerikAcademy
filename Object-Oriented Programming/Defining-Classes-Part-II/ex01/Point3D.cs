namespace ex01
{
    using System;
    using System.Text;

    public struct Point3D
    {
        static readonly Point3D pointO = new Point3D(0, 0, 0);

        private int x;
        private int y;
        private int z;

        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        static public Point3D PointO
        {
            get { return pointO; }
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }


        public int Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})",
                this.X, this.Y, this.Z);
        }
    }
}
