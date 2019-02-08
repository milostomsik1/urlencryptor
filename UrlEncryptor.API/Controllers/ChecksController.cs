using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace UrlEncryptor.API.Controllers
{
	[ExcludeFromCodeCoverage]
	[ApiController]
	[Route("api/checks")]
	public class Checks : ControllerBase
	{
		[HttpGet("health")]
		public ActionResult Health()
		{
			return Ok(new { Status = "Healthy" });
		}
	}
}
