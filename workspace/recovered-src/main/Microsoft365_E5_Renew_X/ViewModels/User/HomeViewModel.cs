using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Microsoft365_E5_Renew_X.ViewModels.User;

public class HomeViewModel
{
	public class EXAccountViewModel
	{
		public class LogViewModel
		{
			public string API { get; set; }

			public string Result { get; set; }

			public bool IsSuccess { get; set; }

			public LogViewModel()
			{
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
				base._002Ector();
			}
		}

		public string Id { get; set; }

		public string UserName { get; set; }

		public string ClientID { get; set; }

		public string PwdOrSecert { get; set; }

		public bool IsLogin { get; set; }

		public DateTime NextDate { get; set; }

		public DateTime Date { get; set; }

		public int Success { get; set; }

		public int Fail { get; set; }

		public int Request { get; set; }

		public int TodaySuccess { get; set; }

		public int TodayFail { get; set; }

		public int TodayRequest { get; set; }

		public bool IsPaused { get; set; }

		public string PausedReason { get; set; }

		public bool IsSynchronized { get; set; }

		public List<LogViewModel> Logs { get; set; }

		public DateTime CreatedDate { get; set; }

		public EXAccountViewModel()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			IsPaused = true;
			Logs = new List<LogViewModel>();
			base._002Ector();
		}
	}

	public int Quota { get; set; }

	public int Paused { get; set; }

	public int UnSynchronized { get; set; }

	public int Total { get; set; }

	public string Overview { get; set; }

	public int OverviewStatus { get; set; }

	public List<EXAccountViewModel> EXAccountDetails { get; set; }

	public string[] NoticeMessage { get; set; }

	public HomeViewModel()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		Overview = "";
		OverviewStatus = 1;
		EXAccountDetails = new List<EXAccountViewModel>();
		base._002Ector();
	}
}
