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

[RazorSourceChecksum("SHA1", "a1c3ae457eb50f13508c057f48db46e016979d17", "/Views/Admin/User.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "cb2fd25cde740f6cb9ddef4bf2af6ae15710d297", "/Views/Admin/_ViewImports.cshtml")]
public class Views_Admin_User : RazorPage<UserViewModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("class", new HtmlString("form-control"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("type", "text", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("id", new HtmlString("validationServer01"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("placeholder", new HtmlString("请输入UID"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("maxlength", new HtmlString("36"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("class", new HtmlString("text-danger"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("class", new HtmlString("form-control is-valid"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("placeholder", new HtmlString("请输入用户名"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("maxlength", new HtmlString("32"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("placeholder", new HtmlString("请输入OAuth登录关联账户"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("type", "number", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("placeholder", new HtmlString("请输入配额"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("min", new HtmlString("1"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_13 = new TagHelperAttribute("max", new HtmlString("999"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_14 = new TagHelperAttribute("placeholder", new HtmlString("请输入邮箱地址"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_15 = new TagHelperAttribute("maxlength", new HtmlString("64"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_16 = new TagHelperAttribute("class", new HtmlString("btn btn-primary btn-block"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_17 = new TagHelperAttribute("asp-controller", "Admin", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_18 = new TagHelperAttribute("asp-action", "UserList", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_19 = new TagHelperAttribute("class", new HtmlString("row was-validated"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_20 = new TagHelperAttribute("method", "post", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_21 = new TagHelperAttribute("asp-action", "User", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_22 = new TagHelperAttribute("asp-action", "EXAccount", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_23 = new TagHelperAttribute("class", new HtmlString("form-inline"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_24 = new TagHelperAttribute("asp-action", "UnBlockUser", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_25 = new TagHelperAttribute("asp-action", "BlockUser", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_26 = new TagHelperAttribute("asp-action", "DeleteUser", HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;

	private RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;

	private InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;

	private ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;

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
	public IHtmlHelper<UserViewModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n");
		base.ViewBag.Title = Lang.Get("用户详情");
		WriteLiteral("\r\n\r\n<h1>用户详情</h1>\r\n<hr />\r\n\r\n\r\n\r\n\r\n\r\n");
		if (base.Model.IsShow)
		{
			WriteLiteral("    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1714167", async delegate
			{
				WriteLiteral("\r\n        <div class=\"input-group mb-3\">\r\n            <span class=\"input-group-text\" for=\"validationServer01\">UID</span>\r\n            ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", TagMode.StartTagOnly, "a1c3ae457eb50f13508c057f48db46e016979d1714568", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<InputTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.Id);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				BeginWriteTagHelperAttribute();
				WriteLiteral(base.Model.Id);
				__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
				__tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
				BeginWriteTagHelperAttribute();
				__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
				__tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), HtmlAttributeValueStyle.Minimized);
				BeginWriteTagHelperAttribute();
				__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
				__tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), HtmlAttributeValueStyle.Minimized);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            <button class=\"btn btn-danger btn-block\"data-bs-toggle=\"modal\" data-bs-target=\"#myModal2\" type=\"button\">");
				Write(Lang.Get("删除数据"));
				WriteLiteral(" </button>\r\n            <div class=\"valid-feedback\">\r\n                ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1718505", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<ValidationMessageTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.Id);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"input-group mb-3\">\r\n            <span class=\"input-group-text\" for=\"validationServer01\">用户名</span>\r\n            ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", TagMode.StartTagOnly, "a1c3ae457eb50f13508c057f48db46e016979d1720331", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<InputTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.Name);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				BeginWriteTagHelperAttribute();
				WriteLiteral(base.Model.Name);
				__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
				__tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
				BeginWriteTagHelperAttribute();
				__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
				__tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), HtmlAttributeValueStyle.Minimized);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            <div class=\"valid-feedback\">\r\n                ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1723494", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<ValidationMessageTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.Name);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"input-group mb-3\">\r\n            <span class=\"input-group-text\" for=\"validationServer01\">OAuth登录关联账户</span>\r\n");
				if (base.Model.IsEditOAuthId)
				{
					WriteLiteral("                ");
					__tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", TagMode.StartTagOnly, "a1c3ae457eb50f13508c057f48db46e016979d1725576", async delegate
					{
					});
					__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<InputTagHelper>();
					__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
					__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
					__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
					__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
					__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
					__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.OAuthId);
					__tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
					BeginWriteTagHelperAttribute();
					WriteLiteral(base.Model.OAuthId);
					__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
					__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
					__tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, HtmlAttributeValueStyle.DoubleQuotes);
					__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
					__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
					BeginWriteTagHelperAttribute();
					__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
					__tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), HtmlAttributeValueStyle.Minimized);
					await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
					if (!__tagHelperExecutionContext.Output.IsContentModified)
					{
						await __tagHelperExecutionContext.SetOutputContentAsync();
					}
					Write(__tagHelperExecutionContext.Output);
					__tagHelperExecutionContext = __tagHelperScopeManager.End();
					WriteLiteral("\r\n");
				}
				else
				{
					WriteLiteral("                ");
					__tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", TagMode.StartTagOnly, "a1c3ae457eb50f13508c057f48db46e016979d1728945", async delegate
					{
					});
					__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<InputTagHelper>();
					__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
					__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
					__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
					__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
					__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
					__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.OAuthId);
					__tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
					BeginWriteTagHelperAttribute();
					WriteLiteral(base.Model.OAuthId);
					__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
					__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
					__tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, HtmlAttributeValueStyle.DoubleQuotes);
					__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
					__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
					BeginWriteTagHelperAttribute();
					__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
					__tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), HtmlAttributeValueStyle.Minimized);
					BeginWriteTagHelperAttribute();
					__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
					__tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), HtmlAttributeValueStyle.Minimized);
					await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
					if (!__tagHelperExecutionContext.Output.IsContentModified)
					{
						await __tagHelperExecutionContext.SetOutputContentAsync();
					}
					Write(__tagHelperExecutionContext.Output);
					__tagHelperExecutionContext = __tagHelperScopeManager.End();
					WriteLiteral("\r\n");
				}
				WriteLiteral("\r\n            <div class=\"valid-feedback\">\r\n                ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1732645", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<ValidationMessageTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.OAuthId);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"input-group mb-3\">\r\n            <span class=\"input-group-text\" for=\"validationServer01\">账户配额</span>\r\n            ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", TagMode.StartTagOnly, "a1c3ae457eb50f13508c057f48db46e016979d1734473", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<InputTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_10.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.Quota);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				BeginWriteTagHelperAttribute();
				WriteLiteral(base.Model.Quota);
				__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
				__tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
				BeginWriteTagHelperAttribute();
				__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
				__tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), HtmlAttributeValueStyle.Minimized);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            <div class=\"valid-feedback\">\r\n                ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1737733", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<ValidationMessageTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.Quota);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"input-group mb-3\">\r\n            <span class=\"input-group-text\" for=\"validationServer01\">通知邮箱</span>\r\n            ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", TagMode.StartTagOnly, "a1c3ae457eb50f13508c057f48db46e016979d1739559", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<InputTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.Email);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				BeginWriteTagHelperAttribute();
				WriteLiteral(base.Model.Email);
				__tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
				__tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            <div class=\"valid-feedback\">\r\n                ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1742404", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<ValidationMessageTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(base.ViewData, (UserViewModel __model) => __model.Email);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-6\">\r\n                <h5>注册时间：");
				Write(base.Model.RegisterDate.ToString("yy-MM-dd HH:mm:ss zz"));
				WriteLiteral("</h5>\r\n            </div>\r\n            <div class=\"col-6\">\r\n                <h5>最近一次登录时间：");
				Write(base.Model.LastLoginDate.ToString("yy-MM-dd HH:mm:ss zz"));
				WriteLiteral("</h5>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-6\">\r\n                <p class=\"h5\">\r\n                    <vi>");
				Write(Lang.Get("账号状态"));
				WriteLiteral("：</vi>\r\n");
				if (base.Model.Status == -1)
				{
					WriteLiteral("                        <vi style=\"color:#DC3545;\">已封禁 </vi>\r\n");
				}
				else if (base.Model.Status == 0)
				{
					WriteLiteral("                        <vi style=\"color:#FFC107;\">待激活</vi>\r\n");
				}
				else if (base.Model.Status == 1)
				{
					WriteLiteral("                        <vi style=\"color:#198754;\">正常</vi>\r\n");
				}
				WriteLiteral("                </p>\r\n            </div>\r\n            <div class=\"col-6\">\r\n                <p class=\"h5\">\r\n                    <vi >");
				Write(Lang.Get("配额使用情况"));
				WriteLiteral("：</vi>\r\n\r\n                        <vi >");
				Write(base.Model.EXAccountDetails.Count);
				WriteLiteral("</vi>\r\n\r\n                        <vi >|</vi>\r\n                    \r\n                        <vi style=\"color:#198754;\">");
				Write(base.Model.Quota);
				WriteLiteral("</vi>\r\n                    \r\n                </p>\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"row\">\r\n");
				if (base.Model.TipMessage != "")
				{
					if (base.Model.TipMessageIsSuccess)
					{
						WriteLiteral("                    <label class=\"text-success\">");
						Write(base.Model.TipMessage);
						WriteLiteral("</label>\r\n");
					}
					else
					{
						WriteLiteral("                    <label class=\"text-danger\">");
						Write(base.Model.TipMessage);
						WriteLiteral("</label>\r\n");
					}
				}
				WriteLiteral("        </div>\r\n        <hr />\r\n        <div class=\" row\">\r\n            <div class=\"col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2\">\r\n                ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1749302", async delegate
				{
					Write(Lang.Get("返回用户列表"));
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
				WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col-4 col-sm-4 col-md-6 col-lg-8 col-xl-8\" style=\"text-align:center;\">\r\n                <button class=\"btn btn-success btn-block\" type=\"submit\">");
				Write(Lang.Get("保存并修改"));
				WriteLiteral("</button>\r\n            </div>\r\n            <div class=\"col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2\" style=\"text-align:right;\">\r\n");
				if (base.Model.Status == -1)
				{
					WriteLiteral("                    <button class=\"btn btn-danger btn-block\"data-bs-toggle=\"modal\" data-bs-target=\"#myModal\" type=\"button\">");
					Write(Lang.Get("解封账户"));
					WriteLiteral(" </button>\r\n");
				}
				else
				{
					WriteLiteral("                    <button class=\"btn btn-danger btn-block\" data-bs-toggle=\"modal\" data-bs-target=\"#myModal\" type=\"button\">");
					Write(Lang.Get("封禁账户"));
					WriteLiteral(" </button>\r\n");
				}
				WriteLiteral("            </div>\r\n\r\n        </div>\r\n    ");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_19);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_20.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_20);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_17.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_17);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_21.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_21);
			if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
			}
			BeginWriteTagHelperAttribute();
			WriteLiteral("UID-");
			WriteLiteral(base.Model.Id);
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
			WriteLiteral("\r\n");
			WriteLiteral("    <hr />\r\n");
			foreach (UserViewModel.EXAccountViewModel var in base.Model.EXAccountDetails)
			{
				WriteLiteral("        <div class=\"accordion\">\r\n            <div class=\"accordion-item\">\r\n                <h2 class=\"accordion-header\">\r\n                    <button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#UID-");
				Write(var.Id);
				WriteLiteral("\" aria-expanded=\"false\"");
				BeginWriteAttribute("aria-controls", " aria-controls=\"", 6177, "\"", 6204, 2);
				WriteAttributeValue("", 6193, "UID-", 6193, 4, isLiteral: true);
				WriteAttributeValue("", 6197, var.Id, 6197, 7, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(">\r\n                        <p class=\"h5\" style=\"margin-top:7px;\">\r\n\r\n");
				if (var.IsSynchronized)
				{
					if (!var.IsPaused)
					{
						if (var.IsLogin)
						{
							WriteLiteral("                                        <vi style=\"color:#007ACC;font-weight:bold;\">");
							Write(var.UserName);
							WriteLiteral("</vi>\r\n");
						}
						else
						{
							WriteLiteral("                                        <vi style=\"color:#009999;font-weight:bold;\">");
							Write(var.UserName);
							WriteLiteral("</vi>\r\n");
						}
					}
					else
					{
						WriteLiteral("                                    <vi style=\"color:#DC3545;font-weight:bold;\">");
						Write(var.UserName);
						WriteLiteral("</vi>\r\n");
					}
				}
				else
				{
					WriteLiteral("                                <vi style=\"color:#FFC107;font-weight:bold;\">");
					Write(var.UserName);
					WriteLiteral("</vi>\r\n");
				}
				WriteLiteral("\r\n\r\n                        </p>\r\n\r\n                    </button>\r\n                </h2>\r\n                <div");
				BeginWriteAttribute("id", " id=\"", 7490, "\"", 7506, 2);
				WriteAttributeValue("", 7495, "UID-", 7495, 4, isLiteral: true);
				WriteAttributeValue("", 7499, var.Id, 7499, 7, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" class=\"accordion-collapse collapse\" aria-labelledby=\"headingOne\">\r\n                    <div class=\"accordion-body\">\r\n                        <div class=\"container\">\r\n\r\n                            <div class=\"row\">\r\n\r\n                                <div class=\"col-sm-8 col-md-9 col-lg-9 col-xl-10 col-xxl-10\">\r\n\r\n                                    <p class=\"h4\">\r\n                                        <vi style=\"color:#000000;\">");
				Write(Lang.Get("当前状态"));
				WriteLiteral("：</vi>\r\n");
				if (var.IsSynchronized)
				{
					if (var.IsPaused)
					{
						WriteLiteral("                                                <vi style=\"color:#DC3545;\">");
						Write(Lang.Get("已暂停"));
						WriteLiteral(" (");
						Write(var.PausedReason);
						WriteLiteral(")</vi>\r\n");
					}
					else
					{
						WriteLiteral("                                                <vi style=\"color:#198754;\">");
						Write(Lang.Get("正在运行"));
						WriteLiteral("</vi>\r\n");
					}
				}
				else
				{
					WriteLiteral("                                            <vi style=\"color:#FFC107;\">");
					Write(Lang.Get("等待后台同步配置信息"));
					WriteLiteral("</vi>\r\n");
				}
				WriteLiteral("\r\n\r\n\r\n                                    </p>\r\n\r\n                                </div>\r\n\r\n\r\n\r\n                                <div class=\"col\" style=\"text-align:right;\">\r\n                                    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1765811", async delegate
				{
					Write(Lang.Get("编辑"));
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_17.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_17);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_22.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_22);
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
				WriteLiteral("\r\n                                </div>\r\n\r\n\r\n\r\n                            </div>\r\n\r\n                            <div class=\"row\">\r\n                                <div class=\"col-6\">\r\n                                    <p class=\"h4\">\r\n                                        <vi style=\"color:#000000;\">");
				Write(Lang.Get("调用方式"));
				WriteLiteral("：</vi>\r\n");
				if (var.IsLogin)
				{
					WriteLiteral("                                            <vi style=\"color:#007ACC;\">登录调用</vi>\r\n");
				}
				else
				{
					WriteLiteral("                                            <vi style=\"color:#009999;\">非登录调用</vi>\r\n");
				}
				WriteLiteral("\r\n                                    </p>\r\n                                </div>\r\n\r\n                                <div class=\" col-6\">\r\n                                    <p class=\"h4\">\r\n                                        <vi style=\"color:#000000;\">");
				Write(Lang.Get("创建时间"));
				WriteLiteral("：</vi>\r\n                                        <vi style=\"color:#000000;\">");
				Write(var.CreatedDate.ToString("yy-MM-dd HH:mm:ss zz"));
				WriteLiteral("</vi>\r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n\r\n");
				if (var.IsSynchronized)
				{
					WriteLiteral("                                <div class=\"row\">\r\n                                    <div class=\"col-6\">\r\n                                        <p class=\"h4\">\r\n                                            <vi style=\"color:#000000;\">");
					Write(Lang.Get("上次调用时间"));
					WriteLiteral("：</vi>\r\n                                            <vi style=\"color:#000000;\">");
					Write(var.Date.ToString("yy-MM-dd HH:mm:ss zz"));
					WriteLiteral("</vi>\r\n                                        </p>\r\n                                    </div>\r\n\r\n                                    <div class=\" col-6\">\r\n                                        <p class=\"h4\">\r\n                                            <vi style=\"color:#000000;\">");
					Write(Lang.Get("上次调用统计"));
					WriteLiteral("：</vi>\r\n                                            <vi style=\"color:#0D6EFD;\">");
					Write(var.Request);
					WriteLiteral(" </vi>\r\n                                            <vi>|</vi>\r\n                                            <vi style=\"color:#198754;\">");
					Write(var.Success);
					WriteLiteral("</vi>\r\n                                            <vi>|</vi>\r\n                                            <vi style=\"color:#DC3545;\">");
					Write(var.Fail);
					WriteLiteral("</vi>\r\n                                        </p>\r\n                                    </div>\r\n                                </div>\r\n");
					WriteLiteral("                                <div class=\"row\">\r\n                                    <div class=\"col-sm-6\">\r\n                                        <p class=\"h4\">\r\n                                            <vi style=\"color:#000000;\">");
					Write(Lang.Get("下次调用时间"));
					WriteLiteral("：</vi>\r\n");
					if (var.IsPaused)
					{
						WriteLiteral("                                                <vi style=\"color:#000000;\">NA</vi>\r\n");
					}
					else
					{
						WriteLiteral("                                                <vi style=\"color:#000000;\">");
						Write(var.NextDate.ToString("yy-MM-dd HH:mm:ss zz"));
						WriteLiteral("</vi>\r\n");
					}
					WriteLiteral("                                        </p>\r\n                                    </div>\r\n\r\n                                    <div class=\" col-sm-6\">\r\n                                        <p class=\"h4\">\r\n                                            <vi style=\"color:#000000;\">");
					Write(Lang.Get("今日调用统计"));
					WriteLiteral("：</vi>\r\n                                            <vi style=\"color:#0D6EFD;\">");
					Write(var.TodayRequest);
					WriteLiteral(" </vi>\r\n                                            <vi>|</vi>\r\n                                            <vi style=\"color:#198754;\">");
					Write(var.TodaySuccess);
					WriteLiteral("</vi>\r\n                                            <vi>|</vi>\r\n                                            <vi style=\"color:#DC3545;\">");
					Write(var.TodayFail);
					WriteLiteral("</vi>\r\n                                        </p>\r\n                                    </div>\r\n                                </div>\r\n");
					if (var.Logs.Count > 0)
					{
						WriteLiteral("                                    <hr />\r\n                                    <div class=\"row\">\r\n                                        <div class=\"col-8 col-sm-8 col-md-8 col-lg-6 col-xl-6\">\r\n                                            <h4>");
						Write(Lang.Get("API名称"));
						WriteLiteral("</h4>\r\n                                        </div>\r\n                                        <div class=\"col-2 col-sm-2 col-md-2 col-lg-4 col-xl-4\">\r\n                                            <h4>");
						Write(Lang.Get("响应"));
						WriteLiteral("</h4>\r\n                                        </div>\r\n                                        <div class=\"col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2\">\r\n                                            <h4>");
						Write(Lang.Get("结果"));
						WriteLiteral("</h4>\r\n                                        </div>\r\n                                    </div>\r\n                                    <hr />\r\n");
						foreach (UserViewModel.EXAccountViewModel.LogViewModel log in var.Logs)
						{
							WriteLiteral("                                        <div class=\"row\">\r\n                                            <div class=\"col-8 col-sm-8 col-md-8 col-lg-6 col-xl-6\">\r\n");
							if (log.IsSuccess)
							{
								WriteLiteral("                                                    <h5>");
								Write(log.API);
								WriteLiteral("</h5>\r\n");
							}
							else
							{
								WriteLiteral("                                                    <h5 class=\"text-danger\">");
								Write(log.API);
								WriteLiteral("</h5>\r\n");
							}
							WriteLiteral("\r\n                                            </div>\r\n                                            <div class=\"col-2 col-sm-2 col-md-2 col-lg-4 col-xl-4\">\r\n");
							if (log.IsSuccess)
							{
								WriteLiteral("                                                    <h5>");
								Write(log.Result);
								WriteLiteral("</h5>\r\n");
							}
							else
							{
								WriteLiteral("                                                    <h5 class=\"text-danger\">");
								Write(log.Result);
								WriteLiteral("</h5>\r\n");
							}
							WriteLiteral("                                            </div>\r\n                                            <div class=\"col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2\">\r\n");
							if (log.IsSuccess)
							{
								WriteLiteral("                                                    <h5>");
								Write(Lang.Get("成功"));
								WriteLiteral("</h5>\r\n");
							}
							else
							{
								WriteLiteral("                                                    <h5 class=\"text-danger\">");
								Write(Lang.Get("失败"));
								WriteLiteral("</h5>\r\n");
							}
							WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n");
						}
					}
				}
				WriteLiteral("\r\n\r\n\r\n\r\n\r\n                        </div>\r\n\r\n\r\n\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
			}
			WriteLiteral("    <div class=\"modal fade\" id=\"myModal\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\">\r\n        <div class=\"modal-dialog\">\r\n            <div class=\"modal-content\">\r\n                <div class=\"modal-header\">\r\n                    <h4 class=\"modal-title\" id=\"myModalLabel\">\r\n                        警告！！！\r\n                    </h4>\r\n                    <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"modal\" aria-hidden=\"true\" />\r\n                </div>\r\n");
			if (base.Model.Status == -1)
			{
				WriteLiteral("                    <div class=\"modal-body\">\r\n                        确认解封此用户?\r\n                    </div>\r\n");
			}
			else
			{
				WriteLiteral("                    <div class=\"modal-body\">\r\n                        确认封禁此用户?此操作会拉黑该用户并删除其在本站的所有运行账号！\r\n                    </div>\r\n");
			}
			WriteLiteral("                <div class=\"modal-footer\">\r\n");
			if (base.Model.Status == -1)
			{
				WriteLiteral("                        ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1788676", async delegate
				{
					WriteLiteral("\r\n\r\n\r\n                            <button type=\"submit\" class=\"btn btn-danger\">\r\n                                确认\r\n                            </button>\r\n                        ");
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_23);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_20.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_20);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_17.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_17);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_24.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_24);
				if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
				}
				BeginWriteTagHelperAttribute();
				WriteLiteral("UID-");
				WriteLiteral(base.Model.Id);
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
				WriteLiteral("\r\n");
			}
			else
			{
				WriteLiteral("                        ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1792175", async delegate
				{
					WriteLiteral("\r\n\r\n\r\n                            <button type=\"submit\" class=\"btn btn-danger\">\r\n                                确认\r\n                            </button>\r\n                        ");
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_23);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_20.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_20);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_17.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_17);
				__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_25.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_25);
				if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
				}
				BeginWriteTagHelperAttribute();
				WriteLiteral("UID-");
				WriteLiteral(base.Model.Id);
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
				WriteLiteral("\r\n");
			}
			WriteLiteral("                    <button type=\"button\" class=\"btn btn-primary\" data-bs-dismiss=\"modal\">\r\n                        取消\r\n                    </button>\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"modal fade\" id=\"myModal2\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\">\r\n        <div class=\"modal-dialog\">\r\n            <div class=\"modal-content\">\r\n                <div class=\"modal-header\">\r\n                    <h4 class=\"modal-title\" id=\"myModalLabel2\">\r\n                        警告！！！\r\n                    </h4>\r\n                    <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"modal\" aria-hidden=\"true\" />\r\n                </div>\r\n\r\n                <div class=\"modal-body\">\r\n                    确认删除此用户数据?此操作会删除该用户在本站的所有关联信息，但<b>并不能阻止其再次注册</b>，若要拉黑此用户请使用封禁操作！\r\n                </div>\r\n                \r\n                <div class=\"modal-footer\">\r\n\r\n                    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "a1c3ae457eb50f13508c057f48db46e016979d1796602", async delegate
			{
				WriteLiteral("\r\n\r\n\r\n                        <button type=\"submit\" class=\"btn btn-danger\">\r\n                            确认\r\n                        </button>\r\n                    ");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_23);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_20.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_20);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_17.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_17);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_26.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_26);
			if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
			}
			BeginWriteTagHelperAttribute();
			WriteLiteral("UID-");
			WriteLiteral(base.Model.Id);
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
			WriteLiteral("\r\n                    \r\n\r\n                    <button type=\"button\" class=\"btn btn-primary\" data-bs-dismiss=\"modal\">\r\n                        取消\r\n                    </button>\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
		}
		else
		{
			WriteLiteral("    <h1 class=\"text-danger\"><b>错误</b></h1>\r\n    <br />\r\n    <h3 class=\"text-danger\">该用户不存在！！！</h3>\r\n");
			WriteLiteral("    <a class=\"btn btn-primary btn-block\" href='javascript:history.go(-1)'>");
			Write(Lang.Get("返回"));
			WriteLiteral("</a>\r\n");
		}
		WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
	}
}
