namespace BackendAPI.Models.TaxCalculation
{
    public class FlatValue : ITaxCalculation
    {
        private decimal _taxableamount;

        public decimal CalculateTax()
        {
          if (_taxableamount < 200000)
            return _taxableamount * 0.05m;

          return 10000;
        }

        public decimal TaxableAmount { set => _taxableamount = value; }
    }
}
