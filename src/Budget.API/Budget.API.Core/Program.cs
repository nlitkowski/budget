using Autofac.Extensions.DependencyInjection;
using Budget.API.Core.Extensions;
using Budget.API.Data;
using Budget.API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

namespace Budget.API.Core
{
	public class Program
	{
		public static int Main(string[] args)
		{
			var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
			logger.Debug("Initialize application");

			var configuration = GetConfiguration();

			var app = CreateApplication(configuration, args);

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			
			app.MapControllers();

			try
			{
				app.Run();
				return 0;
			}
			catch (Exception ex)
			{
				logger.Error(ex, "Program stopped because of exception");
				return 1;
			}
			finally
			{
				LogManager.Shutdown();
			}
		}

		private static WebApplication CreateApplication(IConfiguration configuration, string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Logging.ClearProviders();
			builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
			builder.Host.UseNLog();

			builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

			builder.WebHost.UseConfiguration(configuration);

			builder.Services.AddDbContext<BudgetDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
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

