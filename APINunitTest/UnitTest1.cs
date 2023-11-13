using BackendAPI.Data.Context;
using BackendAPI.Services;
using BackendAPI.Services.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

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

	[TestFixture]
	public class TaxCalculatorFactoryTests
	{
		private ITaxCalculatorFactory _taxCalculatorFactory;

		[SetUp]
		public void Setup()
		{
			_taxCalculatorFactory = new TaxCalculatorFactory();
		}

		[Test]
		public void should_use_flatvalue_taxing()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("A100");
			taxCalculatorObjectFromFactory.TaxableAmount = 666667;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 10000m);
		}

		public void should_use_flatvalue_taxing_too()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("A100");
			taxCalculatorObjectFromFactory.TaxableAmount = 100000;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 5000m);
		}

		[Test]
		public void should_use_progressive_taxing()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("7441");
			taxCalculatorObjectFromFactory.TaxableAmount = 66776667;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 23349516.95m);
		}

		[Test]
		public void should_use_progressive_taxing_too()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("1000");
			taxCalculatorObjectFromFactory.TaxableAmount = 66776667;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 23349516.95m);
		}

		[Test]
		public void should_use_flatrate_taxing()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("7000");
			taxCalculatorObjectFromFactory.TaxableAmount = 66776667;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 11685916.725m);

		}
	}
}