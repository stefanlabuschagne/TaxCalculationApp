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
    [Range(0,int.MaxValue,ErrorMessage ="Enter a positive value")]
    public decimal TaxableIncome { get; set; }
  }
}
