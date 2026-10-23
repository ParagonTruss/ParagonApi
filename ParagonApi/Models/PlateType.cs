namespace ParagonApi.Models;

// This enum mirrors PlateType in ComponentLibrary. Members must be kept in sync with that enum, and PublicApiTranslator
// translates between the two.
public enum PlateType
{
    M20,
    M16,
    M20HS,
    M18AHS,
    M18SHS,
    MII16,
    MII20,
    MII20HS,
    MT18HS,
    MT20HS,
    Eagle16,
    Eagle18,
    Eagle20,
    Eagle18HS,
    Eagle20HS,
    TL16,
    TL18,
    TL20,
    MT16,
    MT18,
    MT20,

    /// <summary>
    /// A MiTek hinge plate. Teeth are oriented parallel to the width direction, and alternate rows of 3 and 2 teeth
    /// instead of the standard columns.
    /// </summary>
    MTH18,

    /// <summary>
    /// A MiTek hinge plate. Teeth are oriented parallel to the width direction with two columns.
    /// </summary>
    SMH18,

    /// <summary></summary>
    /// <remarks>This is referred to as AS 18 in the evaluation report.</remarks>
    AS18HS,
    AS18S6,
    AS18S5,
    AS20,
    AS20HS,

    /// <summary>Alpine Wave Plate</summary>
    AlpineW,
    Alpine20H,

    /// <summary>Alpine Trulox nail plate</summary>
    AlpineT,

    /// <summary></summary>
    /// <remarks>This is referenced as simply SS in the evaluation report.</remarks>
    Alpine18SS,
    CH18,
    CH18HS,
    CH20,
    CH20S,
    CherokeeB,
    Any18,
    Any18HS,
    Any20,
    Any20HS,

    Combo16,
    Combo18,
    Combo18HS,
    Combo20,
    Combo20HS,
}
