using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorFrontEndProject.Models;
using System.Net.Http;

namespace RazorFrontEndProject.Pages
{
    public class TaxCalcModel : PageModel
    {
      public void OnGet()
      {


      }

    public async void OnPost(TaxInformation TaxInfoModel)
    {
      // Logic for handling POST requests
      // Access posted values using the Request.Form collection or model binding


      // Call API to update the database
      // Create an instance of HttpClient
      using (HttpClient client = new HttpClient())
      {
        // Set the base address of the API
        client.BaseAddress = new Uri("http://localhost:5015");

        try
        {
          // Make a GET request
          HttpResponseMessage response = await client.PostAsync("/CalculateTax", TaxInfoModel);

          // Check if the response is successful
          if (response.IsSuccessStatusCode)
          {
            // Read and print the response content
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
          }
          else
          {
            Console.WriteLine($"Error: {response.StatusCode}, {response.ReasonPhrase}");
          }
        }
        catch (HttpRequestException e)
        {
          Console.WriteLine($"Request error: {e.Message}");
        }
      }

    }
  }
}
