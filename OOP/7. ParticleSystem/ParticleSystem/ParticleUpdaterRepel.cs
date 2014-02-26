using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    public class ParticleUpdaterRepel : AdvancedParticleOperator
    {
        private readonly List<Particle> _currentTickParticles = new List<Particle>();
        private readonly List<ParticleRepel> _currentTickRepels = new List<ParticleRepel>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var particleRepel = p as ParticleRepel;
            if (particleRepel != null)
            {
                this._currentTickRepels.Add(particleRepel);
            }
            else
            {
                this._currentTickParticles.Add(p);
            }
            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (ParticleRepel repel in this._currentTickRepels)
            {
                foreach (Particle particle in this._currentTickParticles)
                {
                    double distance = GetDistance(particle.Position, repel.Position);
                    if (!(distance <= repel.Radius)) continue;
                    MatrixCoords dir = repel.Position - particle.Position;

                    int pToAttrRow = DecreaseVectorCoordToPower(repel, dir.Row);
                    int pToAttrCol = DecreaseVectorCoordToPower(repel, dir.Col);

                    var curAcceleration = new MatrixCoords(-pToAttrRow, -pToAttrCol);
                    var chicken = particle as ChickenParticle;
                    if (chicken != null)
                    {
                        chicken.Accelerate(curAcceleration);
                    }
                    else
                    {
                        particle.Accelerate(curAcceleration);
                    }
                }
            }

            this._currentTickParticles.Clear();
            this._currentTickRepels.Clear();

            base.TickEnded();
        }

        private static double GetDistance(MatrixCoords pos1Cords, MatrixCoords pos2Cords)
        {
            return
                Math.Sqrt((pos1Cords.Row - pos2Cords.Row)*(pos1Cords.Row - pos2Cords.Row) +
                          (pos1Cords.Col - pos2Cords.Col)*(pos1Cords.Col - pos2Cords.Col));
        }

        protected static int DecreaseVectorCoordToPower(ParticleRepel repel, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > repel.AttractionPower)
            {
                pToAttrCoord = (pToAttrCoord/Math.Abs(pToAttrCoord))*repel.AttractionPower;
            }
            return pToAttrCoord;
        }
    }
}
