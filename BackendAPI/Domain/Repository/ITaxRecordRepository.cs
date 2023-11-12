using BackendAPI.Domain.Entities;

namespace BackendAPI.Domain.Repository
{
    //Interface to be passed to the Genereic Repository
    public interface ITaxRecordRepository : IGenericRepository<TaxRecord>
    {
        //double TaxableAmount { get; set; }
        //double TaxCalculated { get; set; }
        //string TaxType { get; set; }
        //DateTime TimeCalculated { get; set; }
    }
}