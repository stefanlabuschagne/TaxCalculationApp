using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RazorFrontEndProject.Configuration;
using RazorFrontEndProject.Models;

namespace RazorFrontEndProject.Services
{
  public class ApiService : IApiService
  {
		private readonly HttpClient _httpClient;
		private readonly ApiServiceConfig _config;

		public ApiService(
			HttpClient httpClient,
			IOptions<ApiServiceConfig> config)
				{
					_httpClient = httpClient;
					_config = config.Value;
				}

		public bool TaxCalculation(ITaxInformation taxInfoModel)
    {
			using (_httpClient)
			{
				// Set the base address of the API as specified in Appsettings.Json
				// _httpClient.BaseAddress = new Uri(_config.Url);

				try
				{
					var taxInfoModelJson = new StringContent(
						JsonSerializer.Serialize(taxInfoModel),
						Encoding.UTF8,
						"application/json");

					// Make a POST request
					HttpResponseMessage response = _httpClient.PostAsync(string.Concat(_config.Url.ToString(), "/TaxCalculation"), taxInfoModelJson).Result;

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
