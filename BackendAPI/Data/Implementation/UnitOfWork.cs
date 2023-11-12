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
			// List of all repositories implemented in the unit of work
			TaxRecord = new TaxRecordRepository(context);
		}

		public ITaxRecordRepository TaxRecord { get; private set; }

		public int Save()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();

		}
	}
}
