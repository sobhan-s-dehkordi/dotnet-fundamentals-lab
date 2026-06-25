using System.Text.Json;

public class JsonOrderParser
{
    public List<Order> Parse(string jsonContent)
    {
        try
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<List<Order>>(jsonContent, option);
            return result ?? new List<Order>();    

        }
        catch (JsonException ex)
        {

            throw new FileImportException("The JSON file structure is corrupted and unreadable.", ex);
        }
    }
}
