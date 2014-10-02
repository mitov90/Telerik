using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    internal class ParticleSystemMain
    {
        private const int SimulationRows = 30;

        private const int SimulationCols = 40;

        private static readonly Random RandomGenerator = new Random();

        private static void Main()
        {
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);
            var particleOperator = new ParticleUpdaterRepel();
            
            var particles = new List<Particle>
                            {
                                new Particle(new MatrixCoords(12, 12), new MatrixCoords(-1, -1)),
                                new ParticleRepel(new MatrixCoords(8, 8), new MatrixCoords(0, 0), 1, 10),
                                new Particle(new MatrixCoords(8, 35), new MatrixCoords(0, -1)),
                                new ChickenParticle(new MatrixCoords(5, 10), RandomGenerator),
                                new ParticleRepel(new MatrixCoords(25, 30), new MatrixCoords(0, 0), 1, 10),
                                new ChickenParticle(new MatrixCoords(20, 25), RandomGenerator),
                            };

            var engine = new Engine(renderer, particleOperator, particles, 100);

            engine.Run();
        }
    }
}
