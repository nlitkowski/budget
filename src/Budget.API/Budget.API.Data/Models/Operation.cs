using System;

namespace Budget.API.Data.Models
{
	public abstract record Operation
	{
		public int Id { get; init; }
		public ApplicationUser User { get; init; }
		public Category Category { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public double Value { get; init; }
		public DateTime CreatedAt { get; init; }
		public DateTime UpdatedAt { get; init; }
	}
}
