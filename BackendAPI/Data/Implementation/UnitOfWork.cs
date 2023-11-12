using BackendAPI.Data.Context;
using BackendAPI.Domain.Repository;

namespace BackendAPI.Data.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{

		TaxDbContext _context;

		public UnitOfWork(TaxDbContext context) 
		{ 
			_context = context;
			TaxRecord = new TaxRecordRepository(context);
		}

		public ITaxRecordRepository TaxRecord { get; private set; }

		public void Dispose()
		{
			_context.Dispose();
		}

		public int Save()
		{
			return _context.SaveChanges();
		}
	}
}
