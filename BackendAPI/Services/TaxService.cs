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
		decimal _taxableamount;
		string _taxtype;
		ITaxCalculatorFactory _taxCalculatorFactory;
		DbContext _dbContext;

		public TaxService(decimal taxableAmount, string taxType, ITaxCalculatorFactory tcf, DbContext dbc )
		{
			_taxableamount = taxableAmount;
			_taxtype = taxType;
			_taxCalculatorFactory = tcf;
			_dbContext = dbc;
		}

		public decimal CalculateTax()
		{

			var a = _taxCalculatorFactory.CalcuateTaxRateBasedOnType(_taxtype);
			a.TaxableAmount = _taxableamount;
			var b = a.CalculateTax();

			_dbContext.Add();
			_dbContext.SaveChangesAsync();

			// Inject EF to update the Database Here
			return b;
		}
	}
}
