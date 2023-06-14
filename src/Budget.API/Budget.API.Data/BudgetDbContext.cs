using Budget.API.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Budget.API.Data
{
	public class BudgetDbContext : IdentityDbContext<ApplicationUser>
	{
		public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
			: base(options)
		{
		}

		public DbSet<Expense> Expenses { get; set; }
		public DbSet<Income> Incomes { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}