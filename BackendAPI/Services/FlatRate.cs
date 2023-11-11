namespace BackendAPI.Services
{
    public class FlatRate : ITaxService
    {
        private decimal _taxableamount;

        public FlatRate(decimal taxableAmount)
        {
            _taxableamount = taxableAmount;
        }

        public decimal CalculateTax()
        {
            return _taxableamount * 0.175m;
        }
    }
}
