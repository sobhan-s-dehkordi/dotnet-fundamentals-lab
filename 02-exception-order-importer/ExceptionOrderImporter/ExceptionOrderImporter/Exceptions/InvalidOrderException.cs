public class InvalidOrderException : OrderImportException
{
    public string OrderId { get; }

    public InvalidOrderException(string orderId, string message) 
        : base($"Order {orderId} is invalid: {message}")
    {
        OrderId = orderId;
    }
}
