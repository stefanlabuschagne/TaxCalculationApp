using BackendAPI.Models.DTO.Request;
using BackendAPI.Models.TaxCalculation;

namespace BackendAPI.Services.Factory
{
    public interface ITaxCalculatorFactory
	{
		ITaxCalculation CalcuateTaxRateBasedOnType(TaxType entityType);
	}
}