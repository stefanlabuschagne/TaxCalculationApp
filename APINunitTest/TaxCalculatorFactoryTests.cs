using BackendAPI.Services.Factory;

namespace APINunitTest
{

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
		public void Should_use_flatvalue_taxing_for_more_than_200000()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("A100");
			taxCalculatorObjectFromFactory.TaxableAmount = 666667m;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 10000m);
		}

		public void Should_use_flatvalue_taxing_for_less_than_200000_at_5Percent()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("A100");
			taxCalculatorObjectFromFactory.TaxableAmount = 100000m;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 5000m);
		}

		[Test]
		public void Should_use_progressive_taxing()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("7441");
			taxCalculatorObjectFromFactory.TaxableAmount = 66776667m;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 23349516.95m);
		}

		[Test]
		public void Should_use_progressive_taxing_too()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("1000");
			taxCalculatorObjectFromFactory.TaxableAmount = 66776667m;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 23349516.95m);
		}

		[Test]
		public void Should_use_flatrate_taxing()
		{
			var taxCalculatorObjectFromFactory = _taxCalculatorFactory.CalcuateTaxRateBasedOnType("7000");
			taxCalculatorObjectFromFactory.TaxableAmount = 66776667m;
			decimal result = taxCalculatorObjectFromFactory.CalculateTax();

			Assert.IsTrue(result == 11685916.725m);
		}
	}
}