using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorFrontEndProject.Models
{
	public class TaxInformation : ITaxInformation
	{
		[BindProperty]
		[Required]
		public required string PostalCode { get; set; }

		[BindProperty]
		[Required]
		[DefaultValue(0)]
		[Range(0, double.MaxValue, ErrorMessage = "Enter a positive value")]
		public decimal TaxableIncome { get; set; }
	}
}
