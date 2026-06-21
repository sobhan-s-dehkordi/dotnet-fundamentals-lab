namespace OopOrderSystem.Domain;

public abstract class Product
{
    public int Id { get; init; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    protected Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"[{Id}: {Name} - {Price}]";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Product other)
            return Id == other.Id;

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
