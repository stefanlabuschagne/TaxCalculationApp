using System.ComponentModel.DataAnnotations;
using BackendAPI.Domain.Repository;

namespace BackendAPI.Domain.Entities
{
    public class TaxRecord
	{
		[Key]
		public int Id { get; set; }

		public DateTime TimeCalculated { get; set; }

		public double TaxableAmount { get; set; }

		public string TaxType { get; set; }

		public double TaxCalculated { get; set; }
	}
}
