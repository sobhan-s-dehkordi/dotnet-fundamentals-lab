using System.Text.Json;

string sampleFilePath = "sample-orders.json";
CreateSampleJsonFile(sampleFilePath);

var logger = new ConsoleLogger();
var reporter = new ErrorReporter();
var fileReader = new JsonFileReader();
var parser = new JsonOrderParser();
var validator = new OrderValidator();
var repository = new FakeOrderRepository();
var processor = new OrderProcessor(validator, repository);


try
{
    string jsonContent = fileReader.Read(sampleFilePath);

    var orders = parser.Parse(jsonContent);

    var result = processor.ProcessOrders(orders);

    PrintReport(result);
}
catch (OrderImportException ex)
{
    reporter.ReportError(ex);
}
catch (Exception ex)
{
    logger.LogError(ex, "Program.Main");
    reporter.ReportError(ex);
}

Console.ReadLine();



static void PrintReport(ImportResult result)
{
    Console.WriteLine($"TotalProcessed: {result.TotalProcessed} | SuccessCount: {result.SuccessCount} | FailureCount: {result.FailureCount}\n");

    foreach (var detail in result.Details)
    {
        if (detail.IsSuccess)
        {
            Console.WriteLine($"[OK] Order {detail.OrderId} was successfully registered.");
        }
        else
        {
            Console.WriteLine($"[FAIL] Order {detail.OrderId} failed to register. Reason: {detail.ErrorMessage}");
        }
    }
}

static void CreateSampleJsonFile(string path)
{
    var orders = new[]
    {
        new { orderId = "ORD-1001", customerName = "Ali", totalAmount = 250000, itemsCount = 3 },
        new { orderId = "", customerName = "Sara", totalAmount = 120000, itemsCount = 1 },
        new { orderId = "ORD-1003", customerName = "Reza", totalAmount = -50000, itemsCount = 2 },
        new { orderId = "ORD-2000", customerName = "DuplicateUser", totalAmount = 50000, itemsCount = 1 }
    };

    string json = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(path, json);
}

