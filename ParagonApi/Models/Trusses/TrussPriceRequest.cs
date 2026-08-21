namespace ParagonApi.Models;

public class TrussPriceRequest
{
    /// <summary>
    /// Prices for custom hangers, by hanger name.  Custom hangers have no price of their own, so any custom hanger
    ///   left out here is reported as missing a price.
    /// </summary>
    public Dictionary<string, double>? CustomHangerHardwarePrices { get; set; }
}
