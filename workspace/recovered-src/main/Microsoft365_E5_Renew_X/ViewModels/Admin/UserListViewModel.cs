using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Microsoft365_E5_Renew_X.ViewModels.Admin;

public class UserListViewModel
{
	public class AppUserViewModel
	{
		public string Id { get; set; }

		public string OAuthId { get; set; }

		public string Name { get; set; }

		public int Status { get; set; }

		public int Quota { get; set; }

		public int AccountNum { get; set; }

		public int PausedNum { get; set; }

		public DateTime RegisterDate { get; set; }

		public DateTime LastLoginDate { get; set; }

		public AppUserViewModel()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			base._002Ector();
		}
	}

	public List<AppUserViewModel> AppUsers;

	public int Total { get; set; }

	public int UnActivate { get; set; }

	public int Nomal { get; set; }

	public int Block { get; set; }

	public int Day1 { get; set; }

	public int Day7 { get; set; }

	public int Day30 { get; set; }

	public int Day90 { get; set; }

	public UserListViewModel()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		AppUsers = new List<AppUserViewModel>();
		base._002Ector();
	}
}
