// ReSharper disable UnusedMember.Global

namespace ParagonApi.Models;

// These enums mirror the lumber enums in ComponentLibrary.SharedModels. Members must be kept in sync with those
// enums, and PublicApiTranslator translates between the two.

/// <summary>
/// Chemical or fire-retardant treatments applied to lumber.
/// </summary>
public enum LumberTreatmentType
{
    Untreated,

    // Fire treatment
    FireRetardantUnknown,
    FirePro,
    Dricon,
    PyroGuard,
    DBlaze,

    // Other treatment
    MCA,
    MCQ,
    Preservative,
    IncisedPreservative,
    ACQ,
    Borate,
}

/// <summary>
/// <para>Lumber grades, including visual grades, machine stress rated (MSR) and machine evaluated lumber (MEL)
/// grades, and grades of engineered wood.</para>
/// <para>
/// MSR grades are classified by bending strength (Fb) and modulus of elasticity (E); MEL grades are classified by
/// a grade code.
/// </para>
/// </summary>
public enum LumberGrade
{
    // Visual Grades
    Dense_Select_Structural,
    Select_Structural,
    Select_Structural_Open_Grain,
    Select_And_Better,
    Non_Dense_Select_Structural,
    Dense_Number_1,
    Dense_Number_2,
    Dense_Number_3,
    Number_1_And_Better,
    Number_2_And_Better,
    Number_1,
    Number_2,
    Number_3,
    Number_1_Open_Grain,
    Number_2_Open_Grain,
    Number_3_Open_Grain,
    Non_Dense_Number_1,
    Non_Dense_Number_2,
    Non_Dense_Number_3,
    Number_1_And_2,
    Stud,
    Construction,
    Standard,
    Utility,
    Clear_Structural,
    Economy,

    // Structural Composite LFL
    LFL_1_6E,
    LFL_1_7E,
    LFL_1_9E,
    LFL_2_1E,

    // Structural Composite LVL
    LVL_1_3E,
    LVL_1_5E,
    LVL_1_8E,
    LVL_2_0E,
    LVL_2_2E,
    LVL_2_3E,

    // Structural Composite LSL
    LSL_1730F_1_35E,
    LSL_2360F_1_55E,
    LSL_2500F_1_75E,

    // Machine Stress Rated
    MSR_750f_1_4E,
    MSR_850f_1_4E,
    MSR_900f_1_0E,
    MSR_975f_1_6E,
    MSR_1050f_1_2E,
    MSR_1050f_1_6E,
    MSR_1200f_1_2E,
    MSR_1200f_1_3E,
    MSR_1200f_1_6E,
    MSR_1250f_1_4E,
    MSR_1250f_1_6E,
    MSR_1350f_1_3E,
    MSR_1350f_1_4E,
    MSR_1400f_1_2E,
    MSR_1450f_1_3E,
    MSR_1450f_1_5E,
    MSR_1500f_1_4E,
    MSR_1500f_1_5E,
    MSR_1500f_1_6E,
    MSR_1500f_1_7E,
    MSR_1600f_1_4E,
    MSR_1650f_1_3E,
    MSR_1650f_1_5E,
    MSR_1650f_1_6E,
    MSR_1650f_1_7E,
    MSR_1700f_1_6E,
    MSR_1800f_1_5E,
    MSR_1800f_1_6E,
    MSR_1800f_1_8E,
    MSR_1800f_2_0E,
    MSR_1850f_1_7E,
    MSR_1950f_1_5E,
    MSR_1950f_1_7E,
    MSR_2000f_1_6E,
    MSR_2100f_1_8E,
    MSR_2250f_1_7E,
    MSR_2250f_1_8E,
    MSR_2250f_1_9E,
    MSR_2400f_1_8E,
    MSR_2400f_2_0E,
    MSR_2500f_2_2E,
    MSR_2550f_1_8E,
    MSR_2550f_2_1E,
    MSR_2700f_2_0E,
    MSR_2700f_2_2E,
    MSR_2850f_1_8E,
    MSR_2850f_2_3E,
    MSR_3000f_2_4E,

    // Machine Evaluated Lumber
    MEL_M_5,
    MEL_M_6,
    MEL_M_7,
    MEL_M_8,
    MEL_M_9,
    MEL_M_10,
    MEL_M_11,
    MEL_M_12,
    MEL_M_13,
    MEL_M_14,
    MEL_M_15,
    MEL_M_16,
    MEL_M_17,
    MEL_M_18,
    MEL_M_19,
    MEL_M_20,
    MEL_M_21,
    MEL_M_22,
    MEL_M_23,
    MEL_M_24,
    MEL_M_25,
    MEL_M_26,
    MEL_M_27,
    MEL_M_28,
    MEL_M_29,
    MEL_M_30,
    MEL_M_31,
    MEL_M_32,
    MEL_M_33,
    MEL_M_34,
    MEL_M_35,
    MEL_M_36,
    MEL_M_37,
    MEL_M_38,
    MEL_M_39,
    MEL_M_40,
    MEL_M_41,
    MEL_M_42,

    MasterPlank,

    Kerto_S_2_0E,

    Unknown,

    Combo,
}

/// <summary>
/// <para>Lumber species or species combinations, or types of engineered wood.</para>
/// <para>
/// Species combinations are species that are grouped together because distinguishing them may not be worthwhile.
/// </para>
/// </summary>
/// <remarks>
/// This enum includes (but is not limited to) all the species and species combinations in NDS 2018 that have design
/// values for dimension lumber (2-4" nominal thickness).
/// The species combination definitions are given in NDS Supplement Section 2.1.
/// </remarks>
public enum LumberSpecies
{
    /// <summary></summary>
    /// <remarks>Also known as "Southern Yellow Pine"</remarks>
    Southern_Pine,
    Mixed_Southern_Pine,
    Alaska_Cedar,
    Alaska_Hemlock,
    Alaska_Spruce,
    Alaska_Yellow_Cedar,
    Aspen,

    /// <remarks>
    /// The orthography used here is found in some sources, including the SPIB grading rules. The NDS Supplement and
    /// DOC PS 20 Appendix A, as well as other sources, spell it as a single word.
    /// </remarks>
    Bald_Cypress,
    Beech_Birch_Hickory,
    Coast_Sitka_Spruce,
    Cottonwood,
    Douglas_Fir_Larch,
    Douglas_Fir_Larch_North,
    Douglas_Fir_South,
    Eastern_Hemlock_Balsam_Fir,
    Eastern_Hemlock_Tamarack,
    Eastern_Softwoods,
    Eastern_White_Pine,
    Engelmann_Spruce_Lodgepole_Pine,
    Hem_Fir,
    Hem_Fir_North,
    Mixed_Maple,
    Mixed_Oak,
    Northern_Red_Oak,
    Northern_Species,
    Northern_White_Cedar,
    Norway_Spruce_North,
    Ponderosa_Pine,
    Red_Maple,
    Red_Oak,
    Redwood,
    Spruce_Pine_Fir,
    Spruce_Pine_Fir_South,
    Western_Cedars,
    Western_Juniper,
    Western_Woods,
    White_Oak,

    /// <remarks>
    /// This species is not included in the NDS Supplement but is named in DOC PS 20 Appendix A.
    /// </remarks>
    White_Fir,
    Yellow_Cedar,
    Yellow_Poplar,

    // Structural Composites
    MasterPlank_LVL,
    RigidLam_LVL,
    Parallam_PSL,
    VersaLam_LVL,

    GPLam_LVL,

    LP_LVL,

    BC_OSB,

    LP_SolidStart_LSL,

    KSLVL,
    Unknown,

    Combo,
}
