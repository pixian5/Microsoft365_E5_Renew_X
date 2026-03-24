using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authentication;

namespace Microsoft365_E5_Renew_X.ViewModels.Account;

public class LoginViewModel
{
	public string TipMessage { get; set; }

	public bool TipMessageIsDanger { get; set; }

	public string ReturnUrl { get; set; }

	public IList<AuthenticationScheme> ExternalLogins { get; set; }

	public LoginViewModel()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
