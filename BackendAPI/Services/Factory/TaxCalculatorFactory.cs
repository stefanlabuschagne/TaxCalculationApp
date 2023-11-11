using BackendAPI.Models.DTO.Request;
using BackendAPI.Models.TaxCalculation;

namespace BackendAPI.Services.Factory
{
    public class TaxCalculatorFactory : ITaxCalculatorFactory
	{
		private Dictionary<TaxType, Func<ITaxCalculation>> _entityTypeMapper;

		public TaxCalculatorFactory()
		{
			_entityTypeMapper = new Dictionary<TaxType, Func<ITaxCalculation>>();
			_entityTypeMapper.Add(TaxType.Progressive, () => { return new Progressive(); });
			_entityTypeMapper.Add(TaxType.Flatrate, () => { return new FlatRate(); });
			_entityTypeMapper.Add(TaxType.FlatValue, () => { return new FlatValue(); });
		}

		public ITaxCalculation CalcuateTaxRateBasedOnType(TaxType entityType)
		{
			return _entityTypeMapper[entityType]();
		}
	}
}
