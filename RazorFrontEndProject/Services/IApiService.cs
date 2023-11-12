using RazorFrontEndProject.Models;

namespace RazorFrontEndProject.Services
{
  public interface IApiService
  {
    void TaxCalculation(TaxInformation TaxInfoModel);
  }
}