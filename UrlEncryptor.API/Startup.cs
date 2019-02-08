using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlEncryptor.Data.Contexts;

namespace UrlEncryptor.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().AddNewtonsoftJson();

			services.AddTransient<DefaultContext, DefaultContext>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseRouting(routes =>
			{
				routes.MapApplication();
			});
		}
	}
}
