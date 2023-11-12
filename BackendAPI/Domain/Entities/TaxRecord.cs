using System.ComponentModel.DataAnnotations;
using BackendAPI.Domain.Repository;

namespace BackendAPI.Domain.Entities
{
    public class TaxRecord
	{
		[Key]
		public int Id { get; set; }

		public DateTime TimeCalculated { get; set; }

		public decimal TaxableAmount { get; set; }

		public string PostalCode { get; set; }

		public decimal TaxCalculated { get; set; }
	}
}
