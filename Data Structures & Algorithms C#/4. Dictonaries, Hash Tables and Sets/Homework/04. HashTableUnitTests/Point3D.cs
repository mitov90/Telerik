namespace HashTableUnitTests
{
    internal class Point3D
    {
        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            Point3D other = obj as Point3D;

            if (other == null)
            {
                return false;
            }

            if (!this.X.Equals(other.X))
            {
                return false;
            }

            if (!this.Y.Equals(other.Y))
            {
                return false;
            }

            if (!this.Z.Equals(other.Z))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int Prime = 83;
            int result = 1;
            unchecked
            {
                result = result * Prime + X.GetHashCode();
                result = result * Prime + Y.GetHashCode();
                result = result * Prime + Z.GetHashCode();
            }

            return result;
        }
    }
}
