namespace BackendAPI.Models.DTO.Response
{
	public class TaxCalculationResponse
	{
		public required string Sucsess { get; set; }

		public required string ResponseMessage { get; set; }

		public decimal TaxAmountDue { get; set; }
	}
}
