namespace ParagonApi.Models;

/// <summary>
/// Some downloads are available for either `ComponentDesign`s or `AnalysisSet`s. This enum helps us to distinguish
/// which GUIDs are referred to in the request.
/// </summary>
public enum GuidType
{
    ComponentDesign,
    AnalysisSet,
}

public class DownloadRequest
{
    /// <summary>
    /// Identifies whether the GUIDs in the request refer to `ComponentDesign`s or `AnalysisSet`s. Ultimately, a
    /// `ComponentDesign` is being looked up either way. If `GuidType` == `AnalysisSet`, the `ComponentDesign` will be
    /// in the state it was in when that analysis occurred. If `GuidType` == `ComponentDesign`, the most recent state of
    /// the `ComponentDesign` will be used.
    /// </summary>
    public required GuidType GuidType { get; set; }

    /// <summary>
    /// For the <see cref="GuidType"/> specified above, this is a map of the GUIDs you want to download file(s) for, and
    /// a quantity for each.
    /// </summary>
    public required Dictionary<Guid, int> GuidToQuantity { get; set; }

    /// <summary>
    /// This will be included in the file name for the download, unless only one truss is specified, in which case the
    /// downloaded file will be named after that truss.
    /// </summary>
    public string? GroupName { get; set; }

    /// <summary>
    /// Generally you can only download components that belong to you or your organization. However, if you have access
    /// to a Shared Component Set, you can download components from that set by providing its lookup code here. If you
    /// do this, <see cref="GuidType"/> must be `AnalysisSet`, and those GUIDs must appear in the Shared Component Set.
    /// </summary>
    public string? SharedComponentSetLookupCode { get; set; }
}

public class DownloadMaterialReportRequest : DownloadRequest
{
    /// <summary>
    /// If a price is not found, this price will be used.
    /// </summary>
    public required double OverLengthPrice { get; set; }
}

public enum DownloadMachineryTrsRequestMemberTypes
{
    /// <summary>
    /// Include all member types
    /// </summary>
    All,

    /// <summary>
    /// Include top and bottom chords only
    /// </summary>
    Chords,

    /// <summary>
    /// Include webs only
    /// </summary>
    Webs,

    /// <summary>
    /// Include members which are not chords, not webs, and have only square cuts
    /// </summary>
    Blocks,
}

public class DownloadMachineryTrsRequest : DownloadRequest
{
    public required DownloadMachineryTrsRequestMemberTypes MemberType { get; set; }

    public double? MaxMemberLengthInInches { get; set; }
    public bool? IncludeMembersLongerThanMaxLengthInSeparateFile { get; set; }
}

public class DownloadShopDrawingsRequest : DownloadRequest
{
    public required ShopDrawingOptionsRequest Options { get; set; }

    /// <summary>
    /// If generating the shop drawings takes too long, they can be emailed to the requesting user instead of making
    /// them wait on the request. Only available to authenticated users; ignored for anonymous requests.
    /// </summary>
    public bool AllowEmail { get; set; }
}
