public class OrderProcessingResult
{
    public bool IsSuccess { get; set; }
    public string OrderId { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
}
