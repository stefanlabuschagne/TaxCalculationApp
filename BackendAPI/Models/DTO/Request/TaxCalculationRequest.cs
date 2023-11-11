using Microsoft.AspNetCore.Routing.Constraints;

namespace BackendAPI.Models.DTO.Request
{
    public class TaxCalculationRequest
    {
        decimal Amount { get; set; }

        TaxType TaxType { get; set; }
    }

    public enum TaxType
    {
        Flatrate,
        FlatValue,
        Progressive
    }
}
