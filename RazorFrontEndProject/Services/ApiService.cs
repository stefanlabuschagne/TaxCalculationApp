using System.Text;
using System.Text.Json;
using RazorFrontEndProject.Models;

namespace RazorFrontEndProject.Services
{
  public class ApiService : IApiService
  {
    public bool TaxCalculation(TaxInformation taxInfoModel)
    {
			using (HttpClient client = new HttpClient())
			{
				// Set the base address of the API
				client.BaseAddress = new Uri("http://localhost:5015");

				try
				{
					var taxInfoModelJson = new StringContent(
						JsonSerializer.Serialize(taxInfoModel),
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
						return true;
					}
					else
					{
						Console.WriteLine($"Error: {response.StatusCode}, {response.ReasonPhrase}");
						return false;
					}
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine($"Request error: {e.Message}");
					return false;
				}
			}
		}
  }
}
