public class FakeOrderRepository
{
    private readonly List<string> _existingOrders = new() { "ORD-2000" }; // Simulating duplicate data

    public void Save(Order order)
    {
        if (_existingOrders.Contains(order.OrderId))
            throw new DuplicateOrderException(order.OrderId);
        
        if (new Random().Next(1, 100) > 95) // Simulating a random external service error
            throw new ExternalServiceException("The database is currently unresponsive.");

        _existingOrders.Add(order.OrderId);
    }
}