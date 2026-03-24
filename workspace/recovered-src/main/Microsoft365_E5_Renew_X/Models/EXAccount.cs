using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Microsoft365_E5_Renew_X.Models;

public class EXAccount
{
	[Key]
	public string Id { get; set; }

	public string AppUserUUID { get; set; }

	public string UserName { get; set; }

	public string ClientID { get; set; }

	public string PwdOrSecert { get; set; }

	public bool IsLogin { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime TimeStamp { get; set; }

	public EXAccount()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
