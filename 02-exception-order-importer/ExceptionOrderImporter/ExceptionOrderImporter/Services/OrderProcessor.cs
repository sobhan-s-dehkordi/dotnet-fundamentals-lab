public class OrderProcessor
{
    private readonly OrderValidator _validator;
    private readonly FakeOrderRepository _repository;

    public OrderProcessor(OrderValidator validator, FakeOrderRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public ImportResult ProcessOrders(List<Order> orders)
    {
        var result = new ImportResult { TotalProcessed = orders.Count };

        foreach (var order in orders)
        {
            try
            {
                _validator.Validate(order);

                _repository.Save(order);

                result.SuccessCount++;
                result.Details.Add(new OrderProcessingResult { IsSuccess = true, OrderId = order.OrderId });
            }
            catch (OrderImportException ex)
            {
                result.FailureCount++;
                result.Details.Add(new OrderProcessingResult
                {
                    IsSuccess = false,
                    OrderId = string.IsNullOrWhiteSpace(order.OrderId) ? "unknown" : order.OrderId,
                    ErrorMessage = ex.Message
                });
            }
        }

        return result;
    }
}