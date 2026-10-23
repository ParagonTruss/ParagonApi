using System.Globalization;

namespace ParagonApi.Connections;

public class LumberPricesConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<LumberPrice>> GetAll() => Client.Get<List<LumberPrice>>("api/public/lumberPrices");

    /// <summary>
    /// Gets the most recent price for each stock length of the given lumber.
    /// </summary>
    public Task<List<LumberPrice>> GetMostRecent(
        double nominalThicknessInInches,
        double nominalWidthInInches,
        LumberGrade grade,
        LumberSpecies species,
        LumberTreatmentType treatmentType
    ) =>
        Client.Get<List<LumberPrice>>(
            "api/public/lumberPrices/mostRecent"
                + $"?nominalThicknessInInches={nominalThicknessInInches.ToString(CultureInfo.InvariantCulture)}"
                + $"&nominalWidthInInches={nominalWidthInInches.ToString(CultureInfo.InvariantCulture)}"
                + $"&grade={grade}&species={species}&treatmentType={treatmentType}"
        );

    public Task<LumberPrice> Insert(NewLumberPrice newLumberPrice) =>
        Client.Post<NewLumberPrice, LumberPrice>("api/public/lumberPrices", newLumberPrice);

    public Task<List<LumberPrice>> BulkInsert(List<NewLumberPrice> newLumberPrices) =>
        Client.Post<List<NewLumberPrice>, List<LumberPrice>>("api/public/lumberPrices/bulk", newLumberPrices);

    public Task<LumberPrice> Update(LumberPriceEdit lumberPriceEdit) =>
        Client.Put<LumberPriceEdit, LumberPrice>("api/public/lumberPrices", lumberPriceEdit);

    public Task<List<LumberPrice>> BulkUpdate(List<LumberPriceEdit> lumberPriceEdits) =>
        Client.Put<List<LumberPriceEdit>, List<LumberPrice>>("api/public/lumberPrices/bulk", lumberPriceEdits);
}
