using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft365_E5_Renew_X.Core;
using Microsoft365_E5_Renew_X.Languages;
using Microsoft365_E5_Renew_X.ViewModels.System;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "759f72605465ae12616fe58266d10408adbc0a61", "/Views/System/Monitor.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "6265d2efa40c5b637baa922382d3359ac92f0081", "/Views/System/_ViewImports.cshtml")]
public class Views_System_Monitor : RazorPage<MonitorViewModel>
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
	public IHtmlHelper<MonitorViewModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		base.ViewBag.Title = "系统监视";
		WriteLiteral("\r\n<h1>系统监视</h1>\r\n<br />\r\n\r\n\r\n\r\n<!-- Nav pills -->\r\n<ul class=\"nav nav-pills nav-justified\">\r\n    <li class=\"nav-item\">\r\n        <a class=\"nav-link active\" data-bs-toggle=\"pill\" href=\"#Today\"><h4>");
		Write(Lang.Get("实时数据"));
		WriteLiteral("</h4> </a>\r\n    </li>\r\n    <li class=\"nav-item\">\r\n        <a class=\"nav-link\" data-bs-toggle=\"pill\" href=\"#Last\"><h4>");
		Write(Lang.Get("昨日数据"));
		WriteLiteral("</h4></a>\r\n    </li>\r\n</ul>\r\n\r\n<div class=\"tab-content \">\r\n\r\n    <div class=\"tab-pane active container\" id=\"Today\">\r\n        <hr />\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("系统负载"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.SystemLoad);
		WriteLiteral(" %</vi>\r\n                </p>\r\n\r\n\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("耗时统计"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.DataSyncTime);
		WriteLiteral(" </vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.APIRequestTime);
		WriteLiteral("</vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-success\">");
		Write(base.Model.IdleTime);
		WriteLiteral(" </vi>\r\n                </p>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n        <div class=\"form-group row\">\r\n            <div class=\"form-inline col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("登录调用"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.LoginRequest);
		WriteLiteral(" </vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-success\">");
		Write(base.Model.LoginSuccess);
		WriteLiteral("</vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-danger\">");
		Write(base.Model.LoginFail);
		WriteLiteral(" </vi>\r\n                </p>\r\n            </div>\r\n            <div class=\"form-inline col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("非登调用"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.NoLoginRequest);
		WriteLiteral(" </vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-success\">");
		Write(base.Model.NoLoginSuccess);
		WriteLiteral("</vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-danger\">");
		Write(base.Model.NoLoginFail);
		WriteLiteral(" </vi>\r\n                </p>\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div class=\" row\">\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("调用统计"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.TodayRequest);
		WriteLiteral(" </vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-success\">");
		Write(base.Model.TodaySuccess);
		WriteLiteral("</vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-danger\">");
		Write(base.Model.TodayFail);
		WriteLiteral(" </vi>\r\n                </p>\r\n            </div>\r\n            <div class=\" col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("调用单个API花费时间"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.PerAPITime);
		WriteLiteral(" S</vi>\r\n                </p>\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <hr />\r\n\r\n        <div class=\"form-group row\">\r\n            <div class=\"col-8 col-sm-8 col-md-8 col-lg-6 col-xl-6\">\r\n                <h4>");
		Write(Lang.Get("API名称"));
		WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"col-2 col-sm-2 col-md-2 col-lg-4 col-xl-4\">\r\n                <h4>");
		Write(Lang.Get("调用次数"));
		WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2\">\r\n                <h4>");
		Write(Lang.Get("平均时间"));
		WriteLiteral("</h4>\r\n            </div>\r\n        </div>\r\n\r\n        <hr />\r\n\r\n");
		foreach (APIAnalyse.APIAnalyseBase aPIAnalyse in base.Model.APIAnalyseList)
		{
			WriteLiteral("            <div class=\"form-group row\">\r\n                <div class=\"col-8 col-sm-8 col-md-8 col-lg-6 col-xl-6\">\r\n                    <h5>");
			Write(aPIAnalyse.Name);
			WriteLiteral("</h5>\r\n                </div>\r\n                <div class=\"form-inline col-2 col-sm-2 col-md-2 col-lg-4 col-xl-4\">\r\n                    <p class=\"h4\">\r\n                        <vi class=\"text-danger\">");
			Write(aPIAnalyse.FailNum);
			WriteLiteral("</vi>\r\n                        <vi>|</vi>\r\n                        <vi class=\"text-primary\">");
			Write(aPIAnalyse.RequestNum);
			WriteLiteral(" </vi>\r\n                        <vi>|</vi>\r\n                        <vi class=\"text-danger\">");
			Write(aPIAnalyse.FailPercent.ToString("00"));
			WriteLiteral("%</vi>\r\n                    </p>\r\n                </div>\r\n                <div class=\"col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2\">\r\n                    <h5>");
			Write(aPIAnalyse.AverageCostTime.ToString("0.0000"));
			WriteLiteral(" S</h5>\r\n                </div>\r\n            </div>\r\n");
		}
		WriteLiteral("\r\n\r\n\r\n    </div>\r\n\r\n\r\n\r\n    <div class=\"tab-pane container\" id=\"Last\">\r\n        <hr />\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("系统负载"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.LastSystemLoad);
		WriteLiteral(" %</vi>\r\n                </p>\r\n            </div>\r\n            <div class=\"form-inline col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("耗时统计"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.LastDataSyncTime);
		WriteLiteral(" </vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.LastAPIRequestTime);
		WriteLiteral("</vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-success\">");
		Write(base.Model.LastIdleTime);
		WriteLiteral(" </vi>\r\n                </p>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n        <div class=\"form-group row\">\r\n            <div class=\"col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("登录调用"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.LastLoginRequest);
		WriteLiteral(" </vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-success\">");
		Write(base.Model.LastLoginSuccess);
		WriteLiteral("</vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-danger\">");
		Write(base.Model.LastLoginFail);
		WriteLiteral(" </vi>\r\n                </p>\r\n            </div>\r\n            <div class=\"form-inline col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("非登调用"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.LastNoLoginRequest);
		WriteLiteral(" </vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-success\">");
		Write(base.Model.LastNoLoginSuccess);
		WriteLiteral("</vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-danger\">");
		Write(base.Model.LastNoLoginFail);
		WriteLiteral(" </vi>\r\n                </p>\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            <div class=\"form-inline col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("调用统计"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.LastRequest);
		WriteLiteral(" </vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-success\">");
		Write(base.Model.LastSuccess);
		WriteLiteral("</vi>\r\n                    <vi>|</vi>\r\n                    <vi class=\"text-danger\">");
		Write(base.Model.LastFail);
		WriteLiteral(" </vi>\r\n                </p>\r\n            </div>\r\n            <div class=\"form-inline col-sm-6\">\r\n                <p class=\"h4\">\r\n                    <vi>");
		Write(Lang.Get("调用单个API花费时间"));
		WriteLiteral("：</vi>\r\n                    <vi class=\"text-primary\">");
		Write(base.Model.LastPerAPITime);
		WriteLiteral(" S</vi>\r\n                </p>\r\n            </div>\r\n\r\n        </div>\r\n        <hr />\r\n        <div class=\"form-group row\">\r\n            <div class=\"col-8 col-sm-8 col-md-8 col-lg-6 col-xl-6\">\r\n                <h4>");
		Write(Lang.Get("API名称"));
		WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"col-2 col-sm-2 col-md-2 col-lg-4 col-xl-4\">\r\n                <h4>");
		Write(Lang.Get("调用次数"));
		WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2\">\r\n                <h4>");
		Write(Lang.Get("平均时间"));
		WriteLiteral("</h4>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n");
		foreach (APIAnalyse.APIAnalyseBase lastAPIAnalyse in base.Model.LastAPIAnalyseList)
		{
			WriteLiteral("            <div class=\"form-group row\">\r\n                <div class=\"col-8 col-sm-8 col-md-8 col-lg-6 col-xl-6\">\r\n                    <h5>");
			Write(lastAPIAnalyse.Name);
			WriteLiteral("</h5>\r\n                </div>\r\n                <div class=\"form-inline col-2 col-sm-2 col-md-2 col-lg-4 col-xl-4\">\r\n                    <p class=\"h4\">\r\n                        <vi class=\"text-danger\">");
			Write(lastAPIAnalyse.FailNum);
			WriteLiteral("</vi>\r\n                        <vi>|</vi>\r\n                        <vi class=\"text-primary\">");
			Write(lastAPIAnalyse.RequestNum);
			WriteLiteral(" </vi>\r\n                        <vi>|</vi>\r\n                        <vi class=\"text-danger\">");
			Write(lastAPIAnalyse.FailPercent.ToString("00"));
			WriteLiteral("% </vi>\r\n                    </p>\r\n                </div>\r\n                <div class=\"col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2\">\r\n                    <h5>");
			Write(lastAPIAnalyse.AverageCostTime.ToString("0.0000"));
			WriteLiteral(" S</h5>\r\n                </div>\r\n            </div>\r\n");
		}
		WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
	}
}
