namespace ParticleSystem
{
    public class ParticleRepel : Particle
    {
        public double Radius { get; protected set; }
        public int AttractionPower { get; protected set; }
        
        public ParticleRepel(MatrixCoords position, MatrixCoords speed, int repelPower, int radius)
            : base(position, speed)
        {
            this.AttractionPower = repelPower;
            this.Radius = radius;
        }

        public override char[,] GetImage()
        {
            return new char[,] {{'#'}};
        }
    }
}
