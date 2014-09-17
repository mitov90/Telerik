namespace ToyStore.DataSeed.Contracts
{
    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomLengthString(int minLength, int maxLength);

        bool GetChance(int chance);
    }
}