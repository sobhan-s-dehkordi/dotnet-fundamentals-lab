using OopOrderSystem.Domain;
using OopOrderSystem.Interfaces;
using System.Text.Json;

namespace OopOrderSystem.Utilities;

public class JsonStorage : IStorage
{
    public List<Order> LoadOrders(string filePath)
    {
        if (!File.Exists(filePath))
            return new List<Order>();

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
    }

    public void SaveOrders(List<Order> orders, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(orders, options);
        File.WriteAllText(filePath, json);
    }
}
