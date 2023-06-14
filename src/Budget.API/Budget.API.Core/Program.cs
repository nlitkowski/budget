using Autofac.Extensions.DependencyInjection;
using Budget.API.Core.Extensions;
using Budget.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Budget.API.Core
{
	public class Program
	{
		public static int Main(string[] args)
		{
			var configuration = GetConfiguration();

			var app = CreateApplication(configuration, args);

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();
			
			app.MapControllers();

			try
			{
				app.Run();
				return 0;
			}
			catch // (Exception ex)
			{
				// Log exception
				return 1;
			}
			finally
			{
				// flush logs
			}
		}

		private static WebApplication CreateApplication(IConfiguration configuration, string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

			builder.WebHost.UseConfiguration(configuration);

			builder.Services.AddDbContext<BudgetDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
			builder.Services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<BudgetDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.ConfigureAuthentication(configuration);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwagger();

			return builder.Build();
		}

		private static IConfiguration GetConfiguration()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables();

			return builder.Build();
		}
	}
}

