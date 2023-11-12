using BackendAPI.Data.Context;
using BackendAPI.Services.Factory;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackendAPI.Services
{
    // Repository pattern
    // for the thin controller
    public class TaxService : ITaxService
	{

		public decimal _taxableamount;
		public string _taxtype;
		public ITaxCalculatorFactory _taxCalculatorFactory;
		public TaxDbContext _dbContext;

		public TaxService()
		{
			// _dbContext = new TaxDbContext();
		}

		public decimal CalculateTax()
		{

			//var a = _taxCalculatorFactory.CalcuateTaxRateBasedOnType(_taxtype);
			//a.TaxableAmount = _taxableamount;
			//var b = a.CalculateTax();

			//_dbContext.Add();
			//_dbContext.SaveChangesAsync();

			// Inject EF to update the Database Here

			decimal d = 1000;

			return d; //  b;
		}
	}
}
