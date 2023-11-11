namespace BackendAPI.Data.Domain
{
	public class TaxRecord
	{
		public int Id { get; set; }

		public DateTime TimeCalculated { get; set; }

		public double TaxableAmount { get; set; }

		public string TaxType { get; set; }

		public double TaxCalculated { get; set; }
	}
}
