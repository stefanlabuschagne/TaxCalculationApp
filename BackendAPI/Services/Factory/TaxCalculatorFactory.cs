using BackendAPI.Models.DTO.Request;
using BackendAPI.Models.TaxCalculation;

namespace BackendAPI.Services.Factory
{
    public class TaxCalculatorFactory : ITaxCalculatorFactory
	{
		public string[] PostalCodes { get; set; } = new string[] { "7441", "A100", "7000", "1000" };

		private Dictionary<string, Func<ITaxCalculation>> entityTypeMapper;

		public TaxCalculatorFactory()
		{
			entityTypeMapper = new Dictionary<string, Func<ITaxCalculation>>();
			entityTypeMapper.Add(PostalCodes[0], () => { return new Progressive(); });
			entityTypeMapper.Add(PostalCodes[1], () => { return new FlatValue(); });
			entityTypeMapper.Add(PostalCodes[2], () => { return new FlatRate(); });
			entityTypeMapper.Add(PostalCodes[3], () => { return new Progressive(); });
		}

		public ITaxCalculation CalcuateTaxRateBasedOnType(string entityType)
		{
			return entityTypeMapper[entityType]();
		}
	}
}
