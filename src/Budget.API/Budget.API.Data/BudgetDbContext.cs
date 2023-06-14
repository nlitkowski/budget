using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Budget.API.Data
{
	public class BudgetDbContext : IdentityDbContext<IdentityUser>
	{
		public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
			: base(options)
		{
		}
	}
}