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

		public TaxService(TaxDbContext dbContext, ITaxCalculatorFactory taxCalculatorFactory)
		{
			_dbContext = dbContext;
			_taxCalculatorFactory = taxCalculatorFactory;			
		}

		public bool CalculateTax()
		{
			var TaxType = (BackendAPI.Models.DTO.Request.TaxType) 1;
			decimal TaxableAmount = 100000000;

			var TaxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType(TaxType);

			TaxCalculatorObjectFromFactory.TaxableAmount = TaxableAmount;
			decimal CalculatedTax = TaxCalculatorObjectFromFactory.CalculateTax();

			try
			{
				_dbContext.TaxRecord.Add(new Domain.Entities.TaxRecord()
				{
					TaxableAmount = TaxableAmount,
					TaxCalculated = CalculatedTax,
					TimeCalculated = DateTime.Now,
					TaxType = "Progressive"
				});
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
