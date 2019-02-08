using Microsoft.AspNetCore.Mvc;
using UrlEncryptor.Data.Models;
using System.Linq;
using UrlEncryptor.Data.Contexts;
using System;

namespace UrlEncryptor.API.Controllers
{
	[Route("api/url")]
	[ApiController]
	public class UrlController : ControllerBase
	{
		private readonly DefaultContext _defaultContext;

		public UrlController(DefaultContext defaultContext)
		{
			_defaultContext =  defaultContext;
		}

		[HttpPost]
		public ActionResult EncryptUrl([FromBody] Url url)
		{
			url.Id = Guid.NewGuid();

			_defaultContext.Urls.Add(url);
			_defaultContext.SaveChanges();

			return Ok(new { Url = url.Id });
		}

		[HttpGet]
		public ActionResult GetAllUrls()
		{
			var urls = _defaultContext.Urls.ToList();
			return Ok(urls);
		}

		[HttpGet("{id}")]
		public ActionResult GetUrlById([FromRoute] Guid id)
		{
			var url = _defaultContext.Urls.Where(u => u.Id == id).FirstOrDefault();

			if (url == null)
			{
				return NotFound();
			}

			return Ok(new { Url = url.Link });
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteUrlById([FromRoute] Guid id)
		{
			var url = _defaultContext.Urls.Find(id);
			if (url == null)
			{
				return NotFound();
			}

			_defaultContext.Urls.Remove(url);
			_defaultContext.SaveChanges();

			return Ok();
		}
	
	}
}
