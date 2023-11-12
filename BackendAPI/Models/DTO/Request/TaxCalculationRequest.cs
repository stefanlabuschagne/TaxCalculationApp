using Microsoft.AspNetCore.Routing.Constraints;

namespace BackendAPI.Models.DTO.Request
{
  public class TaxCalculationRequest
  {
    public decimal TaxableIncome { get; set; }

    public required string PostalCode { get; set; }
  }
}
