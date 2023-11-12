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
		public int _taxtype;

		private ITaxCalculatorFactory _taxCalculatorFactory;
		private TaxDbContext _dbContext;

		public TaxService(TaxDbContext dbc, ITaxCalculatorFactory tcf)
		{
			_dbContext = dbc;
			_taxCalculatorFactory = tcf;			
		}

		public decimal CalculateTax()
		{
			var z = (BackendAPI.Models.DTO.Request.TaxType) 1;

			var a = _taxCalculatorFactory.CalcuateTaxRateBasedOnType( z );
			a.TaxableAmount = 100000000; // _taxableamount;
			var b = a.CalculateTax();

			//_dbContext.Add();
			//_dbContext.SaveChangesAsync();

			// Inject EF to update the Database Here

			decimal d = 1000;

			return d; //  b;
		}
	}
}
