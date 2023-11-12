using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorFrontEndProject.Models;
using RazorFrontEndProject.Services;

namespace RazorFrontEndProject.Pages
{
	public class TaxCalcModel : PageModel
  {
    private IApiService _apiService;

		public TaxCalcModel(IApiService apiService)
		{
      _apiService = apiService;
		}

		public void OnGet()
    {
    }

		public void OnPost(TaxInformation taxInfoModel)
		{
			if (!ModelState.IsValid)
				return;

			// Logic for handling POST requests
			// Access posted values using the Request.Form collection or model binding

			// Call API to update the database
			if (_apiService.TaxCalculation(taxInfoModel))
				return;

			return;
		}
	}
}
