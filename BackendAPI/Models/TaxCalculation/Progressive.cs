using System.Diagnostics.CodeAnalysis;

namespace BackendAPI.Models.TaxCalculation;

public class Progressive : ITaxCalculation
{
    private decimal _taxableamount;

    decimal ITaxCalculation.TaxableAmount { set => _taxableamount = value; }

    public decimal CalculateTax()
    {
      if (_taxableamount >= 372951)
        return ((_taxableamount - 372950) * 0.35m) + 108216;

      if (_taxableamount >= 171551)
        return _taxableamount - (_taxableamount - 171550) * 0.33m + 41754;

      if (_taxableamount >= 82251)
        return _taxableamount - (_taxableamount - 82250) * 0.28m + 16750;

      if (_taxableamount >= 33951)
        return _taxableamount - (_taxableamount - 33950) * 0.25m + 4675;

      if (_taxableamount >= 8351)
        return _taxableamount - (_taxableamount - 8350) * 0.15m + 835;

      if (_taxableamount >= 0)
        return _taxableamount - _taxableamount * 0.10m + 0;

      return 0;
    }
}