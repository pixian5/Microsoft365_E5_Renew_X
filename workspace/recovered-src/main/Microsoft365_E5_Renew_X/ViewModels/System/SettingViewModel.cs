using System.Runtime.CompilerServices;

namespace Microsoft365_E5_Renew_X.ViewModels.System;

public class SettingViewModel
{
	public bool AllowRegister { get; set; }

	public string Notice { get; set; }

	public string Master { get; set; }

	public string MasterLink { get; set; }

	[_0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0313]
	public int DefaultQuota { get; set; }

	public bool SpecialPardon { get; set; }

	[_0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0314]
	public int AutoSpecialPardonInterval { get; set; }

	public SettingViewModel()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		AutoSpecialPardonInterval = 30;
		base._002Ector();
	}
}
