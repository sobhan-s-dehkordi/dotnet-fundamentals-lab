namespace OopOrderSystem.Utilities;

public static class RandomGenerator
{
    private static readonly Random _random = new Random();

    public static int GenerateOrderNumber()
    {
        return _random.Next(10000, 99999);
    }
}