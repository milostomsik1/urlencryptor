using System;
using System.ComponentModel.DataAnnotations;

namespace UrlEncryptor.Data.Models
{
	public class Url
	{
		[Key]
		[Required]
		public Guid Id { get; set; }
		[Required]
		[RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$",
		 ErrorMessage = "Invalid link format.")]
		public string Link { get; set; }
		[Required]
		public string Label { get; set; }
	}
}
