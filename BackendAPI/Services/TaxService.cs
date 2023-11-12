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
		private ITaxCalculatorFactory _taxCalculatorFactory;
		private TaxDbContext _dbContext;

		public TaxService(TaxDbContext dbContext, ITaxCalculatorFactory taxCalculatorFactory)
		{
			_dbContext = dbContext;
			_taxCalculatorFactory = taxCalculatorFactory;			
		}

		public bool CalculateTax(decimal TaxableAmount, string PostalCode)
		{

			var TaxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType(PostalCode);

			TaxCalculatorObjectFromFactory.TaxableAmount = TaxableAmount;
			decimal CalculatedTax = TaxCalculatorObjectFromFactory.CalculateTax();

			try
			{
				_dbContext.TaxRecord.Add(new Domain.Entities.TaxRecord()
				{
					TaxableAmount = TaxableAmount,
					TaxCalculated = CalculatedTax,
					TimeCalculated = DateTime.Now,
					PostalCode = PostalCode 
				}); ;
				_dbContext.SaveChanges();

			}
			catch (Exception ex) 
			{
				var X = ex.Message;
				return false;
			}
			return true;
		}
	}
}
