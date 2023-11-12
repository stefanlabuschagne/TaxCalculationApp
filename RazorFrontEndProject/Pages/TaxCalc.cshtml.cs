using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorFrontEndProject.Models;

namespace RazorFrontEndProject.Pages
{
    public class TaxCalcModel : PageModel
    {
      public void OnGet()
      {


      }

    public void OnPost(TaxInformation TaxInfoModel)
    {
      // Logic for handling POST requests
      // Access posted values using the Request.Form collection or model binding


      // Call API to update the database

    }
  }
}
