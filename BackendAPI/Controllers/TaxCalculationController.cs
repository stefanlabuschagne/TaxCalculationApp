﻿using BackendAPI.Models.DTO.Request;
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

		public TaxCalculationController(ILogger<TaxCalculationController> logger, ITaxService taxservice)
		{
			_logger = logger;
			_taxService = taxservice;
		}

		[HttpPost(Name = "CalculateTax")]
		public TaxCalcultionResponse HttpPost([FromBody] TaxCalculationRequest taxCalculationRequest)
		{
			// call the Repository Service that was injected into the 

			// _taxService.CalculateTax();

			return new TaxCalcultionResponse(); 

		}
	}
}
