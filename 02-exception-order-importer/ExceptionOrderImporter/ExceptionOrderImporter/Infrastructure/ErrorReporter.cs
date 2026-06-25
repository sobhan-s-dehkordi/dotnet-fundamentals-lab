public class ErrorReporter
{
    public void ReportError(Exception ex)
    {
        string msg = ex switch
        {
            FileImportException => "Error reading the input file. Please ensure the file exists and is not being used by another process.",
            ExternalServiceException => "The order registration service is temporarily unavailable. Please try again in a few minutes.",
            OrderImportException => $"Order processing error: {ex.Message}",
            _ => "An unexpected system error occurred. The support team has been notified."
        };

        Console.WriteLine($"Message to user: {msg}");
    }
}
