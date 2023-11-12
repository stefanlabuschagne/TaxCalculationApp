using BackendAPI.Models.DTO.Request;
using BackendAPI.Models.TaxCalculation;

namespace BackendAPI.Services.Factory
{
    public class TaxCalculatorFactory : ITaxCalculatorFactory
	{

		public string[] PostalCodes { get; set; } = new string[] { "7441", "A100", "7000", "1000" };

		private Dictionary<string, Func<ITaxCalculation>> _entityTypeMapper;

		public TaxCalculatorFactory()
		{
			_entityTypeMapper = new Dictionary<string, Func<ITaxCalculation>>();
				_entityTypeMapper.Add(PostalCodes[0], () => { return new Progressive(); });
				_entityTypeMapper.Add(PostalCodes[1], () => { return new FlatValue(); });
				_entityTypeMapper.Add(PostalCodes[2], () => { return new FlatRate(); });
				_entityTypeMapper.Add(PostalCodes[3], () => { return new Progressive(); });
		}

		public ITaxCalculation CalcuateTaxRateBasedOnType(string entityType)
		{
			return _entityTypeMapper[entityType]();
		}
	}
}
