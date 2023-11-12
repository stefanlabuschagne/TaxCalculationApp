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
		// private readonly ITaxService _taxService;
		private readonly IUnitOfWork _unitofwork;

		public TaxCalculationController(ILogger<TaxCalculationController> logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			_unitofwork = unitOfWork;
		}

		[HttpPost(Name = "CalculateTax")]
		public TaxCalcultionResponse HttpPost([FromBody] TaxCalculationRequest taxCalculationRequest)
		{
			_unitofwork.TaxRecord.Add(new Domain.Entities.TaxRecord() { TaxableAmount=1000 });
			return new TaxCalcultionResponse(); 
		}
	}
}
