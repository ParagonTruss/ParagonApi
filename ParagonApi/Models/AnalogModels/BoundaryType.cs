namespace ParagonApi.Models.AnalogModels;

public enum BoundaryType
{
    Unrestrained,
    HorizontalRoller,
    HorizontalRollerWithUpwardRelease,
    VerticalRoller,
    Pinned,
    PinnedWithUpwardRelease,
    Fixed,
    RotationFixed,
    XAndRotationFixed,
    YAndRotationFixed,
}
