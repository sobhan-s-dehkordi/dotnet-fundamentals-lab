public class JsonFileReader
{
    public string Read(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
        {
            throw new FileImportException($"The file at path {filePath} was not found.", ex);
        }
        catch (IOException ex)
        {
            throw new FileImportException("The file is being used by another process.", ex);
        }
    }
}
