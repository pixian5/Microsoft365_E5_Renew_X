using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft365_E5_Renew_X.Core;
using Microsoft365_E5_Renew_X.Languages;
using Microsoft365_E5_Renew_X.ViewModels.Account;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "a61d9aa8bdd02c3e09a1e34050bb04c76dd1e30a", "/Views/Account/Login.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "39f87f9f763dc1c7c44e6c7b8495d373eb6e42c3", "/Views/Account/_ViewImports.cshtml")]
public class Views_Account_Login : RazorPage<LoginViewModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("method", "post", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("asp-action", "ExternalLogin", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-controller", "Account", HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;

	private RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;

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
	public IHtmlHelper<LoginViewModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		base.ViewBag.Title = Lang.Get("登录您的账户");
		WriteLiteral("\r\n");
		if (SystemConfig.Static.ShareSite.Enable)
		{
			WriteLiteral("    <h1>");
			Write(Lang.Get("请选择一种登录方式"));
			WriteLiteral("</h1>\r\n");
			WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-6\">\r\n\r\n            <hr />\r\n            ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "a61d9aa8bdd02c3e09a1e34050bb04c76dd1e30a5990", async delegate
			{
				WriteLiteral("\r\n                <div class=\"card shadow-sm\" style=\"background-color: #E9ECEF;border-color:#E9ECEF;\">\r\n                    <div class=\"card-body\">\r\n                        <h1>&emsp;</h1>\r\n                        <h1 class=\"card-title\">Microsoft ");
				Write(Lang.Get("账户登录"));
				WriteLiteral("</h1>\r\n                        <p class=\"card-text\">");
				Write(Lang.Get("仅限Microsoft个人账户访问"));
				WriteLiteral("</p>\r\n");
				if (SystemConfig.Static.ShareSite.Enable && SystemConfig.Static.ShareSite.OAuth.Microsoft.Enable)
				{
					WriteLiteral("                            <button type=\"submit\" class=\"btn btn-primary btn-lg\" name=\"provider\" value=\"Microsoft\" title=\"使用微软账户登录\">Microsoft</button>\r\n");
				}
				else
				{
					WriteLiteral("                            <button type=\"submit\" class=\"btn btn-secondary btn-lg\" disabled name=\"provider\" value=\"Microsoft\" title=\"使用微软账户登录\">Microsoft</button>\r\n");
				}
				WriteLiteral("                        <h1>&emsp;</h1>\r\n                    </div>\r\n                </div>\r\n            ");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
			if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
			}
			BeginWriteTagHelperAttribute();
			WriteLiteral(base.Model.ReturnUrl);
			__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"], HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-md-6 border-start\">\r\n            <hr />\r\n            ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "a61d9aa8bdd02c3e09a1e34050bb04c76dd1e30a11196", async delegate
			{
				WriteLiteral("\r\n                <div>\r\n                    <div class=\"card shadow-sm\" style=\"background-color: #E9ECEF;border-color:#E9ECEF;\">\r\n                        <div class=\"card-body\">\r\n                            <h1>&emsp;</h1>\r\n                            <h1 class=\"card-title\">GitHub ");
				Write(Lang.Get("账户登录"));
				WriteLiteral("&emsp;</h1>\r\n                            <p class=\"card-text\">");
				Write(Lang.Get("通过GitHub账户快速访问"));
				WriteLiteral("</p>\r\n");
				if (SystemConfig.Static.ShareSite.Enable && SystemConfig.Static.ShareSite.OAuth.Github.Enable)
				{
					WriteLiteral("                                <button type=\"submit\" class=\"btn btn-primary btn-lg\" name=\"provider\" value=\"GitHub\" title=\"使用GitHub账户登录\"> GitHub </button>\r\n");
				}
				else
				{
					WriteLiteral("                                <button type=\"submit\" class=\"btn btn-secondary btn-lg\" disabled name=\"provider\" value=\"GitHub\" title=\"使用GitHub账户登录\"> GitHub </button>\r\n");
				}
				WriteLiteral("                            \r\n                            <h1>&emsp;</h1>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            ");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
			if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
			}
			BeginWriteTagHelperAttribute();
			WriteLiteral(base.Model.ReturnUrl);
			__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"], HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n        </div>\r\n\r\n        <h3>&emsp;</h3>\r\n        <h6 style=\"color:#009999\">&emsp;");
			Write(Lang.Get("*温馨提示：GitHub登录建议使用无痕窗口，提示“HTTP Error 500”请重开浏览器尝试！"));
			WriteLiteral("</h6>\r\n\r\n\r\n\r\n    </div>\r\n");
			if (base.Model.TipMessageIsDanger)
			{
				WriteLiteral("        <h5 class=\"navbar-text text-danger\">");
				Write(base.Model.TipMessage);
				WriteLiteral("</h5>\r\n");
			}
			else
			{
				WriteLiteral("        <h5 class=\"navbar-text text-success\">");
				Write(base.Model.TipMessage);
				WriteLiteral("</h5>\r\n");
			}
		}
		else
		{
			WriteLiteral("    <h1 class=\"text-danger\"><b>不支持的登录方式</b></h1>\r\n    <h3 class=\"text-danger\">此站点未开启站点共享！！！</h3>\r\n");
		}
	}
}
