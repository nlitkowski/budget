using System.ComponentModel.DataAnnotations;

namespace Budget.API.Contracts
{
	public class LoginModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}