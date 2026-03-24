using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft365_E5_Renew_X;

public class MicrosoftAccountNoCSRFHandler : MicrosoftAccountHandler
{
	public MicrosoftAccountNoCSRFHandler(IOptionsMonitor<MicrosoftAccountOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector(options, logger, encoder, clock);
	}

	protected override bool ValidateCorrelationId(AuthenticationProperties properties)
	{
		return true;
	}
}
