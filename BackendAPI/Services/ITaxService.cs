namespace BackendAPI.Services
{
	public interface ITaxService
	{
		public bool CalculateTax(decimal TaxableAmount, string PostalCode);
	}
}