namespace BackendAPI.Services
{
	public interface ITaxService
	{
		public bool CalculateTax(decimal taxableAmount, string postalCode);
	}
}