using System.ComponentModel.DataAnnotations;

namespace Budget.API.Contracts
{
	public record Category : CategoryBase
	{
		[Required]
		public int Id { get; init; }
	}
}
