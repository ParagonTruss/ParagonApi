// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

namespace ParagonApi.Models;

public class UploadFilesResult
{
    public required List<Guid> ComponentDesignGuids { get; set; }

    public required List<string> Errors { get; set; }
}
