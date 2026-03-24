using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Microsoft365_E5_Renew_X.ViewModels.User;

public class SettingViewModel
{
	[Key]
	public string Id { get; set; }

	[_0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0311]
	public string Name { get; set; }

	public string OAuthId { get; set; }

	public int Quota { get; set; }

	[_0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0312]
	public string Email { get; set; }

	public DateTime RegisterDate { get; set; }

	public DateTime LastLoginDate { get; set; }

	public bool TipMessageIsSuccess { get; set; }

	public string TipMessage { get; set; }

	public SettingViewModel()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
