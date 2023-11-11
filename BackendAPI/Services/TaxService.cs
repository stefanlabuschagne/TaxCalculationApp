namespace BackendAPI.Services
{
	public class TaxService : ITaxService
	{
		decimal _taxableamount;
		string _taxtype;

		public TaxService(decimal taxableAmount, string taxType)
		{
			_taxableamount = taxableAmount;
			_taxtype = taxType;
		}

		public decimal CalculateTax()
		{ 
			// Inject EF to update the Database Here
			return _taxableamount * 0.2000m;
		}
	}
}
