namespace HashedSetUnitTests
{
    using System.Collections.Generic;

    /// <summary>
    ///     Strange comparer that uses modulo arithmetic.
    /// </summary>
    internal class ModularComparer : IEqualityComparer<int>
    {
        private readonly int modulus;

        public ModularComparer(int modulus)
        {
            this.modulus = modulus;
        }

        public bool Equals(int x, int y)
        {
            return (x % this.modulus) == (y % this.modulus);
        }

        public int GetHashCode(int obj)
        {
            return (obj % this.modulus).GetHashCode();
        }
    }
}