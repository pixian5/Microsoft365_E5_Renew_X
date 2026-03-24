using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft365_E5_Renew_X.Languages;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "3523141441c74715cd1f6e0cfeba13e418adb72e", "/Views/Account/Blocked.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "39f87f9f763dc1c7c44e6c7b8495d373eb6e42c3", "/Views/Account/_ViewImports.cshtml")]
public class Views_Account_Blocked : RazorPage<dynamic>
{
	[RazorInject]
	public LanguageService Lang { get; private set; }

	[RazorInject]
	public IModelExpressionProvider ModelExpressionProvider { get; private set; }

	[RazorInject]
	public IUrlHelper Url { get; private set; }

	[RazorInject]
	public IViewComponentHelper Component { get; private set; }

	[RazorInject]
	public IJsonHelper Json { get; private set; }

	[RazorInject]
	public IHtmlHelper<dynamic> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n");
		base.ViewBag.Title = Lang.Get("账户封禁");
		WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n<h1 class=\"text-danger\"><b>账户封禁</b></h1>\r\n<h3 class=\"text-danger\">您的账户已被永久封禁，若要解封请联系站长！！！</h3>\r\n");
	}
}
