using BackendAPI.Data.Context;
using BackendAPI.Services;
using BackendAPI.Services.Factory;
using Microsoft.EntityFrameworkCore;

namespace APINunitTest
{
	[TestFixture]
	public class Tests
  {
    private ITaxService _taxService;

    [SetUp]
		public void Setup()
		{
			var options = new DbContextOptions<TaxDbContext>();

			var _dbContext = new TaxDbContext(options);

			var _taxCalculatorFactory = new TaxCalculatorFactory();

			_taxService = new TaxService(_dbContext, _taxCalculatorFactory);
	  }

		[Test]
		[Ignore("Reason for ignoring this test")]
		public void Test1()
		{
      var result = _taxService.CalculateTax(6666666,"7000");
		}
  }
}