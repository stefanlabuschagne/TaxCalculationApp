using BackendAPI.Data.Context;
using BackendAPI.Services.Factory;

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

		public bool CalculateTax(decimal taxableAmount, string postalCode)
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType(postalCode);

			taxCalculatorObjectFromFactory.TaxableAmount = taxableAmount;
			decimal calculatedTax = taxCalculatorObjectFromFactory.CalculateTax();

			try
			{
				_dbContext.TaxRecord.Add(new Domain.Entities.TaxRecord()
				{
					TaxableAmount = taxableAmount,
					TaxCalculated = calculatedTax,
					TimeCalculated = DateTime.Now,
					PostalCode = postalCode,
				});
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				var x = ex.Message;
				return false;
			}

			return true;
		}
	}
}
