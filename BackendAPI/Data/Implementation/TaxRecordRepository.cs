using BackendAPI.Data.Context;
using BackendAPI.Domain.Entities;
using BackendAPI.Domain.Repository;

namespace BackendAPI.Data.Implementation
{
	public class TaxRecordRepository : GenericRepository<TaxRecord>, ITaxRecordRepository
	{
		public TaxRecordRepository(TaxDbContext context)
            : base(context)
		{
		}
	}
}