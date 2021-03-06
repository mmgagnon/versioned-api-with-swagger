using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiVersionningTest
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddApiVersioning(o =>
			{
				//o.AssumeDefaultVersionWhenUnspecified = true;
				//o.DefaultApiVersion = new ApiVersion(1, 0);
				//o.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
			});

			var apiExplorer = services.AddVersionedApiExplorer(options => {
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1.0", new OpenApiInfo()
				{
					Title = "My API v1.0",
					Version = "v1.0"
				});

				options.SwaggerDoc("v1.1", new OpenApiInfo()
				{
					Title = "My API v1.1",
					Version = "v1.1"
				});

				options.SwaggerDoc("v2.0", new OpenApiInfo()
				{
					Title = "My API v2.0",
					Version = "v2.0"
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger(swagger => {
			});

			app.UseSwaggerUI(c =>
			{
				c.DefaultModelsExpandDepth(0);
				c.SwaggerEndpoint($"/swagger/v1.0/swagger.json", "my API 1.0");
			});
		}
	}
}
