using OopOrderSystem.Interfaces;

namespace OopOrderSystem.Discounts;

public class FixedDiscount : IDiscount
{
    private readonly decimal _amount;

    public FixedDiscount(decimal amount)
    {
        _amount = amount;
    }

    public decimal Apply(decimal price)
    {
        return price > _amount ? price - _amount : 0;
    }
}