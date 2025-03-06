namespace ParagonApi;

public class JwtStorage
{
    private static string AppDataDirectory => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    private string JwtStorageFileName { get; }

    private static string StorageDirectory => Path.Combine(AppDataDirectory, "Paragon");
    public string FilePath => Path.Combine(StorageDirectory, JwtStorageFileName);

    public JwtStorage(string jwtStorageFileName)
    {
        JwtStorageFileName = jwtStorageFileName;
    }

    public void Store(string jwtToken)
    {
        if (!Directory.Exists(StorageDirectory))
        {
            Directory.CreateDirectory(StorageDirectory);
        }

        File.WriteAllText(FilePath, jwtToken);
    }

    public string? Fetch()
    {
        return !File.Exists(FilePath) ? null : File.ReadAllText(FilePath);
    }

    public void Clear()
    {
        if (File.Exists(FilePath))
            File.Delete(FilePath);
    }
}
