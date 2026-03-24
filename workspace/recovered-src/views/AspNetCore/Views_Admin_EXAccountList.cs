using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft365_E5_Renew_X.Languages;
using Microsoft365_E5_Renew_X.ViewModels.Admin;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "b89a01974e86dd59c24bfb5a90c4bfeb7e562a8c", "/Views/Admin/EXAccountList.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "cb2fd25cde740f6cb9ddef4bf2af6ae15710d297", "/Views/Admin/_ViewImports.cshtml")]
public class Views_Admin_EXAccountList : RazorPage<EXAccountListViewModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("class", new HtmlString("btn btn-primary btn-sm"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("asp-controller", "Admin", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-action", "EXAccount", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", new HtmlString("btn btn-info btn-sm"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("asp-action", "User", HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;

	private TagHelperScopeManager __tagHelperScopeManager
	{
		get
		{
			if (__backed__tagHelperScopeManager == null)
			{
				__backed__tagHelperScopeManager = new TagHelperScopeManager(base.StartTagHelperWritingScope, base.EndTagHelperWritingScope);
			}
			return __backed__tagHelperScopeManager;
		}
	}

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
	public IHtmlHelper<EXAccountListViewModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n");
		base.ViewBag.Title = Lang.Get("运行账号列表");
		WriteLiteral("\r\n\r\n<h1>运行账号列表</h1>\r\n<hr />\r\n<div>\r\n    <ul class=\"list-inline h6\" style=\"font-weight:bold;\">\r\n        <li class=\"list-inline-item text-primary\">总数</li>\r\n        <li class=\"list-inline-item\">|</li>\r\n        <li class=\"list-inline-item text-success\">正常</li>\r\n        <li class=\"list-inline-item\">|</li>\r\n        <li class=\"list-inline-item text-warning\">待同步</li>\r\n        <li class=\"list-inline-item\">|</li>\r\n        <li class=\"list-inline-item text-danger\">暂停</li>\r\n        <li class=\"list-inline-item\">:</li>\r\n        <li class=\"list-inline-item text-primary\">");
		Write(base.Model.Total);
		WriteLiteral("</li>\r\n        <li class=\"list-inline-item\">|</li>\r\n        <li class=\"list-inline-item text-success\">");
		Write(base.Model.Nomal);
		WriteLiteral("</li>\r\n        <li class=\"list-inline-item\">|</li>\r\n        <li class=\"list-inline-item text-warning\">");
		Write(base.Model.UnSynchronized);
		WriteLiteral("</li>\r\n        <li class=\"list-inline-item\">|</li>\r\n        <li class=\"list-inline-item text-danger\">");
		Write(base.Model.Paused);
		WriteLiteral("</li>\r\n       \r\n    </ul>\r\n</div>\r\n\r\n\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-4\">\r\n        <h4>账号名称</h4>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <h4 class=\"text-center\">上次调用</h4>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <h4 class=\"text-center\">今日调用</h4>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <h4 class=\"text-center\">操作</h4>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <h4 class=\"text-center\">查看</h4>\r\n    </div>\r\n</div>\r\n<hr />\r\n\r\n");
		foreach (EXAccountListViewModel.EXAccountViewModel eXAccount in base.Model.EXAccounts)
		{
			WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-4\" style=\"margin-top:7px;\">\r\n");
			if (eXAccount.IsSynchronized)
			{
				if (!eXAccount.IsPaused)
				{
					if (eXAccount.IsLogin)
					{
						WriteLiteral("                    <h6 style=\"color:#007ACC;font-weight:bold;\">");
						Write(eXAccount.UserName);
						WriteLiteral("</h6>\r\n");
					}
					else
					{
						WriteLiteral("                    <h6 style=\"color:#009999;font-weight:bold;\">");
						Write(eXAccount.UserName);
						WriteLiteral("</h6>\r\n");
					}
				}
				else
				{
					WriteLiteral("                <h6 class=\"text-danger\" style=\"font-weight:bold;\">");
					Write(eXAccount.UserName);
					WriteLiteral("</h6>\r\n");
				}
			}
			else
			{
				WriteLiteral("            <h6 class=\"text-warning\" style=\"font-weight:bold;\">");
				Write(eXAccount.UserName);
				WriteLiteral("</h6>\r\n");
			}
			WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"col-2\" style=\"margin-top:7px\">\r\n        <p class=\"h6 text-center\" style=\"font-weight:bold;\">\r\n            <vi style=\"color:#0D6EFD;\">");
			Write(eXAccount.Request);
			WriteLiteral(" </vi>\r\n            <vi>|</vi>\r\n            <vi style=\"color:#198754;\">");
			Write(eXAccount.Success);
			WriteLiteral("</vi>\r\n            <vi>|</vi>\r\n            <vi style=\"color:#DC3545;\">");
			Write(eXAccount.Fail);
			WriteLiteral("</vi>\r\n        </p>\r\n    </div>\r\n    <div class=\"col-2\" style=\"margin-top:7px\">\r\n        <p class=\"h6 text-center\" style=\"font-weight:bold;\">\r\n            <vi style=\"color:#0D6EFD;\">");
			Write(eXAccount.TodayRequest);
			WriteLiteral(" </vi>\r\n            <vi>|</vi>\r\n            <vi style=\"color:#198754;\">");
			Write(eXAccount.TodaySuccess);
			WriteLiteral("</vi>\r\n            <vi>|</vi>\r\n            <vi style=\"color:#DC3545;\">");
			Write(eXAccount.TodayFail);
			WriteLiteral("</vi>\r\n        </p>\r\n    </div>\r\n\r\n    <div class=\"col-2\" style=\"text-align:center;\">\r\n        ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "b89a01974e86dd59c24bfb5a90c4bfeb7e562a8c13955", async delegate
			{
				WriteLiteral("编辑");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
			if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			BeginWriteTagHelperAttribute();
			WriteLiteral("UID-");
			WriteLiteral(eXAccount.Id);
			__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    </div>\r\n    <div class=\"col-2\" style=\"text-align:center;\">\r\n        ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "b89a01974e86dd59c24bfb5a90c4bfeb7e562a8c16570", async delegate
			{
				WriteLiteral("用户");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
			if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			BeginWriteTagHelperAttribute();
			WriteLiteral("UID-");
			WriteLiteral(eXAccount.AppUserUUID);
			__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    </div>\r\n</div>\r\n");
		}
		WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
	}
}
