using OopOrderSystem.Domain;

namespace OopOrderSystem.Services;

public class PricingService
{
    public decimal CalculateTotal(Order order)
    {
        decimal total = 0;

        foreach (var item in order.Items)
        {
            total += item.Product.Price * item.Quantity;
        }

        if (order.AppliedDiscount is not null)
            total = order.AppliedDiscount.Apply(total);

        return total;
    }
}
