namespace OopOrderSystem.Domain;

public sealed class DigitalProduct : Product
{
    public string DownloadLink { get; private set; }

    public DigitalProduct(int id, string name, decimal price, string downloadLink) 
        : base(id, name, price) 
    {
        DownloadLink = downloadLink;
    }
}