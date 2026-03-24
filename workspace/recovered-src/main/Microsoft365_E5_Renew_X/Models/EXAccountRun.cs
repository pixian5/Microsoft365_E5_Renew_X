using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Microsoft365_E5_Renew_X.Models;

public class EXAccountRun
{
	[Key]
	public string Id { get; set; }

	public string AppUserUUID { get; set; }

	public string UserName { get; set; }

	public string ClientID { get; set; }

	public string PwdOrSecert { get; set; }

	public bool IsLogin { get; set; }

	public DateTime Date { get; set; }

	public int Success { get; set; }

	public int Fail { get; set; }

	public int Request { get; set; }

	public string Log { get; set; }

	public int TodaySuccess { get; set; }

	public int TodayFail { get; set; }

	public int TodayRequest { get; set; }

	public bool IsPaused { get; set; }

	public bool IsNeedSendMail { get; set; }

	public string PausedReason { get; set; }

	public DateTime NextDate { get; set; }

	public DateTime TimeStamp { get; set; }

	public EXAccountRun()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		Date = DateTime.MinValue;
		Log = "";
		IsPaused = true;
		PausedReason = "";
		base._002Ector();
	}
}
