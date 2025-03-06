namespace ParagonApi.Models;

public class BinaryUploadFile
{
    private string SourcePath { get; }
    private byte[] SourceBytes { get; }

    public BinaryUploadFile(string path, byte[] bytes)
    {
        SourcePath = path;
        SourceBytes = bytes;
    }

    public static BinaryUploadFile Create(string path)
    {
        return new BinaryUploadFile(path, File.ReadAllBytes(path));
    }

    public Base64File ToBase64File()
    {
        return new Base64File
        {
            Filename = Path.GetFileName(SourcePath),
            Contents = $"data:application/octet-stream;base64,{Convert.ToBase64String(SourceBytes)}",
        };
    }
}
