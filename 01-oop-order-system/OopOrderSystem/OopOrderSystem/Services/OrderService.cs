using OopOrderSystem.Domain;
using OopOrderSystem.Interfaces;
using OopOrderSystem.Utilities;

namespace OopOrderSystem.Services;

public class OrderService
{
    public Order CreateOrder(string customerName)
    {
        return new Order(RandomGenerator.GenerateOrderNumber(), customerName);
    }

    public Order CreateOrder(string customerName, IDiscount discount)
    {
        return new Order(RandomGenerator.GenerateOrderNumber(), customerName, discount);
    }
}
