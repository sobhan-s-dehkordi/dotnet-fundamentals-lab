public class OrderValidator
{
    public void Validate(Order order)
    {
        if (string.IsNullOrWhiteSpace(order.OrderId))
            throw new InvalidOrderException("Unknown", "Order ID cannot be empty.");

        if (order.TotalAmount < 0)
            throw new InvalidOrderException(order.OrderId, "Order amount cannot be negative.");

        if (order.ItemsCount <= 0)
            throw new InvalidOrderException(order.OrderId, "Order items count must be greater than zero.");
    }
}
