using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Microsoft365_E5_Renew_X.ViewModels.Admin;

public class EXAccountListViewModel
{
	public class EXAccountViewModel
	{
		public string Id { get; set; }

		public string AppUserUUID { get; set; }

		public string UserName { get; set; }

		public bool IsLogin { get; set; }

		public int Success { get; set; }

		public int Fail { get; set; }

		public int Request { get; set; }

		public int TodaySuccess { get; set; }

		public int TodayFail { get; set; }

		public int TodayRequest { get; set; }

		public bool IsPaused { get; set; }

		public bool IsSynchronized { get; set; }

		public EXAccountViewModel()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			IsPaused = true;
			base._002Ector();
		}
	}

	public List<EXAccountViewModel> EXAccounts;

	public int Total { get; set; }

	public int UnSynchronized { get; set; }

	public int Nomal { get; set; }

	public int Paused { get; set; }

	public EXAccountListViewModel()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		EXAccounts = new List<EXAccountViewModel>();
		base._002Ector();
	}
}
