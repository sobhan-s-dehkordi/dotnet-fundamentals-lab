using OopOrderSystem.Discounts;
using OopOrderSystem.Domain;
using OopOrderSystem.Services;
using OopOrderSystem.Utilities;

Console.WriteLine("=== Order Management System ===");

//Test Data
var products = new List<Product>
{
    new PhysicalProduct(1,"Clean Code Book", 10.0m, 1.2),
    new PhysicalProduct(2, "Mouse", 25.0m, 0.3),
    new DigitalProduct(3, "C# Class", 150.0m, "http://smaple")
};


var orderService = new OrderService();
var pricingService  = new PricingService();
var storage = new JsonStorage();

string dbPath = "orders.json";

var discount = new PercentageDiscount(10);
var myOrder = orderService.CreateOrder("Sobhan S Dehkordi", discount);

Console.WriteLine("\nAvailable Products:");
foreach (var p in products)
{
    Console.WriteLine(p.ToString());
}

Console.Write("\nEnter Product Id to buy (or 0 to exit): ");
string input = Console.ReadLine();

if (int.TryParse(input, out int productId) && productId > 0)
{
    var selected = products.Find(p => p.Id == productId);

    if (selected is not null)
    {
        myOrder.AddItem(new OrderItem(selected, 1));
    }

    if (selected is PhysicalProduct physProd)
    {
        Console.WriteLine($"Physical Item - Weight: {physProd.Weight}kg");
    }
    else if (selected is DigitalProduct digProd)
    {
        Console.WriteLine($"Digital Item - Link: {digProd.DownloadLink}");
    }
}

decimal totalBeforeTax = pricingService.CalculateTotal(myOrder);

decimal finalPrice = totalBeforeTax.ApplyTax();

Console.WriteLine("\n=== Order Report ===");
Console.WriteLine($"Order No: {myOrder.OrderNumber}");
Console.WriteLine($"Customer: {myOrder.CustomerName}");
Console.WriteLine($"Total (with discount): ${totalBeforeTax}");
Console.WriteLine($"Final Price (+Tax): ${finalPrice}");

var orderToSave = new List<Order> { myOrder };
storage.SaveOrders(orderToSave, dbPath);
Console.WriteLine($"\nOrder saved to {dbPath}");

Console.ReadKey();