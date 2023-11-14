using System.Text;
using System.Text.Json;
using RazorFrontEndProject.Models;

namespace RazorFrontEndProject.Services
{
  public class ApiService : IApiService
  {
		private HttpClient _httpClient;

		public ApiService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public bool TaxCalculation(ITaxInformation taxInfoModel)
    {
			using (_httpClient)
			{
				// Set the base address of the API
				_httpClient.BaseAddress = new Uri("http://localhost:5015");

				try
				{
					var taxInfoModelJson = new StringContent(
						JsonSerializer.Serialize(taxInfoModel),
						Encoding.UTF8,
						"application/json");

					// Make a POST request
					HttpResponseMessage response = _httpClient.PostAsync("/TaxCalculation", taxInfoModelJson).Result;

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
