namespace OopOrderSystem.Domain;

public class PhysicalProduct : Product
{
    public double Weight { get; private set; }

    public PhysicalProduct(int id, string name, decimal price, double weight) 
        : base(id, name, price)
    {
        Weight = weight;
    }
}