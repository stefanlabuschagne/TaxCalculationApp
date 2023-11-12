using BackendAPI.Data.Implementation;
using BackendAPI.Domain.Repository;
using BackendAPI.Models.DTO.Request;
using BackendAPI.Models.DTO.Response;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
  [ApiController]
	[Route("[controller]")]
	public class TaxCalculationController : Controller
	{
		private readonly ILogger<TaxCalculationController> _logger;
		private readonly ITaxService _taxService;

		public TaxCalculationController(ILogger<TaxCalculationController> logger, ITaxService taxService)
		{
			_logger = logger;
			_taxService = taxService;
		}

		[HttpPost(Name = "CalculateTax")]
		public IActionResult HttpPost([FromBody] TaxCalculationRequest taxCalculationRequest)
		{
			if (taxCalculationRequest == null)
				return new BadRequestResult();

			if (_taxService.CalculateTax(taxCalculationRequest.TaxableIncome, taxCalculationRequest.PostalCode))
				return new OkObjectResult(new TaxCalculationResponse()
				{
					Sucsess = "True",
					ResponseMessage = "Your tax was calculated and added to the database",
				});

			return new BadRequestResult();
		}
	}
}
