using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Budget.API.Core.Extensions
{
	public static class Swagger
	{
		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(ConfigureSwagger);
			return services;
		}

		private static void ConfigureSwagger(SwaggerGenOptions options)
		{
			options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Scheme = "Bearer",
				BearerFormat = "JWT",
				In = ParameterLocation.Header,
				Name = "Authorization",
				Description = "Bearer Authentication with JWT Token",
				Type = SecuritySchemeType.Http
			});
			options.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme {
						Reference = new OpenApiReference {
							Id = "Bearer",
							Type = ReferenceType.SecurityScheme
						}
					},
					new List<string>()
				}
			});
		}
	}
}
