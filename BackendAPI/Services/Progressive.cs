namespace BackendAPI.Services;

public class Progressive : ITaxService
{
    private decimal _taxableamount;

    public Progressive(decimal taxableAmount)
    {
        _taxableamount = taxableAmount;
    }

    public decimal CalculateTax()
    {
        throw new NotImplementedException();
    }
}