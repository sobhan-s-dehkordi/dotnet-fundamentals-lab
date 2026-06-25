public abstract class OrderImportException : Exception
{
    protected OrderImportException() 
        : base () { }

    protected OrderImportException(string message) 
        : base(message) { }

    protected OrderImportException(string message, Exception innerException) 
        : base(message, innerException) { }
}
