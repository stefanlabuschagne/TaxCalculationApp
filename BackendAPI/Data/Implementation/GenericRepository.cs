using BackendAPI.Data.Context;
using BackendAPI.Domain.Entities;
using BackendAPI.Domain.Repository;

// Implementation of the Generic Repository
namespace BackendAPI.Data.Implementation
{
	public class GenericRepository<T> : IGenericRepository<T>
	    where T : class
	{
		// Inject Context
		private readonly TaxDbContext _context;

		public GenericRepository(TaxDbContext context)
		{
			_context = context;
		}

		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public IEnumerable<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}
	}
}
