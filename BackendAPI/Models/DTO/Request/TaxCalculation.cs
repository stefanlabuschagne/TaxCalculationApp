using Microsoft.AspNetCore.Routing.Constraints;

namespace BackendAPI.Models.DTO.Request
{
    public class TaxCalculation
    {
        decimal Amount { get; set; }

        TaxType TaxType { get; set; }
    }

    enum TaxType
    {
        Flatrate,
        FlatValue,
        Progressive
    }
}
