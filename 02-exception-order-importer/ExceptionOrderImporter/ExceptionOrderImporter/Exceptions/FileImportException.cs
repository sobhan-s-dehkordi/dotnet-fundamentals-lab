public class FileImportException : OrderImportException
{
    public FileImportException(string message, Exception innerException) 
        : base(message, innerException) { }
}
