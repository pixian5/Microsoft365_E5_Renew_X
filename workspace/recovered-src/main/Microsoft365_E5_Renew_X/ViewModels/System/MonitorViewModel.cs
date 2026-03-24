using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft365_E5_Renew_X.Core;

namespace Microsoft365_E5_Renew_X.ViewModels.System;

public class MonitorViewModel
{
	public string LoginRequest { get; set; }

	public string LoginSuccess { get; set; }

	public string LoginFail { get; set; }

	public string NoLoginRequest { get; set; }

	public string NoLoginSuccess { get; set; }

	public string NoLoginFail { get; set; }

	public string TodayRequest { get; set; }

	public string TodaySuccess { get; set; }

	public string TodayFail { get; set; }

	public string LastLoginRequest { get; set; }

	public string LastLoginSuccess { get; set; }

	public string LastLoginFail { get; set; }

	public string LastNoLoginRequest { get; set; }

	public string LastNoLoginSuccess { get; set; }

	public string LastNoLoginFail { get; set; }

	public string LastRequest { get; set; }

	public string LastSuccess { get; set; }

	public string LastFail { get; set; }

	public string DataSyncTime { get; set; }

	public string APIRequestTime { get; set; }

	public string IdleTime { get; set; }

	public string LastDataSyncTime { get; set; }

	public string LastAPIRequestTime { get; set; }

	public string LastIdleTime { get; set; }

	public string SystemLoad { get; set; }

	public string LastSystemLoad { get; set; }

	public string PerAPITime { get; set; }

	public string LastPerAPITime { get; set; }

	public List<APIAnalyse.APIAnalyseBase> APIAnalyseList { get; set; }

	public List<APIAnalyse.APIAnalyseBase> LastAPIAnalyseList { get; set; }

	public MonitorViewModel()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
