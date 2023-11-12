using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorFrontEndProject.Models
{
  public class TaxInformation
  {
    [BindProperty]
    [Required]
    public string PostalCode { get; set; }

    [BindProperty]
    [Required]
    [DefaultValue(0)]
    public decimal TaxableIncome { get; set; }
  }
}
