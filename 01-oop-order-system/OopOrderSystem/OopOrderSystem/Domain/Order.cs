using OopOrderSystem.Interfaces;

namespace OopOrderSystem.Domain;

public class Order
{
    public int OrderNumber { get; init; }
    public string CustomerName { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public IDiscount? AppliedDiscount { get; private set; }

    public Order(int orderNumber, string customerName, IDiscount? discount = null)
    {
        OrderNumber = orderNumber;
        CustomerName = customerName;
        Items = new List<OrderItem>();
        AppliedDiscount = discount;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }
}
