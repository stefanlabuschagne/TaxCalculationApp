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
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<TaxDbContext>(options =>
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("TaxDatabaseConnectionstring")));

			builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

			builder.Services.AddSingleton<ITaxCalculatorFactory, TaxCalculatorFactory>(); // DI for Tax Factory Service

			// AddTransient did the thing with 
			builder.Services.AddTransient<ITaxService, TaxService>(); // DI for SQL Database Service
			//																													// builder.Services.AddScoped(typeof(ITaxService), typeof(ITaxService));

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