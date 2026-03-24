using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using AzureCore;

namespace Microsoft365_E5_Renew_X.Core;

public class APIRequestAction
{
	private Thread thread;

	private APIBase API;

	private Client.TokenResult Token;

	public ReportData reportData;

	private HttpClient HttpClient;

	private Chronograph chronographTest;

	private Request.CallResult Result;

	private string UserName;

	private bool IsLogin;

	public bool Status;

	public APIRequestAction()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		chronographTest = new Chronograph();
		Status = true;
		base._002Ector();
		HttpClient = new HttpClient();
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(HttpClient, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0315), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0317).Add(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-1210469698 ^ -1210472868));
	}

	public void Start(string APIName, APIBase aPIBase, Client.TokenResult tokenResult, string UserName, bool IsLogin)
	{
		if (Status)
		{
			reportData = new ReportData(APIName);
			API = aPIBase;
			Token = tokenResult;
			this.UserName = UserName;
			this.IsLogin = IsLogin;
			thread = new Thread(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0318);
			Status = false;
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(thread, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0318);
		}
	}

	private void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0318()
	{
		if (Token.Valid)
		{
			chronographTest.Start();
			if (IsLogin)
			{
				Result = Request.HTTPKeepAlive(HttpClient, Token.Content, API.URL(Random: true), API.Method, API.Content(Random: true), API.ContentType);
			}
			else
			{
				Result = Request.HTTPKeepAlive(HttpClient, Token.Content, API.URL(Random: true, UserName), API.Method, API.Content(Random: true), API.ContentType);
			}
			ReportData obj = reportData;
			string reasonPhrase = Result.ReasonPhrase;
			bool valid = Result.Valid;
			TimeSpan timeSpan = chronographTest.Stop();
			obj.SetResult(reasonPhrase, valid, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref timeSpan, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0303) / 1000.0);
		}
		else
		{
			reportData.SetResult(Token.Content, IsSuccess: false, -1.0);
		}
		Status = true;
	}
}
