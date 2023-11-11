namespace BackendAPI.Models.DTO.Response
{
	public class TaxCalcultionResponse
	{
		string Sucsess { get; set; }

		string ResponseMessage { get; set; }

		decimal TaxAmountDue{ get; set; }		
	}
}
