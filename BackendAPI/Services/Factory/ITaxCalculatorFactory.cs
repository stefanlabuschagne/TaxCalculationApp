using BackendAPI.Models.DTO.Request;
using BackendAPI.Models.TaxCalculation;
using System;
using System.Runtime;

namespace BackendAPI.Services.Factory
{
	public class ITaxCalculatorFactory
	{
		private Dictionary<TaxType, Func<ITaxCalculation>> _entityTypeMapper;

		public ITaxCalculatorFactory()
		{
			_entityTypeMapper = new Dictionary<TaxType, Func<ITaxCalculation>>();
			_entityTypeMapper.Add(TaxType.Progressive, () => { return new Progressive(); });
			_entityTypeMapper.Add(TaxType.Flatrate, () => { return new FlatRate(); });
			_entityTypeMapper.Add(TaxType.FlatValue, () => { return new FlatValue(); });
		}

		public ITaxCalculation GetEntityBasedOnType(TaxType entityType)
		{
			return _entityTypeMapper[entityType]();
		}
	}
}
