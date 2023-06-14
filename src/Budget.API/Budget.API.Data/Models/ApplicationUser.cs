using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Budget.API.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		IEnumerable<Expense> Expenses { get; init; }
		IEnumerable<Income> Incomes { get; init; }
	}
}
