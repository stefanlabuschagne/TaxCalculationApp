namespace BackendAPI.Models.TaxCalculation
{
    public class FlatValue : ITaxCalculation
    {
        private decimal _taxableamount;

        public decimal CalculateTax()
        {
            return _taxableamount < 200000 ? 2000000m * 0.05m : 10000;
        }

        public decimal TaxableAmount { set => _taxableamount = value; }

    }
}
