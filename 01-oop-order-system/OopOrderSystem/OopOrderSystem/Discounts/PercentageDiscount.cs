using OopOrderSystem.Interfaces;

namespace OopOrderSystem.Discounts;

public class PercentageDiscount : IDiscount
{
    private readonly decimal _percentage;

    public PercentageDiscount(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal Apply(decimal price)
    {
        return price - (price * (_percentage / 100));
    }
}
