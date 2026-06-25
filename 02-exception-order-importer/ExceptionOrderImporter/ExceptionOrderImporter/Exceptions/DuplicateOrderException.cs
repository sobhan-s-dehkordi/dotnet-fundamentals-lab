public class DuplicateOrderException : OrderImportException 
{
    public DuplicateOrderException(string orderId) 
        : base($"Order with ID {orderId} is a duplicate and has already been registered.") { }
}
