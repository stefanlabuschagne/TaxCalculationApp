using BackendAPI.Data.Context;
using BackendAPI.Data.Implementation;
using BackendAPI.Domain.Repository;
using BackendAPI.Services;
using BackendAPI.Services.Factory;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<TaxDbContext>(options =>
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("TaxDatabaseConnectionstring")));

			builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
			builder.Services.AddSingleton<ITaxCalculatorFactory, TaxCalculatorFactory>();
			builder.Services.AddTransient<ITaxService, TaxService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}