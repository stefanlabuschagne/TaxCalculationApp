namespace BackendAPI.Models.TaxCalculation;

public class Progressive : ITaxCalculation
{
    private decimal _taxableamount;

    decimal ITaxCalculation.TaxableAmount { set => _taxableamount = value; }

    public decimal CalculateTax()
    {
        return _taxableamount >= 372951 ?
            _taxableamount - 372950 * 0.35m + 108216 :

        _taxableamount >= 171551 ?
            _taxableamount - (_taxableamount - 171550) * 0.33m + 41754 :

        _taxableamount >= 82251 ?
            _taxableamount - (_taxableamount - 82250) * 0.28m + 16750 :

        _taxableamount >= 33951 ?
            _taxableamount - (_taxableamount - 33950) * 0.25m + 4675 :

        _taxableamount >= 8351 ?
            _taxableamount - (_taxableamount - 8350) * 0.15m + 835 :

        _taxableamount >= 0 ?
            _taxableamount - _taxableamount * 0.10m + 0 : 0;
    }
}