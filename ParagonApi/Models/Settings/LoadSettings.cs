namespace ParagonApi.Models;

public class LoadSettings
{
    #region Live and Dead
    /// <summary>
    /// In PSF
    /// </summary>
    public required double RoofTopChordLiveLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double RoofTopChordDeadLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double OverhangDeadLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double RoofBottomChordLiveLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double RoofBottomChordDeadLoad { get; set; }

    public required bool ApplyBottomChordLiveLoadNonConcurrently { get; set; }

    public required bool ConsiderUnbalancedRoofLiveLoad { get; set; }

    public required bool AddHalfWeightOfTrussToRoofBCDeadLoad { get; set; }

    public required bool AddHalfWeightOfTrussToRoofTCDeadLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double FloorTopChordLiveLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double FloorTopChordDeadLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double FloorBottomChordLiveLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double FloorBottomChordDeadLoad { get; set; }

    public required bool AddHalfWeightOfTrussToFloorBCDeadLoad { get; set; }

    public required bool AddHalfWeightOfTrussToFloorTCDeadLoad { get; set; }

    public required bool ConsiderUnbalancedFloorLiveLoad { get; set; }
    #endregion

    #region Wind and Snow
    public required TerrainExposureCategory TerrainExposureCategory { get; set; }
    #endregion

    #region Wind
    public required bool UseWind { get; set; }

    /// <summary>
    /// In MPH
    /// </summary>
    public required double WindSpeed { get; set; }

    public required EnclosureClassification EnclosureClassification { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double MeanRoofHeight { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double BuildingWidth { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double BuildingLength { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double? MaxTopChordDeadLoadForUpliftOverride { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double? MaxBottomChordDeadLoadForUpliftOverride { get; set; }

    public required bool IsRightCantileverExposed { get; set; }

    public required bool IsLeftCantileverExposed { get; set; }

    public required bool IsRightPorchExposed { get; set; }

    public required bool IsLeftPorchExposed { get; set; }

    public required bool IsRightEndVerticalExposed { get; set; }

    public required bool IsLeftEndVerticalExposed { get; set; }

    public required WindDesignMethod WindDesignMethod { get; set; }

    public required double WindDirectionalityFactor { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double HorizontalDistanceToWindwardEdge { get; set; }

    public required double WindTopographicFactor { get; set; }

    public required double GroundElevationFactor { get; set; }

    public required double WindGustEffectFactor { get; set; }

    public required RoofShape RoofShape { get; set; }

    public required bool UseSlopedTopChordAngleForFlatTopChords { get; set; }

    /// <summary>
    /// In degrees
    /// </summary>
    public required double AngleForFlatTopChords { get; set; }
    #endregion

    #region Tornado
    public required bool UseTornado { get; set; }

    /// <summary>
    /// In MPH
    /// </summary>
    public required double TornadoSpeed { get; set; }

    public required double TornadoGustEffectFactor { get; set; }

    public required bool ReclassifyEnclosedAsPartiallyEnclosedForTornadoLoads { get; set; }

    public required bool EssentialFacilityOrNecessaryThereto { get; set; }
    #endregion

    #region Snow
    public required bool UseSnow { get; set; }

    public required ActiveSnowLoad ActiveSnowLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double SnowLoad { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double EaveToRidgeDistance { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double SnowFetchDistancePerpendicularToTruss { get; set; }

    public required Exposure Exposure { get; set; }

    public required RiskCategory RiskCategory { get; set; }

    public required ThermalCondition ThermalCondition { get; set; }

    public required bool SlipperyRoof { get; set; }

    public required bool IsSawtoothRoof { get; set; }

    public required bool IncludeDriftLoads { get; set; }
    #endregion

    #region Attic
    public required bool ConsiderAtticLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double AtticFloorLiveLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double AtticFloorDeadLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double AtticWallDeadLoad { get; set; }

    /// <summary>
    /// In PSF
    /// </summary>
    public required double AtticCeilingDeadLoad { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double AtticRoomWidth { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double AtticRoomHeight { get; set; }
    #endregion

    #region Drag
    public required bool ConsiderDragLoad { get; set; }

    public required double TotalDragLoad { get; set; }

    public required DragLoadUnit DragLoadUnit { get; set; }

    public required bool DragLoadTakenOutOnTopChord { get; set; }

    public required bool DragLoadTakenOutLeftSide { get; set; }

    public required List<BCRestraintLocations>? BCRestraintLocations { get; set; }
    #endregion

    #region Sprinkler
    public required bool ConsiderSprinklerLoad { get; set; }

    /// <summary>
    /// In pounds
    /// </summary>
    public required double SprinklerLiveLoad { get; set; }

    public required bool ApplySprinklerAlongTC { get; set; }

    public required bool ApplySprinklerAlongBC { get; set; }
    #endregion

    #region Moving Office
    public required bool ConsiderMovingOfficeLoad { get; set; }

    /// <summary>
    /// In pounds
    /// </summary>
    public required double MovingOfficeLoad { get; set; }

    /// <summary>
    /// In feet
    /// </summary>
    public required double MovingOfficeLoadLength { get; set; }
    #endregion

    #region Storage
    public required bool? OneOrTwoFamilyDwelling { get; set; }

    public required bool UseFullStorageLoad { get; set; }
    #endregion
}

public class BCRestraintLocations
{
    public required bool FromLeft { get; set; }

    /// <summary>
    /// In inches
    /// </summary>
    public required double StartPoint { get; set; }

    /// <summary>
    /// In inches
    /// </summary>
    public required double EndPoint { get; set; }
}

public enum TerrainExposureCategory
{
    B_SuburbanAreas,
    C_ScatteredObstructions,
    D_FlatOpenTerrain,
}

public enum EnclosureClassification
{
    Enclosed,
    PartiallyEnclosed,
    PartiallyOpen,
    Open,
}

public enum WindDesignMethod
{
    WindUserDef,
    WindNotDefined,
    WindAsceCc,
    WindHudCc,
    WindAsceMwfrsEnvelope,
    WindAsceMwfrsDirectional,
    WindAsceHybridEnvelope,
    WindAsceHybridDirectional,
    WindNbccCc,
    WindNbccMwfrs,
}

public enum RoofShape
{
    Gable,
    Hip,
    Stepped,
    MultispanGable,
    Monoslope,
    Sawtooth,
}

public enum ActiveSnowLoad
{
    Ground,
    Roof,
}

public enum Exposure
{
    FullyExposed,
    PartiallyExposed,
    Sheltered,
}

public enum RiskCategory
{
    I,
    II,
    III,
    IV,
}

public enum ThermalCondition
{
    Other,
    ColdVented,
    Unheated,
    FreezerBuilding,
    Greenhouse,
}

public enum DragLoadUnit
{
    Pounds,
    Plf,
}
