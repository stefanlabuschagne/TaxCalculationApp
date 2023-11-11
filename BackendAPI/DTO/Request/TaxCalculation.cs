using Microsoft.AspNetCore.Routing.Constraints;

namespace BackendAPI.DTO.Request
{
    public class TaxCalculation
    {
		Decimal Amount { get; set; }

		TaxType TaxType { get; set; }
    }

	enum TaxType
	{ 	
		Flatrate,
		FlatValue,
		Progressive
	}
}
