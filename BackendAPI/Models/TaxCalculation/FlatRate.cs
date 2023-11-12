namespace BackendAPI.Models.TaxCalculation
{
  public class FlatRate : ITaxCalculation
  {
    private decimal _taxableamount;

    decimal ITaxCalculation.TaxableAmount { set => _taxableamount = value; }

    public decimal CalculateTax()
    {
        return _taxableamount * 0.175m;
    }
  }
}
