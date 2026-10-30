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

public class DownloadTrussDesignDrawingsRequest : DownloadRequest
{
    /// <summary>
    /// The template to draw with. Defaults to your organization's system template. Ignored for anonymous requests and
    /// free subscriptions, which always receive dark, non-printable drawings, or drawings made with the system repair
    /// template for repairs.
    /// </summary>
    public int? TemplateId { get; set; }

    /// <summary>
    /// The template to use for the pages after the first one. Defaults to your organization's system overflow template.
    /// Unused for repair drawings, which are always one page.
    /// </summary>
    public int? OverflowTemplateId { get; set; }

    /// <summary>
    /// Draw with the repair template rather than the standard one.
    /// </summary>
    public bool UseRepairTemplate { get; set; }

    /// <summary>
    /// Merge every drawing into one PDF instead of returning a zip containing one PDF per component. Ignored when only
    /// one component is requested, since that is a single PDF either way.
    /// </summary>
    public bool MergeIntoOnePdf { get; set; }

    /// <summary>
    /// Leave the analysis warning text off of the drawings. Repair drawings never include it, so this has no effect on
    /// them.
    /// </summary>
    public bool IgnoreErrors { get; set; }

    /// <summary>
    /// Produce dark, non-printable drawings. This is the only kind of drawing available to anonymous requests and free
    /// subscriptions, which get them whether or not this is set. Repair drawings are never dark, so this has no effect on
    /// them.
    /// </summary>
    public bool ForceDarkMode { get; set; }

    /// <summary>
    /// The job name printed on each component's drawing, keyed like <see cref="DownloadRequest.GuidToQuantity"/>. Any
    /// component missing from this is printed with <see cref="DownloadRequest.GroupName"/> instead.
    /// </summary>
    public Dictionary<Guid, string>? GuidToJobName { get; set; }

    /// <summary>
    /// The project the components are being drawn for. The drawings' QR codes link to a Shared Component Set, and this
    /// is recorded on that set so that whoever imports from it knows where the components came from. The project must
    /// belong to your organization. Ignored if <see cref="DownloadRequest.SharedComponentSetLookupCode"/> is provided,
    /// since in that case the drawings link to that Shared Component Set if it has exactly the requested components at
    /// the requested quantities or if it belongs to another organization. Otherwise they link to a new set which keeps
    /// that set's source project and contact information, along with its snapshot filtered down to the requested
    /// components.
    /// </summary>
    public Guid? ProjectGuid { get; set; }

    /// <summary>
    /// Also include a snapshot of <see cref="ProjectGuid"/>'s hierarchy and layout in that Shared Component Set, so
    /// that whoever scans a QR code can see the layout the components came from. Ignored without a
    /// <see cref="ProjectGuid"/>. The system repair template has no QR code, so leave this off for repair drawings.
    /// </summary>
    public bool ShareLayout { get; set; }
}
