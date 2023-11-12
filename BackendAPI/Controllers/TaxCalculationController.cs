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
		private readonly IUnitOfWork _unitofwork;

		public TaxCalculationController(ILogger<TaxCalculationController> logger, IUnitOfWork unitOfWork, ITaxService taxService)
		{
			_logger = logger;
			_unitofwork = unitOfWork;
			_taxService = taxService;
		}

		[HttpPost(Name = "CalculateTax")]
		public IActionResult HttpPost([FromBody] TaxCalculationRequest taxCalculationRequest)
		{
			if (taxCalculationRequest == null)  
				return new BadRequestResult(); 

			_taxService.CalculateTax(taxCalculationRequest.TaxableIncome,taxCalculationRequest.PostalCode);

			//_unitofwork.TaxRecord.Add(new Domain.Entities.TaxRecord() { TaxableAmount=100000, TaxType="Progressive" });

			return new OkResult(); 
		}

		[HttpGet(Name = "GetAllRecords")]
		public List<TaxCalcultionResponse> HttpGet()
		{
			_unitofwork.TaxRecord.GetAll();
			return new List<TaxCalcultionResponse>();
		}
	}
}
