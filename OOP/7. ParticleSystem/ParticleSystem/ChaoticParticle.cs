using System;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        protected Random RandGenerator;

        private const int MaxSpeedPerCoordinate = 1;

        public ChaoticParticle(MatrixCoords position, Random randGenerator) :
            base(position, new MatrixCoords(0, 0))
        {
            this.RandGenerator = randGenerator;
        }

        protected MatrixCoords GetRandomCoords()
        {
            int speedRow = this.RandGenerator.Next(-MaxSpeedPerCoordinate, MaxSpeedPerCoordinate + 1);
            int speedCol = this.RandGenerator.Next(-MaxSpeedPerCoordinate, MaxSpeedPerCoordinate + 1);

            return new MatrixCoords(speedRow, speedCol);
        }

        protected override void Move()
        {
            this.Speed += this.GetRandomCoords();
            base.Move();
        }
    }
}
