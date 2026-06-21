using OopOrderSystem.Domain;

namespace OopOrderSystem.Interfaces;

public interface IStorage
{
    void SaveOrders(List<Order> orders, string filePath);
    List<Order> LoadOrders(string filePath);
}
