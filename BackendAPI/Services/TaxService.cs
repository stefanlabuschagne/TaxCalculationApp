namespace BackendAPI.Services
{
	public class TaxService : ITaxService : Iflat
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
			switch (_taxtype)

				case "1":
					
					break;

				case "2":
					break;

				case "3":
					break;

			// Inject EF to update the Database Here
			return _taxableamount * 0.2000m;
		}
	}
}
