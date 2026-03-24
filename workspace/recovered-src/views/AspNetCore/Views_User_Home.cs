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
using Microsoft365_E5_Renew_X.ViewModels.User;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "f00566a2d09cb74731f937bc3133c79ea2470834", "/Views/User/Home.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "74d4abd4e1f0bef76f750de100d06c88774fff8e", "/Views/User/_ViewImports.cshtml")]
public class Views_User_Home : RazorPage<HomeViewModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("class", new HtmlString("btn btn-primary btn-block"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("asp-controller", "User", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-action", "AddEXAccount", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("asp-action", "ModifyEXAccount", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("class", new HtmlString("form-inline"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("method", "post", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("asp-action", "DeleteEXAccount", HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

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
	public IHtmlHelper<HomeViewModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n");
		base.ViewBag.Title = Lang.Get("主页");
		WriteLiteral("\r\n<svg xmlns=\"http://www.w3.org/2000/svg\" style=\"display: none;\">\r\n    <symbol id=\"check-circle-fill\" fill=\"currentColor\" viewBox=\"0 0 16 16\">\r\n        <path d=\"M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z\" />\r\n    </symbol>\r\n    <symbol id=\"info-fill\" fill=\"currentColor\" viewBox=\"0 0 16 16\">\r\n        <path d=\"M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm.93-9.412-1 4.705c-.07.34.029.533.304.533.194 0 .487-.07.686-.246l-.088.416c-.287.346-.92.598-1.465.598-.703 0-1.002-.422-.808-1.319l.738-3.468c.064-.293.006-.399-.287-.47l-.451-.081.082-.381 2.29-.287zM8 5.5a1 1 0 1 1 0-2 1 1 0 0 1 0 2z\" />\r\n    </symbol>\r\n    <symbol id=\"exclamation-triangle-fill\" fill=\"currentColor\" viewBox=\"0 0 16 16\">\r\n        <path d=\"M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.");
		WriteLiteral("1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z\" />\r\n    </symbol>\r\n</svg>\r\n\r\n\r\n\r\n");
		if (base.Model.NoticeMessage != null && base.Model.NoticeMessage.Length != 0)
		{
			WriteLiteral("    <div class=\"alert alert-primary d-flex align-items-center\" role=\"alert\">\r\n        <svg class=\"bi flex-shrink-0 me-2\" width=\"24\" height=\"24\" role=\"img\" aria-label=\"Info:\" ><use xlink:href=\"#info-fill\" /></svg>\r\n        <div style=\"font-weight:bold;\">\r\n");
			string[] noticeMessage = base.Model.NoticeMessage;
			foreach (string value in noticeMessage)
			{
				Write(value);
				WriteLiteral("            <br/>\r\n");
			}
			WriteLiteral("        </div>\r\n    </div>\r\n");
		}
		WriteLiteral("\r\n<hr />\r\n");
		if (base.Model.OverviewStatus == -1)
		{
			WriteLiteral("    <div class=\"alert alert-danger d-flex align-items-center\" role=\"alert\">\r\n        <svg class=\"bi flex-shrink-0 me-2\" width=\"24\" height=\"24\" role=\"img\" aria-label=\"Danger:\"><use xlink:href=\"#exclamation-triangle-fill\" /></svg>\r\n        <div style=\"font-weight:bold;\">\r\n            ");
			Write(base.Model.Overview);
			WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
		}
		else if (base.Model.OverviewStatus == 0)
		{
			WriteLiteral("    <div class=\"alert alert-warning d-flex align-items-center\" role=\"alert\">\r\n        <svg class=\"bi flex-shrink-0 me-2\" width=\"24\" height=\"24\" role=\"img\" aria-label=\"Warning:\"><use xlink:href=\"#info-fill\" /></svg>\r\n        <div style=\"font-weight:bold;\">\r\n            ");
			Write(base.Model.Overview);
			WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
		}
		else if (base.Model.OverviewStatus == 1)
		{
			WriteLiteral("    <div class=\"alert alert-success d-flex align-items-center\" role=\"alert\">\r\n        <svg class=\"bi flex-shrink-0 me-2\" width=\"24\" height=\"24\" role=\"img\" aria-label=\"Success:\"><use xlink:href=\"#check-circle-fill\" /></svg>\r\n        <div>\r\n            ");
			Write(base.Model.Overview);
			WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
		}
		WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-auto\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "f00566a2d09cb74731f937bc3133c79ea247083412034", async delegate
		{
			Write(Lang.Get("添加运行账号"));
		});
		__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
		__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
		__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n    <div class=\"col\">\r\n        <p style=\"text-align:right; font-weight:bold;margin-top:5px;\">账号额度已使用： ");
		Write(base.Model.EXAccountDetails.Count);
		WriteLiteral("|");
		Write(base.Model.Quota);
		WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n<hr />\r\n");
		foreach (HomeViewModel.EXAccountViewModel var in base.Model.EXAccountDetails)
		{
			WriteLiteral("    <div class=\"accordion\">\r\n        <div class=\"accordion-item\">\r\n            <h2 class=\"accordion-header\">\r\n                <button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#UID-");
			Write(var.Id);
			WriteLiteral("\" aria-expanded=\"false\"");
			BeginWriteAttribute("aria-controls", " aria-controls=\"", 3440, "\"", 3467, 2);
			WriteAttributeValue("", 3456, "UID-", 3456, 4, isLiteral: true);
			WriteAttributeValue("", 3460, var.Id, 3460, 7, isLiteral: false);
			EndWriteAttribute();
			WriteLiteral(">\r\n                    <p class=\"h5\" style=\"margin-top:7px;\">\r\n\r\n");
			if (var.IsSynchronized)
			{
				if (!var.IsPaused)
				{
					if (var.IsLogin)
					{
						WriteLiteral("                                    <vi style=\"color:#007ACC;font-weight:bold;\">");
						Write(var.UserName);
						WriteLiteral("</vi>\r\n");
					}
					else
					{
						WriteLiteral("                                    <vi style=\"color:#009999;font-weight:bold;\">");
						Write(var.UserName);
						WriteLiteral("</vi>\r\n");
					}
				}
				else
				{
					WriteLiteral("                                <vi style=\"color:#DC3545;font-weight:bold;\">");
					Write(var.UserName);
					WriteLiteral("</vi>\r\n");
				}
			}
			else
			{
				WriteLiteral("                            <vi style=\"color:#FFC107;font-weight:bold;\">");
				Write(var.UserName);
				WriteLiteral("</vi>\r\n");
			}
			WriteLiteral("\r\n\r\n                    </p>\r\n\r\n                </button>\r\n            </h2>\r\n            <div");
			BeginWriteAttribute("id", " id=\"", 4645, "\"", 4661, 2);
			WriteAttributeValue("", 4650, "UID-", 4650, 4, isLiteral: true);
			WriteAttributeValue("", 4654, var.Id, 4654, 7, isLiteral: false);
			EndWriteAttribute();
			WriteLiteral(" class=\"accordion-collapse collapse\" aria-labelledby=\"headingOne\">\r\n                <div class=\"accordion-body\">\r\n                    <div class=\"container\">\r\n\r\n                        <div class=\"row\">\r\n\r\n                            <div class=\"col-sm-8 col-md-9 col-lg-9 col-xl-10 col-xxl-10\">\r\n\r\n                                <p class=\"h4\">\r\n                                    <vi style=\"color:#000000;\">");
			Write(Lang.Get("当前状态"));
			WriteLiteral("：</vi>\r\n");
			if (var.IsSynchronized)
			{
				if (var.IsPaused)
				{
					WriteLiteral("                                            <vi style=\"color:#DC3545;\">");
					Write(Lang.Get("已暂停"));
					WriteLiteral(" (");
					Write(var.PausedReason);
					WriteLiteral(")</vi>\r\n");
				}
				else
				{
					WriteLiteral("                                            <vi style=\"color:#198754;\">");
					Write(Lang.Get("正在运行"));
					WriteLiteral("</vi>\r\n");
				}
			}
			else
			{
				WriteLiteral("                                        <vi style=\"color:#FFC107;\">");
				Write(Lang.Get("等待后台同步配置信息"));
				WriteLiteral("</vi>\r\n");
			}
			WriteLiteral("\r\n\r\n\r\n                                </p>\r\n\r\n                            </div>\r\n\r\n\r\n\r\n                            <div class=\"col\" style=\"text-align:right;\">\r\n                                ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "f00566a2d09cb74731f937bc3133c79ea247083423764", async delegate
			{
				Write(Lang.Get("编辑"));
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
			if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			BeginWriteTagHelperAttribute();
			WriteLiteral("UID-");
			WriteLiteral(var.Id);
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
			WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col\" style=\"text-align:right;\">\r\n                                ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "f00566a2d09cb74731f937bc3133c79ea247083426749", async delegate
			{
				WriteLiteral("\r\n                                    <button type=\"submit\" class=\"btn btn-danger\">\r\n                                        ");
				Write(Lang.Get("删除"));
				WriteLiteral("\r\n                                    </button>\r\n                                ");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
			if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
			}
			BeginWriteTagHelperAttribute();
			WriteLiteral("UID-");
			WriteLiteral(var.Id);
			__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n                            </div>\r\n\r\n\r\n\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <div class=\"col-6\">\r\n                                <p class=\"h4\">\r\n                                    <vi style=\"color:#000000;\">");
			Write(Lang.Get("调用方式"));
			WriteLiteral("：</vi>\r\n");
			if (var.IsLogin)
			{
				WriteLiteral("                                        <vi style=\"color:#007ACC;\">登录调用</vi>\r\n");
			}
			else
			{
				WriteLiteral("                                        <vi style=\"color:#009999;\">非登录调用</vi>\r\n");
			}
			WriteLiteral("\r\n                                </p>\r\n                            </div>\r\n\r\n                            <div class=\" col-6\">\r\n                                <p class=\"h4\">\r\n                                    <vi style=\"color:#000000;\">");
			Write(Lang.Get("创建时间"));
			WriteLiteral("：</vi>\r\n                                    <vi style=\"color:#000000;\">");
			Write(var.CreatedDate.ToString("yy-MM-dd HH:mm:ss zz"));
			WriteLiteral("</vi>\r\n                                </p>\r\n                            </div>\r\n                        </div>\r\n\r\n");
			if (var.IsSynchronized)
			{
				WriteLiteral("                            <div class=\"row\">\r\n                                <div class=\"col-6\">\r\n                                    <p class=\"h4\">\r\n                                        <vi style=\"color:#000000;\">");
				Write(Lang.Get("上次调用时间"));
				WriteLiteral("：</vi>\r\n                                        <vi style=\"color:#000000;\">");
				Write(var.Date.ToString("yy-MM-dd HH:mm:ss zz"));
				WriteLiteral("</vi>\r\n                                    </p>\r\n                                </div>\r\n\r\n                                <div class=\" col-6\">\r\n                                    <p class=\"h4\">\r\n                                        <vi style=\"color:#000000;\">");
				Write(Lang.Get("上次调用统计"));
				WriteLiteral("：</vi>\r\n                                        <vi style=\"color:#0D6EFD;\">");
				Write(var.Request);
				WriteLiteral(" </vi>\r\n                                        <vi>|</vi>\r\n                                        <vi style=\"color:#198754;\">");
				Write(var.Success);
				WriteLiteral("</vi>\r\n                                        <vi>|</vi>\r\n                                        <vi style=\"color:#DC3545;\">");
				Write(var.Fail);
				WriteLiteral("</vi>\r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n");
				WriteLiteral("                            <div class=\"row\">\r\n                                <div class=\"col-sm-6\">\r\n                                    <p class=\"h4\">\r\n                                        <vi style=\"color:#000000;\">");
				Write(Lang.Get("下次调用时间"));
				WriteLiteral("：</vi>\r\n");
				if (var.IsPaused)
				{
					WriteLiteral("                                            <vi style=\"color:#000000;\">NA</vi>\r\n");
				}
				else
				{
					WriteLiteral("                                            <vi style=\"color:#000000;\">");
					Write(var.NextDate.ToString("yy-MM-dd HH:mm:ss zz"));
					WriteLiteral("</vi>\r\n");
				}
				WriteLiteral("                                    </p>\r\n                                </div>\r\n\r\n                                <div class=\" col-sm-6\">\r\n                                    <p class=\"h4\">\r\n                                        <vi style=\"color:#000000;\">");
				Write(Lang.Get("今日调用统计"));
				WriteLiteral("：</vi>\r\n                                        <vi style=\"color:#0D6EFD;\">");
				Write(var.TodayRequest);
				WriteLiteral(" </vi>\r\n                                        <vi>|</vi>\r\n                                        <vi style=\"color:#198754;\">");
				Write(var.TodaySuccess);
				WriteLiteral("</vi>\r\n                                        <vi>|</vi>\r\n                                        <vi style=\"color:#DC3545;\">");
				Write(var.TodayFail);
				WriteLiteral("</vi>\r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n");
				if (var.Logs.Count > 0)
				{
					WriteLiteral("                                <hr />\r\n                                <div class=\"row\">\r\n                                    <div class=\"col-8 col-sm-8 col-md-8 col-lg-6 col-xl-6\">\r\n                                        <h4>");
					Write(Lang.Get("API名称"));
					WriteLiteral("</h4>\r\n                                    </div>\r\n                                    <div class=\"col-2 col-sm-2 col-md-2 col-lg-4 col-xl-4\">\r\n                                        <h4>");
					Write(Lang.Get("响应"));
					WriteLiteral("</h4>\r\n                                    </div>\r\n                                    <div class=\"col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2\">\r\n                                        <h4>");
					Write(Lang.Get("结果"));
					WriteLiteral("</h4>\r\n                                    </div>\r\n                                </div>\r\n                                <hr />\r\n");
					foreach (HomeViewModel.EXAccountViewModel.LogViewModel log in var.Logs)
					{
						WriteLiteral("                                    <div class=\"row\">\r\n                                        <div class=\"col-8 col-sm-8 col-md-8 col-lg-6 col-xl-6\">\r\n");
						if (log.IsSuccess)
						{
							WriteLiteral("                                                <h5>");
							Write(log.API);
							WriteLiteral("</h5>\r\n");
						}
						else
						{
							WriteLiteral("                                                <h5 class=\"text-danger\">");
							Write(log.API);
							WriteLiteral("</h5>\r\n");
						}
						WriteLiteral("\r\n                                        </div>\r\n                                        <div class=\"col-2 col-sm-2 col-md-2 col-lg-4 col-xl-4\">\r\n");
						if (log.IsSuccess)
						{
							WriteLiteral("                                                <h5>");
							Write(log.Result);
							WriteLiteral("</h5>\r\n");
						}
						else
						{
							WriteLiteral("                                                <h5 class=\"text-danger\">");
							Write(log.Result);
							WriteLiteral("</h5>\r\n");
						}
						WriteLiteral("                                        </div>\r\n                                        <div class=\"col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2\">\r\n");
						if (log.IsSuccess)
						{
							WriteLiteral("                                                <h5>");
							Write(Lang.Get("成功"));
							WriteLiteral("</h5>\r\n");
						}
						else
						{
							WriteLiteral("                                                <h5 class=\"text-danger\">");
							Write(Lang.Get("失败"));
							WriteLiteral("</h5>\r\n");
						}
						WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n");
					}
				}
			}
			WriteLiteral("\r\n\r\n\r\n\r\n\r\n                    </div>\r\n\r\n\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
		}
		WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
	}
}
