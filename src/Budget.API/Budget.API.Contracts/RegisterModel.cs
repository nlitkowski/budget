﻿using System.ComponentModel.DataAnnotations;

namespace Budget.API.Contracts
{
	public record RegisterModel
	{
		[Required]
		public string Username { get; set; }

		[EmailAddress]
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
