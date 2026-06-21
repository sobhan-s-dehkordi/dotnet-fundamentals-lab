namespace OopOrderSystem.Utilities;

public static class PriceExtensions
{
    public static decimal ApplyTax(this decimal price, decimal taxPercentage = 10)
    {
        return price + (price * (taxPercentage / 100));
    }

}
