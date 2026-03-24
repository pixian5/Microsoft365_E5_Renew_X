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

[RazorSourceChecksum("SHA1", "5f9c52bed51de3c4fc8d013cd123cdf8fd561f74", "/Views/Admin/UserList.cshtml")]
[RazorSourceChecksum("SHA1", "c66112178a02fb8ff4de9dd05dd6006ea0adb9de", "/Views/_ViewImports.cshtml")]
[RazorSourceChecksum("SHA1", "cb2fd25cde740f6cb9ddef4bf2af6ae15710d297", "/Views/Admin/_ViewImports.cshtml")]
public class Views_Admin_UserList : RazorPage<UserListViewModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("class", new HtmlString("btn btn-primary btn-sm"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("asp-controller", "Admin", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-action", "User", HtmlAttributeValueStyle.DoubleQuotes);

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
	public IHtmlHelper<UserListViewModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		base.ViewBag.Title = Lang.Get("用户列表");
		WriteLiteral("\n\r\n<h1>用户列表</h1>\r\n<hr />\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col\">\r\n        <ul class=\"list-inline\" style=\"font-weight:bold;\">\r\n            <li class=\"list-inline-item text-primary\">总数</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-success\">正常</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-warning\">待激活</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-danger\">封禁</li>\r\n            <li class=\"list-inline-item\">:</li>\r\n            <li class=\"list-inline-item text-primary\">");
		Write(base.Model.Total);
		WriteLiteral("</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-success\">");
		Write(base.Model.Nomal);
		WriteLiteral("</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-warning\">");
		Write(base.Model.UnActivate);
		WriteLiteral("</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-danger\">");
		Write(base.Model.Block);
		WriteLiteral("</li>\r\n        </ul>\r\n    </div>\r\n    <div class=\"col\" style=\"text-align:right;\">\r\n        <ul class=\"list-inline\" style=\"font-weight:bold;\">\r\n            <li class=\"list-inline-item text-success\">今日活跃</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-primary\">7天</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-info\">30天</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-warning\">90天</li>\r\n            <li class=\"list-inline-item\">:</li>\r\n            <li class=\"list-inline-item text-success\">");
		Write(base.Model.Day1);
		WriteLiteral("</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-primary\">");
		Write(base.Model.Day7);
		WriteLiteral("</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-info\">");
		Write(base.Model.Day30);
		WriteLiteral("</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-warning\">");
		Write(base.Model.Day90);
		WriteLiteral("</li>\r\n        </ul>\r\n    </div>\r\n\r\n\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col\">\r\n        <ul class=\"list-inline\" style=\"font-weight:bold;\">\r\n            <li class=\"list-inline-item text-success\">已勾选：</li>\r\n            <li id=\"CheckBoxCheckedNum\" class=\"list-inline-item text-success\">0</li>\r\n            <li class=\"list-inline-item\">|</li>\r\n            <li class=\"list-inline-item text-primary\">");
		Write(base.Model.AppUsers.Count);
		WriteLiteral("</li>\r\n        </ul>\r\n    </div>\r\n    <div class=\"col\" style=\"text-align:right;\">\r\n        <ul class=\"list-inline\" style=\"font-weight:bold;\">\r\n            <li class=\"list-inline-item text-success\">\r\n                <a class=\"btn btn-success btn-sm\" data-bs-toggle=\"modal\" data-bs-target=\"#myModal\">批量解封</a>\r\n            </li>\r\n            <li class=\"list-inline-item\">\r\n                <a class=\"btn btn-danger btn-sm\" data-bs-toggle=\"modal\" data-bs-target=\"#myModal2\">批量封禁</a>\r\n            </li>\r\n\r\n        </ul>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"table-responsive\">\r\n    <table class=\"table table-striped table-bordered table-hover text-nowrap\">\r\n        <thead>\r\n            <tr>\r\n                <th style=\"vertical-align: middle !important;text-align: center; cursor:pointer;\"><input type=\"checkbox\" id=\"TableHeadCheckBox\"></th>\r\n                <th style=\"vertical-align: middle !important;text-align: left;\">用户名</th>\r\n                <th style=\"vertical-align: middle !important;text-align: center;cursor:pointer;\">");
		WriteLiteral("注册日期▲</th>\r\n                <th style=\"vertical-align: middle !important;text-align: center;cursor:pointer;\">上次登录</th>\r\n                <th style=\"vertical-align: middle !important;text-align: right;cursor:pointer;\">配额</th>\r\n                <th style=\"vertical-align: middle !important;text-align: right;cursor:pointer;\">暂停</th>\r\n                <th style=\"vertical-align: middle !important;text-align: center;\">操作</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
		foreach (UserListViewModel.AppUserViewModel appUser in base.Model.AppUsers)
		{
			WriteLiteral("                <tr>\r\n\r\n                    <td style=\"vertical-align: middle !important;text-align: center;\">\r\n                        <input type=\"checkbox\"");
			BeginWriteAttribute("value", " value=\"", 4289, "\"", 4308, 1);
			WriteAttributeValue("", 4297, appUser.Id, 4297, 11, isLiteral: false);
			EndWriteAttribute();
			WriteLiteral(" />\r\n                        <p style=\"visibility:collapse;display:none;\" type=\"collapse\">");
			Write(appUser.Status);
			WriteLiteral("</p>\r\n                    </td>\r\n");
			if (appUser.Status == -1)
			{
				WriteLiteral("                        <td class=\"text-danger\" style=\"vertical-align: middle !important;text-align: left;\">");
				Write(appUser.Name);
				WriteLiteral("</td>\r\n");
			}
			else if (appUser.Status == 0)
			{
				WriteLiteral("                        <td class=\"text-warning\" style=\"vertical-align: middle !important;text-align: left;\">");
				Write(appUser.Name);
				WriteLiteral("</td>\r\n");
			}
			else if (appUser.Status == 1)
			{
				WriteLiteral("                        <td style=\"vertical-align: middle !important;text-align: left;\">");
				Write(appUser.Name);
				WriteLiteral("</td>\r\n");
			}
			WriteLiteral("                    <td style=\"vertical-align: middle !important;text-align: center;\">");
			Write(appUser.RegisterDate.ToString("yy-MM-dd HH:mm:ss"));
			WriteLiteral("</td>\r\n                    <td style=\"vertical-align: middle !important;text-align: center;\">");
			Write(appUser.LastLoginDate.ToString("yy-MM-dd HH:mm:ss"));
			WriteLiteral("</td>\r\n                    <td style=\"vertical-align: middle !important;text-align: right;\">");
			Write(appUser.AccountNum);
			WriteLiteral("|");
			Write(appUser.Quota);
			WriteLiteral("</td>\r\n                    <td style=\"vertical-align: middle !important;text-align: right;\">");
			Write(appUser.PausedNum);
			WriteLiteral("|");
			Write(appUser.AccountNum);
			WriteLiteral("</td>\r\n                    <td style=\"vertical-align: middle !important;text-align: center;\">\r\n                        ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "5f9c52bed51de3c4fc8d013cd123cdf8fd561f7417669", async delegate
			{
				WriteLiteral("查看");
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
			WriteLiteral(appUser.Id);
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
			WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
		}
		WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n<div class=\"modal fade\" id=\"myModal\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog\">\r\n        <div class=\"modal-content\">\r\n            <div class=\"modal-header\">\r\n                <h4 class=\"modal-title\" id=\"myModalLabel\">\r\n                    警告！！！\r\n                </h4>\r\n                <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"modal\" aria-hidden=\"true\" />\r\n            </div>\r\n\r\n            <div class=\"modal-body\">\r\n                确认批量解封用户?\r\n            </div>\r\n\r\n            <div class=\"modal-footer\">\r\n                <button type=\"submit\" class=\"btn btn-danger\" onclick=\"BlockOrUnLockUsers(false)\">\r\n                    确认\r\n                </button>\r\n                <button type=\"button\" class=\"btn btn-primary\" data-bs-dismiss=\"modal\">\r\n                    取消\r\n                </button>\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"modal fade\" id=\"myModal2\" tabin");
		WriteLiteral("dex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog\">\r\n        <div class=\"modal-content\">\r\n            <div class=\"modal-header\">\r\n                <h4 class=\"modal-title\" id=\"myModalLabel\">\r\n                    警告！！！\r\n                </h4>\r\n                <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"modal\" aria-hidden=\"true\" />\r\n            </div>\r\n\r\n            <div class=\"modal-body\">\r\n                确认批量封禁用户?此操作会拉黑这些用户并删除其在本站的所有运行账号！\r\n            </div>\r\n\r\n            <div class=\"modal-footer\">\r\n                <button type=\"submit\" class=\"btn btn-danger\" onclick=\"BlockOrUnLockUsers(true)\">\r\n                    确认\r\n                </button>\r\n                <button type=\"button\" class=\"btn btn-primary\" data-bs-dismiss=\"modal\">\r\n                    取消\r\n                </button>\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
		DefineSection("Scripts", (RenderAsyncDelegate)async delegate
		{
			WriteLiteral("\r\n<script>\r\n\r\n        var TableHeadCheckBox = document.getElementById('TableHeadCheckBox');\r\n        var TableBodyCheckBox = document.querySelector('tbody').getElementsByTagName('input');\r\n        var CheckedNum=0;\r\n        for (var i = 0; i < TableBodyCheckBox.length; i++)\r\n        {\r\n                TableBodyCheckBox[i].checked = this.checked;\r\n                if(TableBodyCheckBox[i].checked) CheckedNum++;\r\n        }\r\n        document.getElementById(\"CheckBoxCheckedNum\").innerHTML=CheckedNum.toString();\r\n\r\n        TableHeadCheckBox.onclick = function()\r\n        {\r\n            CheckedNum=0;\r\n            for (var i = 0; i < TableBodyCheckBox.length; i++)\r\n            {\r\n                TableBodyCheckBox[i].checked = this.checked;\r\n                if(TableBodyCheckBox[i].checked) CheckedNum++;\r\n            }\r\n            document.getElementById(\"CheckBoxCheckedNum\").innerHTML=CheckedNum.toString();\r\n        }\r\n        for (var i = 0; i < TableBodyCheckBox.length; i++)\r\n        {\r\n            TableBodyCheckBox[");
			WriteLiteral("i].onclick = function()\r\n            {\r\n                var flag = true;\r\n                for (var i = 0; i < TableBodyCheckBox.length; i++)\r\n                {\r\n                    if (!TableBodyCheckBox[i].checked)\r\n                    {\r\n                        flag = false;\r\n                    }\r\n                }\r\n                TableHeadCheckBox.checked = flag;\r\n\r\n                if(this.checked) CheckedNum++;\r\n                else CheckedNum--;\r\n                document.getElementById(\"CheckBoxCheckedNum\").innerHTML=CheckedNum.toString();\r\n            }\r\n        }\r\n\r\n    var OrderOption=false;\r\n\r\n    const order = {\r\n        \r\n        init (param) {\r\n            const that = this;\r\n            const table = param.el;\r\n            var thead = table.getElementsByTagName('thead')[0];\r\n\r\n            var tbody = table.getElementsByTagName('tbody')[0];\r\n\r\n            var ths = Array.from(thead.getElementsByTagName('tr')[0].getElementsByTagName('th'));\r\n\r\n            var trs = Array.from(tbody.getElementsByT");
			WriteLiteral("agName('tr'));\r\n\r\n\r\n            if (!table) return;\r\n\r\n\r\n                ths[0][\"addEventListener\"]('click', () =>\r\n                {\r\n                    this.ResetOrderIcon(ths);\r\n                    OrderOption=true;\r\n                    \r\n                    trs.sort(this.SortCheckBox);\r\n                    trs.forEach((tr, index) =>\r\n                    {\r\n                        tbody.appendChild(tr);\r\n                    });\r\n\r\n                });\r\n\r\n                ths[2][\"addEventListener\"]('click', () =>\r\n                {\r\n                    this.ResetOrderIcon(ths);\r\n                    \r\n                    if(OrderOption)\r\n                    {\r\n                        OrderOption=false;\r\n                        ths[2].innerHTML+=\"▲\";\r\n                    }\r\n                    else\r\n                    {\r\n                        OrderOption=true;\r\n                        ths[2].innerHTML+=\"▼\";\r\n                    }\r\n                    trs.sort(this.SortRegisterDate);\r\n                    trs");
			WriteLiteral(".forEach((tr, index) =>\r\n                    {\r\n                        tbody.appendChild(tr);\r\n                    });\r\n\r\n                });\r\n\r\n                ths[3][\"addEventListener\"]('click', () =>\r\n                {\r\n                    this.ResetOrderIcon(ths);\r\n                    if(OrderOption)\r\n                    {\r\n                        OrderOption=false;\r\n                        ths[3].innerHTML+=\"▲\";\r\n                    }\r\n                    else\r\n                    {\r\n                        OrderOption=true;\r\n                        ths[3].innerHTML+=\"▼\";\r\n                    }\r\n                    trs.sort(this.SortLoginDate);\r\n                    trs.forEach((tr, index) =>\r\n                    {\r\n                        tbody.appendChild(tr);\r\n                    });\r\n\r\n                });\r\n\r\n                ths[4][\"addEventListener\"]('click', () =>\r\n                {\r\n                    this.ResetOrderIcon(ths);\r\n                    OrderOption=true;\r\n                    ths[4].inne");
			WriteLiteral("rHTML+=\"▼\";\r\n                    trs.sort(this.SortQuota);\r\n                    trs.forEach((tr, index) =>\r\n                    {\r\n                        tbody.appendChild(tr);\r\n                    });\r\n\r\n                });\r\n                ths[5][\"addEventListener\"]('click', () =>\r\n                {\r\n                    this.ResetOrderIcon(ths);\r\n                    OrderOption=true;\r\n                    ths[5].innerHTML+=\"▼\";\r\n                    trs.sort(this.SortPaused);\r\n                    trs.forEach((tr, index) =>\r\n                    {\r\n                        tbody.appendChild(tr);\r\n                    });\r\n\r\n                });\r\n\r\n        },\r\n        ResetOrderIcon(THs)\r\n        {\r\n            for(var C =1;C<THs.length;C++)\r\n            {\r\n                THs[C].innerHTML=THs[C].innerHTML.replace(\"▲\",\"\").replace(\"▼\",\"\");\r\n            }\r\n        },\r\n        SortCheckBox(A,B)\r\n        {\r\n                var Atds=Array.from(A.getElementsByTagName('input'));\r\n                var Btds=Array.from(B.get");
			WriteLiteral("ElementsByTagName('input'));\r\n                var AV=Atds[0].checked;\r\n                var BV=Btds[0].checked;\r\n                if(AV==BV) return 0;\r\n                if(BV>AV)\r\n                {\r\n                    if(OrderOption) return 1;\r\n                    else return -1;\r\n                }\r\n                else\r\n                {\r\n                    if(OrderOption) return -1;\r\n                    else return 1;\r\n                }\r\n        },\r\n        SortRegisterDate(A,B)\r\n        {\r\n                var Atds=Array.from(A.getElementsByTagName('td'));\r\n                var Btds=Array.from(B.getElementsByTagName('td'));\r\n                var AV=new Date('20'+Atds[2].innerHTML);\r\n                var BV=new Date('20'+Btds[2].innerHTML);\r\n                if(AV==BV) return 0;\r\n                if(BV>AV)\r\n                {\r\n                    if(OrderOption) return 1;\r\n                    else return -1;\r\n                }\r\n                else\r\n                {\r\n                    if(OrderOption) return -1;\r");
			WriteLiteral("\n                    else return 1;\r\n                }\r\n\r\n        },\r\n        SortLoginDate(A,B)\r\n        {\r\n                var Atds=Array.from(A.getElementsByTagName('td'));\r\n                var Btds=Array.from(B.getElementsByTagName('td'));\r\n                var AV=new Date('20'+Atds[3].innerHTML);\r\n                var BV=new Date('20'+Btds[3].innerHTML);\r\n                if(AV==BV) return 0;\r\n                if(BV>AV)\r\n                {\r\n                    if(OrderOption) return 1;\r\n                    else return -1;\r\n                }\r\n                else\r\n                {\r\n                    if(OrderOption) return -1;\r\n                    else return 1;\r\n                }\r\n        },\r\n\r\n        SortQuota(A,B)\r\n        {\r\n\r\n            var Atds=Array.from(A.getElementsByTagName('td'));\r\n            var Btds=Array.from(B.getElementsByTagName('td'));\r\n            var AUserStatus=parseInt(A.getElementsByTagName('p')[0].innerHTML);\r\n            var BUserStatus=parseInt(B.getElementsByTagName('p')[0].inne");
			WriteLiteral("rHTML);\r\n            var A1=parseInt(Atds[4].innerHTML.split('|')[0]);\r\n            var A2=parseInt(Atds[4].innerHTML.split('|')[1]);\r\n            var B1=parseInt(Btds[4].innerHTML.split('|')[0]);\r\n            var B2=parseInt(Btds[4].innerHTML.split('|')[1]);\r\n            var AV=0;\r\n            var BV=0;\r\n\r\n            if(AUserStatus==BUserStatus)\r\n            {\r\n                if(A2==0)AV=0;\r\n                else\r\n                {\r\n                    if(A1<=A2) AV=(A2-A1)/A2;\r\n                    else AV=0;\r\n                }\r\n                if(B2==0)BV=0;\r\n                else\r\n                {\r\n                    if(B1<=B2) BV=(B2-B1)/B2;\r\n                    else BV=0;\r\n                }\r\n                if(AV==BV) return 0;\r\n                    if(BV>AV)\r\n                    {\r\n                        if(OrderOption) return 1;\r\n                        else return -1;\r\n                    }\r\n                    else\r\n                    {\r\n                        if(OrderOption) return -1;\r\n        ");
			WriteLiteral("                else return 1;\r\n                    }\r\n            }\r\n            else\r\n            {\r\n                if(AUserStatus==1)\r\n                {\r\n                    return -1;\r\n                }\r\n                if(BUserStatus==1)\r\n                {\r\n\r\n                    return 1;\r\n                }\r\n\r\n                if(BUserStatus>AUserStatus) return 1;\r\n                else return -1;\r\n            }\r\n\r\n        },\r\n        SortPaused(A,B)\r\n        {\r\n            var Atds=Array.from(A.getElementsByTagName('td'));\r\n            var Btds=Array.from(B.getElementsByTagName('td'));\r\n            var AUserStatus=parseInt(A.getElementsByTagName('p')[0].innerHTML);\r\n            var BUserStatus=parseInt(B.getElementsByTagName('p')[0].innerHTML);\r\n            var A1=parseInt(Atds[5].innerHTML.split('|')[0]);\r\n            var A2=parseInt(Atds[5].innerHTML.split('|')[1]);\r\n            var B1=parseInt(Btds[5].innerHTML.split('|')[0]);\r\n            var B2=parseInt(Btds[5].innerHTML.split('|')[1]);\r\n           ");
			WriteLiteral(" var AV=0;\r\n            var BV=0;\r\n            if(AUserStatus==BUserStatus)\r\n            {\r\n                if(A2==0)AV=0;\r\n                else\r\n                {\r\n                    if(A1<=A2) AV=A1/A2;\r\n                    else AV=1;\r\n                }\r\n                if(B2==0)BV=0;\r\n                else\r\n                {\r\n                    if(B1<=B2) BV=B1/B2;\r\n                    else BV=1;\r\n                }\r\n                if(AV==BV) return 0;\r\n                    if(BV>AV)\r\n                    {\r\n                        if(OrderOption) return 1;\r\n                        else return -1;\r\n                    }\r\n                    else\r\n                    {\r\n                        if(OrderOption) return -1;\r\n                        else return 1;\r\n                    }\r\n            }\r\n            else\r\n            {\r\n                if(AUserStatus==1)\r\n                {\r\n                    return -1;\r\n                }\r\n                if(BUserStatus==1)\r\n                {\r\n\r\n                  ");
			WriteLiteral("  return 1;\r\n                }\r\n\r\n                if(BUserStatus>AUserStatus) return 1;\r\n                else return -1;\r\n            }\r\n        },\r\n    };\r\n\r\n    order.init({el: document.getElementsByTagName('table')[0]});\r\n\r\n    function BlockOrUnLockUsers(BlockOrUnLock)\r\n    {\r\n\r\n        var Temp=GetUserIDs();\r\n        if(Temp.length>0) PostBlockOrUnLockUsers(Temp,BlockOrUnLock);\r\n    }\r\n\r\n    function GetUserIDs()\r\n    {\r\n        var str=new Array();\r\n        for (var i = 0; i < TableBodyCheckBox.length; i++)\r\n        {\r\n            if (TableBodyCheckBox[i].checked)\r\n            {\r\n                str.push(TableBodyCheckBox[i].defaultValue);\r\n            }\r\n        }\r\n        return str;\r\n    }\r\n    function PostBlockOrUnLockUsers(UserIDs,BlockOrUnLock){\r\n      var temp=document.createElement(\"form\");\r\n      if(BlockOrUnLock) temp.action=\"/Admin/BlockUsers\";\r\n      else temp.action=\"/Admin/UnBlockUsers\";\r\n      temp.method=\"post\";\r\n      temp.style.display=\"none\";\r\n      var str=\"\";\r\n      for(var i=Numbe");
			WriteLiteral("r(0);i<UserIDs.length;i++)\r\n      {\r\n          str+=UserIDs[i]+\"|\";\r\n      }\r\n      var opt=document.createElement(\"textarea\");\r\n      opt.name=\"UserIDs\";\r\n      opt.value=str;\r\n      temp.appendChild(opt);\r\n      document.body.appendChild(temp);\r\n      temp.submit();\r\n      return temp;\r\n     }\r\n\r\n</script>\r\n");
		});
		WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
	}
}
