namespace BackendAPI.Models.TaxCalculation
{
  public interface ITaxCalculation
  {
    public decimal TaxableAmount { set; }

    public decimal CalculateTax();
  }
}
