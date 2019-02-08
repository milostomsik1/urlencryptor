using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UrlEncryptor.Data.Models;

namespace UrlEncryptor.Data.Contexts
{
	public class DefaultContext : DbContext
	{
		private readonly IConfiguration _configuration;
		public DefaultContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public DbSet<Url> Urls { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(_configuration.GetConnectionString("DbConnectionString"));
		}
	}
}
