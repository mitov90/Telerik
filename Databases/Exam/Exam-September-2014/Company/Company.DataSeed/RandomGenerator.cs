namespace Company.DataSeed
{
    using System;

    using Company.DataSeed.Contracts;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "qwertyuiopasdfghjklzxcvbnm";

        private static RandomGenerator instance;

        private readonly Lazy<Random> random = new Lazy<Random>();

        private RandomGenerator()
        {
        }

        public Random Random
        {
            get
            {
                return this.random.Value;
            }
        }

        public static RandomGenerator GetInstance()
        {
            return instance ?? (instance = new RandomGenerator());
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.Random.Next(min, max + 1);
        }

        public string GetRandomLengthString(int minLength, int maxLength)
        {
            int length = this.GetRandomNumber(minLength, maxLength);
            return this.GetRandomString(length);
        }

        public string GetRandomString(int length)
        {
            char[] word = new char[length];
            word[0] = char.ToUpper(Letters[this.GetRandomNumber(0, Letters.Length - 1)]);

            for (int i = 1; i < length; i++)
            {
                word[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(word);
        }

        public bool GetChance(int chance)
        {
            return this.GetRandomNumber(0, 100) <= chance;
        }

        public DateTime GetRandomDate(DateTime minDate, DateTime maxDate)
        {
            var span = maxDate - minDate;
            var addTime = this.GetRandomNumber(0, span.Days);
            return minDate.AddDays(addTime);
        }

        public DateTime GetRandomDate(DateTime minDate)
        {
            return this.GetRandomDate(minDate, minDate.AddYears(5));
        }

        public DateTime GetRandomDate()
        {
            return this.GetRandomDate(DateTime.Now.AddYears(-10));
        }
    }
}