using System.ComponentModel.DataAnnotations;

namespace Budget.API.Contracts
{
	public record CategoryBase
	{
		[Required]
		public string Name { get; init; }
	}
}
