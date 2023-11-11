using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TaxCalculationController : Controller
	{

		private readonly ILogger<TaxCalculationController> _logger;

		public TaxCalculationController(ILogger<TaxCalculationController> logger)
		{
			_logger = logger;
		}


		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
