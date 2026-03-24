using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft365_E5_Renew_X.Models;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public class AppDbContext : IdentityDbContext<AppUser>
{
	public DbSet<EXAccount> EXAccounts { get; set; }

	public DbSet<EXAccountRun> EXAccountRuns { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector((DbContextOptions)options);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}
