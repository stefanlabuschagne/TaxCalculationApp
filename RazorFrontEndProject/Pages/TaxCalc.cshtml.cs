using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorFrontEndProject.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using RazorFrontEndProject.Services;

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
      using (HttpClient client = new HttpClient())
      {
        // Set the base address of the API
        client.BaseAddress = new Uri("http://localhost:5015");

        try
        {
          var taxInfoModelJson = new StringContent(
            JsonSerializer.Serialize(TaxInfoModel),
            Encoding.UTF8,
            "application/json");

          // Make a POST request
          HttpResponseMessage response = client.PostAsync("/TaxCalculation", taxInfoModelJson).Result;

          // Check if the response is successful
          if (response.IsSuccessStatusCode)
          {
            // Read and print the response content
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            //return true;
          }
          else
          {
            Console.WriteLine($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            //return false;
          }
        }
        catch (HttpRequestException e)
        {
          Console.WriteLine($"Request error: {e.Message}");
          //return false;
        }
      }

    }
  }
}
