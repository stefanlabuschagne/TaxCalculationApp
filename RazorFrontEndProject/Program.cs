using RazorFrontEndProject.Configuration;
using RazorFrontEndProject.Services;

namespace RazorFrontEndProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();

			builder.Services.AddSingleton<IApiService, ApiService>();
			builder.Services.AddHttpClient<IApiService, ApiService>();
			builder.Services.Configure<ApiServiceConfig>(builder.Configuration.GetSection(key: "ApiServiceConfig"));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
				app.UseExceptionHandler("/Error");

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}