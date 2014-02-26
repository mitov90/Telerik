using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        private readonly List<Particle> _currentTickParticles = new List<Particle>();
        private readonly List<ParticleAttractor> _currentTickAttractors = new List<ParticleAttractor>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialAttractor = p as ParticleAttractor;
            if (potentialAttractor != null)
            {
                this._currentTickAttractors.Add(potentialAttractor);
            }
            else
            {
                this._currentTickParticles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (ParticleAttractor attractor in this._currentTickAttractors)
            {
                foreach (Particle particle in this._currentTickParticles)
                {
                    MatrixCoords currParticleToAttractorVector = attractor.Position - particle.Position;

                    int pToAttrRow = currParticleToAttractorVector.Row;
                    pToAttrRow = DecreaseVectorCoordToPower(attractor, pToAttrRow);

                    int pToAttrCol = currParticleToAttractorVector.Col;
                    pToAttrCol = DecreaseVectorCoordToPower(attractor, pToAttrCol);

                    var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);

                    particle.Accelerate(currAcceleration);
                }
            }

            this._currentTickParticles.Clear();
            this._currentTickAttractors.Clear();

            base.TickEnded();
        }

        protected static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.AttractionPower)
            {
                pToAttrCoord = (pToAttrCoord/Math.Abs(pToAttrCoord))*attractor.AttractionPower;
            }
            return pToAttrCoord;
        }
    }
}
