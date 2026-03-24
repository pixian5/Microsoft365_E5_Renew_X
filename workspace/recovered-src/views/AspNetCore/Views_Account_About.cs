using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft365_E5_Renew_X.Core;
using Microsoft365_E5_Renew_X.Languages;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "76d173a7d71e863de27725227e18d32230fe5779", "/Views/Account/About.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "39f87f9f763dc1c7c44e6c7b8495d373eb6e42c3", "/Views/Account/_ViewImports.cshtml")]
public class Views_Account_About : RazorPage<dynamic>
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
		base.ViewBag.Title = Lang.Get("关于");
		TimeSpan timeSpan = DateTime.Now - SystemConfig.Dynamic.StartTime;
		WriteLiteral("\r\n\r\n\r\n<h1>MS365 E5 Renew X</h1>\r\n\r\n<h4>&emsp;MS365 E5 Renew X是网页版的E5续订服务，通过前台网页与用户进行信息交互，由后台服务全自动执行API调用任务。</h4>\r\n\r\n\r\n<hr />\r\n<h2>");
		Write(Lang.Get("致谢"));
		WriteLiteral("</h2>\r\n<h4>&emsp;<b>LeeSkyler</b> ");
		Write(Lang.Get("进行部署云服务器测试"));
		WriteLiteral("</h4>\r\n<h3>");
		Write(Lang.Get("BUG提交反馈"));
		WriteLiteral("</h3>\r\n<h4>&emsp;<b>LeeSkyler、ChirmyRam</b></h4>\r\n<h3>");
		Write(Lang.Get("开发参与人员"));
		WriteLiteral("</h3>\r\n<h4>&emsp;<b>LeeSkyler、Gladtbam(山抹微云)、黑夜(暗白)、Ednovas、我终于有猫了、匣客、别恋</b></h4>\r\n<hr />\r\n<h4>服务程序版本：<b>");
		Write(SystemConfig.Static.Program.Version.ToString());
		WriteLiteral(" (");
		Write(SystemConfig.Static.Program.CompileTime.ToString("yyyy-MM-dd HH:mm:ss UTC+8"));
		WriteLiteral(")</b></h4>\r\n<h4>Copyright © ");
		Write(SystemConfig.Static.Program.CompileTime.Year);
		WriteLiteral("-");
		Write(Lang.Get("现在"));
		WriteLiteral(" <b>SundayRX</b> All Rights Reserved.</h4>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-auto\">\r\n        <h6 ><b style=\"text-align:left;\">服务启动时间：");
		Write(SystemConfig.Dynamic.StartTime.ToString("yyyy-MM-dd HH:mm:ss UTCz"));
		WriteLiteral(" 持续时间：");
		Write(timeSpan.ToString("dd\\:hh\\:mm\\:ss"));
		WriteLiteral("</b></h6>\r\n    </div>\r\n    <div class=\"col\">\r\n        <h6 style=\"text-align:right;\"><b > 服务器系统时间：");
		Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss UTCz"));
		WriteLiteral("</b></h6>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
	}
}
