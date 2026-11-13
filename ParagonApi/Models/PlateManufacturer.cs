using System.Text.Json.Serialization;

namespace ParagonApi.Models;

// This enum mirrors PlateManufacturer in ComponentLibrary. Members and their JSON names must be kept in sync with that
// enum, and PublicApiTranslator translates between the two.
public enum PlateManufacturer
{
    MiTek,
    Eagle,
    Alpine,
    Simpson,

    [JsonStringEnumMemberName("CH Machine")]
    CH_Machine,

    [JsonStringEnumMemberName("Cherokee Metal")]
    Cherokee_Metal,

    /// <summary>AnyPlate aggregate plates</summary>
    Any,

    Combo,
}
