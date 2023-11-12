using Microsoft.AspNetCore.Routing.Constraints;

namespace BackendAPI.Models.DTO.Request
{
  public class TaxCalculationRequest
  {
    public decimal TaxableIncome { get; set; }

    public string PostalCode { get; set; }
  }
}
