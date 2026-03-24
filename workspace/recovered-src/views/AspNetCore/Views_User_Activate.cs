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

[RazorSourceChecksum("SHA1", "423065fb32e30b528b24406da56b6a0b58614194", "/Views/User/Activate.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "74d4abd4e1f0bef76f750de100d06c88774fff8e", "/Views/User/_ViewImports.cshtml")]
public class Views_User_Activate : RazorPage<ActivateViewModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("class", new HtmlString("was-validated"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("method", "post", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-controller", "User", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("asp-action", "Activate", HtmlAttributeValueStyle.DoubleQuotes);

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
	public IHtmlHelper<ActivateViewModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n");
		base.ViewBag.Title = Lang.Get("激活您的账户");
		WriteLiteral("\r\n<h1>激活您的账户</h1>\r\n<h6>欢迎登录本站！您的账户目前处于未激活状态，站内绝大多数功能无法使用！</h6>\r\n<hr />\r\n\r\n\r\n<dl>\r\n    <dt><b>使用条款</b></dt>\r\n    <dd>&ensp;- 使用该续订服务只是增加E5续订概率，并<b>不能保证100%续订成功</b></dd>\r\n    <dd>&ensp;- 续订操作有些许技术门槛，且<b>应当具备一定的自学能力</b></dd>\r\n    <dd>&ensp;- 要注意保护自己的账号隐私，尽量<b>不要使用管理员账号</b></dd>\r\n    <dd>&ensp;- 各运营者的服务质量可能有些出入，尽量<b>使用优质的运营站点</b></dd>\r\n    <dd>&ensp;- 由于个人错误操作触发微软机器诈术检测而导致封号的<b>概不负责</b></dd>\r\n</dl>\r\n");
		if (base.Model.IsAdmin)
		{
			WriteLiteral("    <dl>\r\n    <dt><b>运营者职责</b></dt>\r\n    <dd>&ensp;- 应当设置安全强度足够高的管理员密码，有义务和责任保护用户数据不被泄露</dd>\r\n    <dd>&ensp;- 站点的服务周期及各维护工作都应当通过系统公告及时告知用户</dd>\r\n    <dd>&ensp;- 应时刻关注系统的运行负载，必要时可关闭注册通道保证站点的稳定运行</dd>\r\n</dl>\r\n");
		}
		WriteLiteral("\r\n\r\n<hr />\r\n\r\n\r\n\r\n\r\n");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "423065fb32e30b528b24406da56b6a0b586141946826", async delegate
		{
			WriteLiteral("\r\n\r\n\r\n\r\n    <div class=\"form-check col-12\">\r\n        <input class=\"form-check-input\" type=\"checkbox\" id=\"invalidCheck3\" required>\r\n        <label class=\"form-check-label\" for=\"invalidCheck3\">我已阅读并同意上述使用条款</label>\r\n        <div class=\"invalid-feedback\">您必须阅读并同意使用条款才能继续</div>\r\n    </div>\r\n\r\n\r\n    <div class=\"d-grid col-12\">\r\n\r\n\r\n\r\n        <button class=\"btn btn-primary \" type=\"submit\">激活账户</button>\r\n\r\n\r\n\r\n    </div>\r\n");
		});
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
		__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
	}
}
