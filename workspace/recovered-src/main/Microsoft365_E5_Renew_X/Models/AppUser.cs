using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace Microsoft365_E5_Renew_X.Models;

public class AppUser : IdentityUser
{
	public override string Id { get; set; }

	public string Name { get; set; }

	public string OAuthId { get; set; }

	public int Status { get; set; }

	public int Quota { get; set; }

	public DateTime RegisterDate { get; set; }

	public DateTime LastLoginDate { get; set; }

	public AppUser()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
