﻿using RazorFrontEndProject.Models;

namespace RazorFrontEndProject.Services
{
  public interface IApiService
  {
    bool TaxCalculation(TaxInformation taxInfoModel);
  }
}