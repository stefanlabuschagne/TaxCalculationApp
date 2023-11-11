
using BackendAPI.Data;
using BackendAPI.Models.TaxCalculation;
using BackendAPI.Services;
using BackendAPI.Services.Factory;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BackendAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<TaxDbContext>(options =>
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("TaxDatabaseConnectionstring")));

			builder.Services.AddSingleton<ITaxService, TaxService>(); // DI for SQL Database Service
			builder.Services.AddSingleton<ITaxCalculatorFactory, TaxCalculatorFactory>(); // DI for Tax Factory Service

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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