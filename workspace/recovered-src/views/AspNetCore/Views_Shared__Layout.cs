using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft365_E5_Renew_X.Core;
using Microsoft365_E5_Renew_X.Languages;
using Microsoft365_E5_Renew_X.Models;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "e455e55a48373dc671796808b2011f214b9c7b59", "/Views/Shared/_Layout.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
public class Views_Shared__Layout : RazorPage<dynamic>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("rel", new HtmlString("shortcut icon"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("href", "~/favicon.svg", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("type", new HtmlString("image/svg"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("rel", new HtmlString("stylesheet"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("crossorigin", new HtmlString("anonymous"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("integrity", new HtmlString("sha512-GQGU0fMMi238uA+a/bdWJfpUGKUkBdgfFdgBm72SUQ6BeyWjoY/ton0tEjH+OSH9iP4Dfh+7HM0I9f5eR0L/4w=="), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("asp-fallback-href", "~/lib/bootstrap/css/bootstrap.min.css", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("asp-fallback-test-class", "dropdown-menu", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("asp-fallback-test-property", "position", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("asp-fallback-test-value", "absolute", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("integrity", new HtmlString("sha512-pax4MlgXjHEPfCwcJLQhigY7+N8rt6bVvWLFyUMuxShv170X53TRzGPmPkZmGBhk+jikR8WBM4yl7A9WMHHqvg=="), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("asp-fallback-src", "~/lib/bootstrap/js/bootstrap.bundle.min.js", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("asp-fallback-test", "window.bootstrap", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_13 = new TagHelperAttribute("class", new HtmlString("navbar-brand"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_14 = new TagHelperAttribute("asp-controller", "User", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_15 = new TagHelperAttribute("asp-action", "Index", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_16 = new TagHelperAttribute("class", new HtmlString("nav-link"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_17 = new TagHelperAttribute("asp-controller", "Account", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_18 = new TagHelperAttribute("asp-action", "About", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_19 = new TagHelperAttribute("href", new HtmlString("~/static/Donate.html"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_20 = new TagHelperAttribute("target", new HtmlString("_blank"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_21 = new TagHelperAttribute("class", new HtmlString("dropdown-item"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_22 = new TagHelperAttribute("asp-controller", "Admin", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_23 = new TagHelperAttribute("asp-action", "Search", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_24 = new TagHelperAttribute("asp-action", "UserList", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_25 = new TagHelperAttribute("asp-action", "EXAccountList", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_26 = new TagHelperAttribute("asp-route-id", "1", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_27 = new TagHelperAttribute("asp-controller", "System", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_28 = new TagHelperAttribute("asp-action", "Setting", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_29 = new TagHelperAttribute("asp-action", "Monitor", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_30 = new TagHelperAttribute("method", "post", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_31 = new TagHelperAttribute("asp-action", "Logout", HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;

	private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

	private LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;

	private ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;

	private BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;

	private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;

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
	public SignInManager<AppUser> _signInManager { get; private set; }

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
		bool UserIsLogin = false;
		bool UserIsAdmin = false;
		int UserStatus = -1;
		string UserName = "";
		if (User != null && _signInManager.IsSignedIn(User))
		{
			UserIsLogin = true;
			if (User.IsInRole("Admin"))
			{
				UserIsAdmin = true;
			}
			AppUser appUser = await _signInManager.UserManager.FindByIdAsync(User.Identity.Name);
			UserStatus = appUser.Status;
			UserName = appUser.Name;
		}
		WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5915936", async delegate
		{
			WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" charset=\"utf-8\" />\r\n    <title>");
			Write(base.ViewBag.Title);
			WriteLiteral("</title>\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", TagMode.SelfClosing, "e455e55a48373dc671796808b2011f214b9c7b5916546", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<LinkTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", TagMode.SelfClosing, "e455e55a48373dc671796808b2011f214b9c7b5918659", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<LinkTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
			BeginWriteTagHelperAttribute();
			WriteLiteral(SystemConfig.Static.Serivce.CDN.CSS);
			__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = __tagHelperStringValueBuffer;
			__tagHelperExecutionContext.AddTagHelperAttribute("href", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href, HtmlAttributeValueStyle.DoubleQuotes);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.FallbackHref = (string)__tagHelperAttribute_6.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.FallbackTestClass = (string)__tagHelperAttribute_7.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.FallbackTestProperty = (string)__tagHelperAttribute_8.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.FallbackTestValue = (string)__tagHelperAttribute_9.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.SuppressFallbackIntegrity = true;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-suppress-fallback-integrity", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.SuppressFallbackIntegrity, HtmlAttributeValueStyle.DoubleQuotes);
			__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5922412", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<ScriptTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
			BeginWriteTagHelperAttribute();
			WriteLiteral(SystemConfig.Static.Serivce.CDN.JS);
			__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = __tagHelperStringValueBuffer;
			__tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src, HtmlAttributeValueStyle.DoubleQuotes);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.FallbackSrc = (string)__tagHelperAttribute_11.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.FallbackTestExpression = (string)__tagHelperAttribute_12.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.SuppressFallbackIntegrity = true;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-suppress-fallback-integrity", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.SuppressFallbackIntegrity, HtmlAttributeValueStyle.DoubleQuotes);
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n\r\n");
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<HeadTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5926379", async delegate
		{
			WriteLiteral("\r\n\r\n\r\n    <nav class=\"navbar navbar-expand-lg bg-dark navbar-dark fixed-top\">\r\n        <div class=\"container-fluid\">\r\n            ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5926778", async delegate
			{
				WriteLiteral("\r\n\r\n                <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"30\" height=\"28\" viewBox=\"0 10 96 90\">\r\n                    <defs>\r\n                        <linearGradient id=\"e399c19f-b68f-429d-b176-18c2117ff73c\" x1=\"-1032.172\" x2=\"-1059.213\" y1=\"145.312\" y2=\"65.426\" gradientTransform=\"matrix(1 0 0 -1 1075 158)\" gradientUnits=\"userSpaceOnUse\"><stop offset=\"0\" stop-color=\"#114a8b\" /><stop offset=\"1\" stop-color=\"#0669bc\" /></linearGradient>\r\n                        <linearGradient id=\"ac2a6fc2-ca48-4327-9a3c-d4dcc3256e15\" x1=\"-1023.725\" x2=\"-1029.98\" y1=\"108.083\" y2=\"105.968\" gradientTransform=\"matrix(1 0 0 -1 1075 158)\" gradientUnits=\"userSpaceOnUse\"><stop offset=\"0\" stop-opacity=\".3\" /><stop offset=\".071\" stop-opacity=\".2\" /><stop offset=\".321\" stop-opacity=\".1\" /><stop offset=\".623\" stop-opacity=\".05\" /><stop offset=\"1\" stop-opacity=\"0\" /></linearGradient>\r\n                        <linearGradient id=\"a7fee970-a784-4bb1-af8d-63d18e5f7db9\" x1=\"-1027.165\" x2=\"-997.482\" y1=\"147.642\" y2=\"68.561\" gradientTransf");
				WriteLiteral("orm=\"matrix(1 0 0 -1 1075 158)\" gradientUnits=\"userSpaceOnUse\"><stop offset=\"0\" stop-color=\"#3ccbf4\" /><stop offset=\"1\" stop-color=\"#2892df\" /></linearGradient>\r\n                    </defs>\r\n                    <path fill=\"url(#e399c19f-b68f-429d-b176-18c2117ff73c)\" d=\"M33.338 6.544h26.038l-27.03 80.087a4.152 4.152 0 0 1-3.933 2.824H8.149a4.145 4.145 0 0 1-3.928-5.47L29.404 9.368a4.152 4.152 0 0 1 3.934-2.825z\" />\r\n                    <path fill=\"#0078d4\" d=\"M71.175 60.261h-41.29a1.911 1.911 0 0 0-1.305 3.309l26.532 24.764a4.171 4.171 0 0 0 2.846 1.121h23.38z\" />\r\n                    <path fill=\"url(#ac2a6fc2-ca48-4327-9a3c-d4dcc3256e15)\" d=\"M33.338 6.544a4.118 4.118 0 0 0-3.943 2.879L4.252 83.917a4.14 4.14 0 0 0 3.908 5.538h20.787a4.443 4.443 0 0 0 3.41-2.9l5.014-14.777 17.91 16.705a4.237 4.237 0 0 0 2.666.972H81.24L71.024 60.261l-29.781.007L59.47 6.544z\" />\r\n                    <path fill=\"url(#a7fee970-a784-4bb1-af8d-63d18e5f7db9)\" d=\"M66.595 9.364a4.145 4.145 0 0 0-3.928-2.82H33.648a4.146 4.146 0 0 1 3.92");
				WriteLiteral("8 2.82l25.184 74.62a4.146 4.146 0 0 1-3.928 5.472h29.02a4.146 4.146 0 0 0 3.927-5.472z\" />\r\n                </svg>\r\n                <b>MS365 E5 Renew X</b>\r\n            ");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_14.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_15.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_15);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n\r\n            <button class=\"navbar-toggler collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapsibleNavbar\" aria-controls=\"collapsibleNavbar\" aria-expanded=\"false\">\r\n                <span class=\"navbar-toggler-icon\"></span>\r\n            </button>\r\n\r\n            <div class=\"collapse navbar-collapse justify-content-between \" id=\"collapsibleNavbar\">\r\n\r\n                <ul class=\"navbar-nav\">\r\n                    <li class=\"nav-item \">\r\n                        <a class=\"nav-link\" target=\"_blank\" href=\"https://e5renew.com/\">");
			Write(Lang.Get("下载桌面版"));
			WriteLiteral("</a>\r\n                    </li>\r\n                    <li class=\"nav-item dropdown\">\r\n                        <a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdownMenuLink\" data-bs-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\"> ");
			Write(Lang.Get("快速链接"));
			WriteLiteral(" </a>\r\n                        <div class=\"dropdown-menu dropdown-menu-dark dropdown-menu-start\" aria-labelledby=\"navbarDropdownMenuLink\">\r\n                            <a class=\"dropdown-item\" target=\"_blank\" href=\"https://developer.microsoft.com/zh-cn/microsoft-365/profile\">");
			Write(Lang.Get("查看E5账号剩余天数"));
			WriteLiteral("</a>\r\n                            <a class=\"dropdown-item\" target=\"_blank\" href=\"https://www.office.com/?auth=2\">");
			Write(Lang.Get("Office 365主页"));
			WriteLiteral("</a>\r\n                            <a class=\"dropdown-item\" target=\"_blank\" href=\"https://admin.microsoft.com\">");
			Write(Lang.Get("E5 管理员中心"));
			WriteLiteral("</a>\r\n                            <a class=\"dropdown-item\" target=\"_blank\" href=\"https://portal.azure.com/#home\">");
			Write(Lang.Get("Azure 主页"));
			WriteLiteral("</a>\r\n                            <a class=\"dropdown-item\" target=\"_blank\" href=\"https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade\">");
			Write(Lang.Get("Azure 应用注册"));
			WriteLiteral("</a>\r\n                            <a class=\"dropdown-item\" target=\"_blank\" href=\"https://aad.portal.azure.com/#blade/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/Overview\">");
			Write(Lang.Get("关闭Azure AD双重验证"));
			WriteLiteral("</a>\r\n                            <a class=\"dropdown-item\" target=\"_blank\" href=\"https://admin.onedrive.com/?v=StorageSettings\">");
			Write(Lang.Get("OneDrive 存储设置"));
			WriteLiteral("</a>\r\n                        </div>\r\n                    </li>\r\n\r\n                    <li class=\"nav-item\">\r\n                        <a class=\"nav-link\" href=\"https://blog.csdn.net/qq_33212020/article/details/119747634\" target=\"_blank\">");
			Write(Lang.Get("使用帮助"));
			WriteLiteral("</a>\r\n                    </li>\r\n                    <li class=\"nav-item\">\r\n                        ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5936536", async delegate
			{
				Write(Lang.Get("关于"));
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_17.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_17);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_18.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_18);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n                    </li>\r\n                    <li class=\"nav-item\">\r\n                        ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5938384", async delegate
			{
				Write(Lang.Get("捐助支持"));
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_19);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_20);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n                    </li>\r\n                </ul>\r\n                <ul class=\"navbar-nav\"></ul>\r\n                <ul class=\"navbar-nav\">\r\n");
			if (UserIsAdmin && UserStatus == 1)
			{
				WriteLiteral("                            <li class=\"nav-item dropdown\">\r\n                                <a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdownMenuLink\" data-bs-toggle=\"dropdown\" data-bs-auto-close=\"false\" aria-expanded=\"false\">");
				Write(Lang.Get("管理员功能"));
				WriteLiteral("</a>\r\n                                <div class=\"dropdown-menu dropdown-menu-dark\" aria-labelledby=\"navbarDropdownMenuLink\">\r\n                                    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5941175", async delegate
				{
					Write(Lang.Get("全站查询"));
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_21);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_22.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_22);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_23.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_23);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                                    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5942978", async delegate
				{
					Write(Lang.Get("用户列表"));
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_21);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_22.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_22);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_24.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_24);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                                    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5944783", async delegate
				{
					Write(Lang.Get("运行账号列表"));
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_21);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_22.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_22);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_25.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_25);
				if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)__tagHelperAttribute_26.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_26);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                                    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5947148", async delegate
				{
					Write(Lang.Get("系统设置"));
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_21);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_27.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_27);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_28.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_28);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                                    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5948953", async delegate
				{
					Write(Lang.Get("系统监视"));
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_21);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_27.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_27);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_29.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_29);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n\r\n\r\n\r\n                                </div>\r\n                            </li>\r\n");
			}
			if (UserIsLogin)
			{
				WriteLiteral("                            <li class=\"nav-item\">\r\n                                <a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdownMenuLink\" data-bs-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n                                    <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"30\" height=\"26\" fill=\"#CDCDCD\" class=\"bi bi-person-circle\" viewBox=\"0 0 18 18\">\r\n                                        <path d=\"M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z\" />\r\n                                        <path fill-rule=\"evenodd\" d=\"M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z\" />\r\n                                    </svg>\r\n                                ");
				Write(UserName);
				WriteLiteral("\r\n                                </a>\r\n                                <ul class=\"dropdown-menu dropdown-menu-dark dropdown-menu-end\" aria-labelledby=\"navbarDropdownMenuLink\">\r\n                                    <li>\r\n                                        ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5952552", async delegate
				{
					Write(Lang.Get("账户设置"));
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_21);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_14.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_28.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_28);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                                    </li>\r\n                                    <li>\r\n                                        ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "e455e55a48373dc671796808b2011f214b9c7b5954452", async delegate
				{
					WriteLiteral("\r\n                                            <button type=\"submit\" class=\"dropdown-item\">");
					Write(Lang.Get("退出登录"));
					WriteLiteral("</button>\r\n                                        ");
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_30.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_30);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_17.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_17);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_31.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_31);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                                    <li>\r\n                                </ul>\r\n                            </li>\r\n");
			}
			WriteLiteral("\r\n\r\n                </ul>\r\n\r\n\r\n\r\n\r\n            </div>\r\n\r\n\r\n\r\n        </div>\r\n    </nav>\r\n    <br>\r\n    <br>\r\n    <br>\r\n    <br>\r\n    <div class=\"container-lg\">\r\n        ");
			Write(RenderBody());
			WriteLiteral("\r\n    </div>\r\n    <br>\r\n    <br>\r\n    <br>\r\n    <br>\r\n\r\n    <div class=\"fixed-bottom\">\r\n        <div style=\"text-align:center\">\r\n            <a style=\"color:#9292AE;font-size:10px;text-decoration:none;\"");
			BeginWriteAttribute("href", " href=\"", 10400, "\"", 10444, 1);
			WriteAttributeValue("", 10407, SystemConfig.Static.Serivce.ICP.Link, 10407, 37, isLiteral: false);
			EndWriteAttribute();
			WriteLiteral(" target=\"_blank\">");
			Write(SystemConfig.Static.Serivce.ICP.Text);
			WriteLiteral("</a>\r\n        </div>\r\n        <div>\r\n");
			if (SystemConfig.Static.ShareSite.Enable)
			{
				WriteLiteral("                    <a class=\"card-text bg-dark  text-white text-right\" style=\"text-align:right;text-decoration:none;display:block;\"");
				BeginWriteAttribute("href", " href=\"", 10739, "\"", 10794, 1);
				WriteAttributeValue("", 10746, SystemConfig.Static.ShareSite.System.MasterLink, 10746, 48, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" target=\"_blank\">");
				Write(Lang.Get("本站由"));
				WriteLiteral(" ");
				Write(SystemConfig.Static.ShareSite.System.Master);
				WriteLiteral(" ");
				Write(Lang.Get("运营"));
				WriteLiteral("&ensp;</a>\r\n");
			}
			WriteLiteral("        </div>\r\n    </div>\r\n\r\n\r\n\r\n");
			if (IsSectionDefined("Scripts"))
			{
				Write(RenderSection("Scripts", required: false));
			}
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<BodyTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n</html>");
	}
}
