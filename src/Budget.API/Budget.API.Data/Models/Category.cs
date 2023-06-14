using Microsoft.EntityFrameworkCore;

namespace Budget.API.Data.Models
{
	[Index(nameof(Name), IsUnique = true)]
	public record Category
	{
		public int Id { get; init; }
		public string Name { get; init; }
	}
}
