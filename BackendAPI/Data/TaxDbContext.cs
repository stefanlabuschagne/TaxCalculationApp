using BackendAPI.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
	public class TaxDbContext : DbContext
	{

		public TaxDbContext(DbContextOptions<TaxDbContext>options) : base(options) { 

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxDbContext).Assembly);
		}

		public DbSet<TaxRecord> TaxRecord { get; set; }

	}
}
