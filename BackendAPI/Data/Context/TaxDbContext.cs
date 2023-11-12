using BackendAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data.Context
{
  public class TaxDbContext : DbContext
  {
		public TaxDbContext(DbContextOptions<TaxDbContext> options)
            : base(options)
		{
		}

		public DbSet<TaxRecord> TaxRecord { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Use this to Load Data
			// https://youtu.be/xdibesoH8zE?t=1312
		}
	}
}
