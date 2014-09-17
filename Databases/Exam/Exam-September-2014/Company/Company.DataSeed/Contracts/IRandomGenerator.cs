namespace Company.DataSeed.Contracts
{
    using System;

    internal interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomLengthString(int minLength, int maxLength);

        bool GetChance(int chance);

        DateTime GetRandomDate(DateTime minDate, DateTime maxDate);

        DateTime GetRandomDate(DateTime minDate);

        DateTime GetRandomDate();
    }
}