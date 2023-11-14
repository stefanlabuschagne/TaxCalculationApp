namespace RazorFrontEndProject.Models
{
	public interface ITaxInformation
	{
		string PostalCode { get; set; }
		decimal TaxableIncome { get; set; }
	}
}