using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        private const int MaxTimeEgg = 10;
        private const int MaxChanceEgg = 20;
        protected int? Timeout;

        public ChickenParticle(MatrixCoords position, Random randGenerator) :
            base(position, randGenerator)
        {
            this.Timeout = null;
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.Timeout == null)
            {
                this.Move();
                int chance = this.RandGenerator.Next(100);
                if (chance < MaxChanceEgg)
                {
                    this.Timeout = this.RandGenerator.Next(MaxTimeEgg);
                }
            }
            else if (this.Timeout > 0)
            {
                this.Timeout--;
                return new List<Particle>();
            }
            else if (Timeout == 0)
            {
                this.Timeout = null;
                return new List<Particle>
                   {
                       new ChickenParticle(this.Position, this.RandGenerator)
                   };
            }

            return base.Update();
        }

        public new void Accelerate(MatrixCoords dir)
        {
            this.Speed += dir;
            this.Move();
        }
        protected override void Move()
        {
            base.Move();
        }
    }
}
