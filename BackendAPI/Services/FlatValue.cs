namespace BackendAPI.Services
{
	public class FlatValue : ITaxService
	{
		private decimal _taxableamount;

		public FlatValue(decimal taxableAmount )
		{
			_taxableamount = taxableAmount;
		}

		public decimal CalculateTax()
		{
			return _taxableamount < 200000 ? (2000000m * 0.05m) : 10000;
		}
	}
}
