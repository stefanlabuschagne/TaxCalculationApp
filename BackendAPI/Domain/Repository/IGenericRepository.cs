namespace BackendAPI.Domain.Repository
{
	public interface IGenericRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		void Add(T entity);
	}
}
