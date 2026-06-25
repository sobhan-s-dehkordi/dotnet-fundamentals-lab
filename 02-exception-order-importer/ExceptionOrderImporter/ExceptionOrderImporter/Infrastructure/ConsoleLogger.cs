public class ConsoleLogger
{
    public void LogError(Exception ex, string context)
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss}] ERROR in {context}");
        Console.WriteLine($"Message: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");
    }
}
