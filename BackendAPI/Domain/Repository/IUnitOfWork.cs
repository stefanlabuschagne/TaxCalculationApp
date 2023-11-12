namespace BackendAPI.Domain.Repository
{

	// One unit of work - should have more in here.
	public interface IUnitOfWork : IDisposable
	{
		ITaxRecordRepository TaxRecordRepository { get; }

		int Save();
	}
}
