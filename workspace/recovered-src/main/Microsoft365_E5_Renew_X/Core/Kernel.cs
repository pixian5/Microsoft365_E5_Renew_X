using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AzureCore;
using FileContextCore;
using FileContextCore.FileManager;
using FileContextCore.Serializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft365_E5_Renew_X.Infrastructure;
using Microsoft365_E5_Renew_X.Models;

namespace Microsoft365_E5_Renew_X.Core;

public static class Kernel
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public List<EXAccount> EXAccounts;

		public List<EXAccountRun> EXAccountRuns;

		public _003C_003Ec__DisplayClass12_0()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public int C;

		public _003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass12_1()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			base._002Ector();
		}

		internal bool _003CKernelProcess_003Eb__1(EXAccountRun x)
		{
			return _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(x.Id, CS_0024_003C_003E8__locals1.EXAccounts[C].Id, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_2
	{
		public int C;

		public _003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass12_2()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			base._002Ector();
		}

		internal bool _003CKernelProcess_003Eb__2(EXAccount x)
		{
			return _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(x.Id, CS_0024_003C_003E8__locals2.EXAccountRuns[C].Id, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_3
	{
		public int C;

		public _003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals3;

		public _003C_003Ec__DisplayClass12_3()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			base._002Ector();
		}

		internal bool _003CKernelProcess_003Eb__3(AppUser x)
		{
			return _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(x.Id, CS_0024_003C_003E8__locals3.EXAccountRuns[C].AppUserUUID, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_4
	{
		public AppUser appUser;

		public _003C_003Ec__DisplayClass12_4()
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			base._002Ector();
		}

		internal bool _003CKernelProcess_003Eb__4(EmailService x)
		{
			return _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(x.Email, appUser.Email, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CKernelProcess_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private _003C_003Ec__DisplayClass12_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass12_1 _003C_003E8__2;

		private AppDbContext _003CappDbContext_003E5__2;

		private DateTime _003CEverydayTaskTime_003E5__3;

		private DateTime _003CNowTime_003E5__4;

		private Chronograph _003Cchronograph_003E5__5;

		private ValueTaskAwaiter<EntityEntry<EXAccountRun>> _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private int _003CC_003E5__6;

		private TaskAwaiter<ReportData[]> _003C_003Eu__3;

		private List<EmailService> _003CemailMessages_003E5__7;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				ValueTaskAwaiter<EntityEntry<EXAccountRun>> awaiter8;
				TaskAwaiter<int> awaiter7;
				TaskAwaiter<ReportData[]> awaiter6;
				TaskAwaiter<ReportData[]> awaiter5;
				TaskAwaiter<int> awaiter4;
				TaskAwaiter<int> awaiter3;
				TaskAwaiter<int> awaiter2;
				TaskAwaiter<int> awaiter;
				_003C_003Ec__DisplayClass12_2 CS_0024_003C_003E8__locals34;
				int num2;
				ReportData[] array;
				ReportData.Pause pause;
				ReportData[] array2;
				double num4;
				TimeSpan timeSpan;
				ReportData[] result;
				ReportData[] result2;
				switch (num)
				{
				default:
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass12_0();
					_003CEverydayTaskTime_003E5__3 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(1.0, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0302), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0304);
					_003CNowTime_003E5__4 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302);
					DateTime dateTime = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302);
					SystemConfig.Dynamic.LastSpecialPardonTime = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302);
					_003Cchronograph_003E5__5 = new Chronograph();
					bool flag = true;
					goto IL_009c;
				}
				case 0:
					awaiter8 = _003C_003Eu__1;
					_003C_003Eu__1 = default(ValueTaskAwaiter<EntityEntry<EXAccountRun>>);
					num = (_003C_003E1__state = -1);
					goto IL_0347;
				case 1:
					awaiter7 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<int>);
					num = (_003C_003E1__state = -1);
					goto IL_0656;
				case 2:
					awaiter6 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<ReportData[]>);
					num = (_003C_003E1__state = -1);
					goto IL_081f;
				case 3:
					awaiter5 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<ReportData[]>);
					num = (_003C_003E1__state = -1);
					goto IL_08f6;
				case 4:
					awaiter4 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<int>);
					num = (_003C_003E1__state = -1);
					goto IL_0d8d;
				case 5:
					awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<int>);
					num = (_003C_003E1__state = -1);
					goto IL_0ff4;
				case 6:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<int>);
					num = (_003C_003E1__state = -1);
					goto IL_1389;
				case 7:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<int>);
						num = (_003C_003E1__state = -1);
						goto IL_172e;
					}
					IL_009c:
					_003Cchronograph_003E5__5.Start();
					_003CappDbContext_003E5__2 = new AppDbContext(optionsBuilder.Options);
					_003C_003E8__1.EXAccounts = _003CappDbContext_003E5__2.EXAccounts.ToList();
					_003C_003E8__1.EXAccountRuns = _003CappDbContext_003E5__2.EXAccountRuns.ToList();
					_003C_003E8__2 = new _003C_003Ec__DisplayClass12_1();
					_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
					_003C_003E8__2.C = 0;
					goto IL_051a;
					IL_051a:
					if (_003C_003E8__2.C < _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts.Count())
					{
						EXAccountRun eXAccountRun = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccountRuns.Find((EXAccountRun x) => _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(x.Id, _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].Id, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313));
						if (eXAccountRun == null)
						{
							eXAccountRun = new EXAccountRun
							{
								Id = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].Id,
								AppUserUUID = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].AppUserUUID,
								UserName = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].UserName,
								ClientID = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].ClientID,
								PwdOrSecert = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].PwdOrSecert,
								IsLogin = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].IsLogin,
								IsPaused = false,
								IsNeedSendMail = false,
								PausedReason = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x7FB8AFD1 ^ 0x7FB88FA1),
								NextDate = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(300.0, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0305), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0306),
								TimeStamp = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].TimeStamp
							};
							awaiter8 = _003CappDbContext_003E5__2.EXAccountRuns.AddAsync(eXAccountRun).GetAwaiter();
							if (!awaiter8.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter8;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter8, ref this);
								break;
							}
							goto IL_0347;
						}
						if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(eXAccountRun.TimeStamp, _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].TimeStamp, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0308))
						{
							eXAccountRun.AppUserUUID = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].AppUserUUID;
							eXAccountRun.UserName = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].UserName;
							eXAccountRun.ClientID = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].ClientID;
							eXAccountRun.PwdOrSecert = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].PwdOrSecert;
							eXAccountRun.IsLogin = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].IsLogin;
							eXAccountRun.IsPaused = false;
							eXAccountRun.IsNeedSendMail = false;
							eXAccountRun.NextDate = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(300.0, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0305), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0306);
							eXAccountRun.TimeStamp = _003C_003E8__2.CS_0024_003C_003E8__locals1.EXAccounts[_003C_003E8__2.C].TimeStamp;
							eXAccountRun.Log = "";
							_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2.EXAccountRuns.Attach(eXAccountRun), EntityState.Modified, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0306);
						}
						goto IL_04fe;
					}
					_003C_003E8__2 = null;
					CS_0024_003C_003E8__locals34 = new _003C_003Ec__DisplayClass12_2
					{
						CS_0024_003C_003E8__locals2 = _003C_003E8__1,
						C = 0
					};
					while (CS_0024_003C_003E8__locals34.C < CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals2.EXAccountRuns.Count())
					{
						EXAccount eXAccount = CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals2.EXAccounts.Find((EXAccount x) => _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(x.Id, CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals2.EXAccountRuns[CS_0024_003C_003E8__locals34.C].Id, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313));
						if (eXAccount == null)
						{
							_003CappDbContext_003E5__2.EXAccountRuns.Remove(CS_0024_003C_003E8__locals34.CS_0024_003C_003E8__locals2.EXAccountRuns[CS_0024_003C_003E8__locals34.C]);
						}
						CS_0024_003C_003E8__locals34.C++;
					}
					awaiter7 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2, default(CancellationToken), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030B).GetAwaiter();
					if (!awaiter7.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter7;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter7, ref this);
						break;
					}
					goto IL_0656;
					IL_04fe:
					num2 = _003C_003E8__2.C;
					_003C_003E8__2.C = num2 + 1;
					goto IL_051a;
					IL_0903:
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Date = _003CNowTime_003E5__4;
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Request = ReportData.GetRequestNum(array);
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Success = ReportData.GetSuccessNum(array);
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Fail = ReportData.GetFailNum(array);
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Log = ReportData.GetLog(array);
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].NextDate = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(RandomEX.GetValue(1000, 2000), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0305), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0306);
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].TodayRequest += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Request;
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].TodaySuccess += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Success;
					_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].TodayFail += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Fail;
					pause = ReportData.AnalysisIsNeedPause(array, _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].IsLogin);
					if (pause.IsNeed)
					{
						_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].IsPaused = true;
						_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].PausedReason = pause.Reason;
						_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].IsNeedSendMail = true;
					}
					_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2.EXAccountRuns.Attach(_003C_003E8__1.EXAccountRuns[_003CC_003E5__6]), EntityState.Modified, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0306);
					if (_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].IsLogin)
					{
						SystemConfig.Dynamic.LoginRequest += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Request;
						SystemConfig.Dynamic.LoginSuccess += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Success;
						SystemConfig.Dynamic.LoginFail += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Fail;
					}
					else
					{
						SystemConfig.Dynamic.NoLoginRequest += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Request;
						SystemConfig.Dynamic.NoLoginSuccess += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Success;
						SystemConfig.Dynamic.NoLoginFail += _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].Fail;
					}
					SystemConfig.Dynamic.TodayRequest = SystemConfig.Dynamic.LoginRequest + SystemConfig.Dynamic.NoLoginRequest;
					SystemConfig.Dynamic.TodaySuccess = SystemConfig.Dynamic.LoginSuccess + SystemConfig.Dynamic.NoLoginSuccess;
					SystemConfig.Dynamic.TodayFail = SystemConfig.Dynamic.LoginFail + SystemConfig.Dynamic.NoLoginFail;
					array2 = array;
					foreach (ReportData reportData in array2)
					{
						SystemConfig.Dynamic.APIAnalyse.AddCostTime(reportData.RequestAPI, reportData.CostTime, reportData.IsSuccess);
					}
					SystemConfig.Dynamic.PerAPITime = SystemConfig.Dynamic.APIAnalyse.AverageCostTime;
					goto IL_0cf2;
					IL_1002:
					if (SystemConfig.Static.ShareSite.Enable)
					{
						_003CappDbContext_003E5__2 = new AppDbContext(optionsBuilder.Options);
						_003C_003E8__1.EXAccountRuns = _003CappDbContext_003E5__2.EXAccountRuns.ToList();
						List<AppUser> source = _003CappDbContext_003E5__2.Users.ToList();
						_003CemailMessages_003E5__7 = new List<EmailService>(0);
						_003C_003Ec__DisplayClass12_3 CS_0024_003C_003E8__locals36 = new _003C_003Ec__DisplayClass12_3
						{
							CS_0024_003C_003E8__locals3 = _003C_003E8__1,
							C = 0
						};
						while (CS_0024_003C_003E8__locals36.C < CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns.Count)
						{
							if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns[CS_0024_003C_003E8__locals36.C].IsPaused && CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns[CS_0024_003C_003E8__locals36.C].IsNeedSendMail)
							{
								_003C_003Ec__DisplayClass12_4 CS_0024_003C_003E8__locals37 = new _003C_003Ec__DisplayClass12_4();
								CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns[CS_0024_003C_003E8__locals36.C].IsNeedSendMail = false;
								_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2.EXAccountRuns.Attach(CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns[CS_0024_003C_003E8__locals36.C]), EntityState.Modified, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0306);
								IEnumerable<AppUser> enumerable = source.Where((AppUser x) => _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(x.Id, CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns[CS_0024_003C_003E8__locals36.C].AppUserUUID, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313));
								CS_0024_003C_003E8__locals37.appUser = null;
								if (enumerable != null && enumerable.Count() == 1)
								{
									CS_0024_003C_003E8__locals37.appUser = enumerable.ElementAt(0);
								}
								if (CS_0024_003C_003E8__locals37.appUser != null && CS_0024_003C_003E8__locals37.appUser.Email != null && _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(CS_0024_003C_003E8__locals37.appUser.Email, "", _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0306))
								{
									EmailService emailService = _003CemailMessages_003E5__7.Find((EmailService x) => _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(x.Email, CS_0024_003C_003E8__locals37.appUser.Email, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313));
									if (emailService == null)
									{
										emailService = new EmailService
										{
											Email = CS_0024_003C_003E8__locals37.appUser.Email,
											Subject = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x696180E ^ 0x6963896),
											Content = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x758F49A9 ^ 0x758F697D), SystemConfig.Static.ShareSite.System.Master, CS_0024_003C_003E8__locals37.appUser.Name, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0310)
										};
										_003CemailMessages_003E5__7.Add(emailService);
									}
									EmailService emailService2 = emailService;
									string content = emailService2.Content;
									string text = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x130E3D18 ^ 0x130E280C);
									string text2 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-31852682 ^ -31861142);
									string userName = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns[CS_0024_003C_003E8__locals36.C].UserName;
									DateTime date = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns[CS_0024_003C_003E8__locals36.C].Date;
									emailService2.Content = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(content, text, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0311._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(text2, userName, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_030B._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref date, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-89887808 ^ -89885814), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_030B._0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_030C), CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals3.EXAccountRuns[CS_0024_003C_003E8__locals36.C].PausedReason, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0311._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0312), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0308);
								}
							}
							CS_0024_003C_003E8__locals36.C++;
						}
						awaiter2 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2, default(CancellationToken), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030B).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 6);
							_003C_003Eu__2 = awaiter2;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							break;
						}
						goto IL_1389;
					}
					goto IL_13a3;
					IL_0ff4:
					awaiter3.GetResult();
					SystemConfig.Dynamic.SpecialPardon = false;
					goto IL_1002;
					IL_0656:
					awaiter7.GetResult();
					SystemConfig.Dynamic.DataSyncTime = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(SystemConfig.Dynamic.DataSyncTime, _003Cchronograph_003E5__5.Stop(), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030A);
					_003Cchronograph_003E5__5.Start();
					_003CNowTime_003E5__4 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302);
					_003CappDbContext_003E5__2 = new AppDbContext(optionsBuilder.Options);
					_003C_003E8__1.EXAccountRuns = (from s in _003CappDbContext_003E5__2.EXAccountRuns.ToList()
						orderby s.NextDate
						select s).ToList();
					_003CC_003E5__6 = 0;
					goto IL_0d04;
					IL_0cf2:
					_003CC_003E5__6++;
					goto IL_0d04;
					IL_1389:
					awaiter2.GetResult();
					EmailService.SendEmailMessages(_003CemailMessages_003E5__7);
					_003CemailMessages_003E5__7 = null;
					goto IL_13a3;
					IL_0d04:
					if (_003CC_003E5__6 < _003C_003E8__1.EXAccountRuns.Count && _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CNowTime_003E5__4, _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].NextDate, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030B))
					{
						if (!_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].IsPaused)
						{
							if (SystemConfig.Static.Serivce.CoreMultiThread)
							{
								awaiter6 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0316(_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].UserName, _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].ClientID, _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].PwdOrSecert, _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].IsLogin).GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__3 = awaiter6;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter6, ref this);
									break;
								}
								goto IL_081f;
							}
							awaiter5 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0315(_003C_003E8__1.EXAccountRuns[_003CC_003E5__6].UserName, _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].ClientID, _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].PwdOrSecert, _003C_003E8__1.EXAccountRuns[_003CC_003E5__6].IsLogin).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__3 = awaiter5;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter5, ref this);
								break;
							}
							goto IL_08f6;
						}
						goto IL_0cf2;
					}
					awaiter4 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2, default(CancellationToken), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030B).GetAwaiter();
					if (!awaiter4.IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__2 = awaiter4;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter4, ref this);
						break;
					}
					goto IL_0d8d;
					IL_172e:
					awaiter.GetResult();
					_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0317), GCCollectionMode.Forced, true, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0300);
					_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0311._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0311._0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0301);
					_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0317), GCCollectionMode.Forced, true, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0318._0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0300);
					_003CEverydayTaskTime_003E5__3 = _003CNowTime_003E5__4;
					goto IL_1778;
					IL_0d8d:
					awaiter4.GetResult();
					SystemConfig.Dynamic.APIRequestTime = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(SystemConfig.Dynamic.APIRequestTime, _003Cchronograph_003E5__5.Stop(), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030A);
					timeSpan = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(SystemConfig.Dynamic.DataSyncTime, SystemConfig.Dynamic.APIRequestTime, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030A);
					num4 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref timeSpan, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0303);
					timeSpan = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(SystemConfig.Dynamic.DataSyncTime, SystemConfig.Dynamic.APIRequestTime, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030A), SystemConfig.Dynamic.IdleTime, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030A);
					SystemConfig.Dynamic.SystemLoad = num4 / _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref timeSpan, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0303) * 100.0;
					timeSpan = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0308._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302), SystemConfig.Dynamic.LastSpecialPardonTime, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0308._0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0309);
					if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030C._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref timeSpan, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030C._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030D) >= SystemConfig.Static.ShareSite.System.AutoSpecialPardonInterval)
					{
						SystemConfig.Dynamic.SpecialPardon = true;
					}
					if (SystemConfig.Dynamic.SpecialPardon)
					{
						SystemConfig.Dynamic.LastSpecialPardonTime = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302);
						_003CappDbContext_003E5__2 = new AppDbContext(optionsBuilder.Options);
						_003C_003E8__1.EXAccountRuns = _003CappDbContext_003E5__2.EXAccountRuns.ToList();
						for (int num5 = 0; num5 < _003C_003E8__1.EXAccountRuns.Count; num5++)
						{
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003C_003E8__1.EXAccountRuns[num5].Date, DateTime.MinValue, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0307._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030E) && _003C_003E8__1.EXAccountRuns[num5].IsPaused)
							{
								_003C_003E8__1.EXAccountRuns[num5].IsPaused = false;
								_003C_003E8__1.EXAccountRuns[num5].NextDate = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(300.0, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0305), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0306);
								_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2.EXAccountRuns.Attach(_003C_003E8__1.EXAccountRuns[num5]), EntityState.Modified, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0306);
							}
						}
						awaiter3 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2, default(CancellationToken), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030B).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 5);
							_003C_003Eu__2 = awaiter3;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
							break;
						}
						goto IL_0ff4;
					}
					goto IL_1002;
					IL_0347:
					awaiter8.GetResult();
					goto IL_04fe;
					IL_13a3:
					_003CNowTime_003E5__4 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302);
					if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003CNowTime_003E5__4, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0314) != _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003CEverydayTaskTime_003E5__3, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0314))
					{
						SystemConfig.Dynamic.LastLoginRequest = SystemConfig.Dynamic.LoginRequest;
						SystemConfig.Dynamic.LastLoginSuccess = SystemConfig.Dynamic.LoginSuccess;
						SystemConfig.Dynamic.LastLoginFail = SystemConfig.Dynamic.LoginFail;
						SystemConfig.Dynamic.LastNoLoginRequest = SystemConfig.Dynamic.NoLoginRequest;
						SystemConfig.Dynamic.LastNoLoginSuccess = SystemConfig.Dynamic.NoLoginSuccess;
						SystemConfig.Dynamic.LastNoLoginFail = SystemConfig.Dynamic.NoLoginFail;
						SystemConfig.Dynamic.LastRequest = SystemConfig.Dynamic.TodayRequest;
						SystemConfig.Dynamic.LastSuccess = SystemConfig.Dynamic.TodaySuccess;
						SystemConfig.Dynamic.LastFail = SystemConfig.Dynamic.TodayFail;
						SystemConfig.Dynamic.LastDataSyncTime = SystemConfig.Dynamic.DataSyncTime;
						SystemConfig.Dynamic.LastAPIRequestTime = SystemConfig.Dynamic.APIRequestTime;
						SystemConfig.Dynamic.LastIdleTime = SystemConfig.Dynamic.IdleTime;
						SystemConfig.Dynamic.LastSystemLoad = SystemConfig.Dynamic.SystemLoad;
						SystemConfig.Dynamic.LastPerAPITime = SystemConfig.Dynamic.PerAPITime;
						SystemConfig.Dynamic.LastAPIAnalyseList = SystemConfig.Dynamic.APIAnalyse.ToList();
						SystemConfig.Dynamic.LoginRequest = 0;
						SystemConfig.Dynamic.LoginSuccess = 0;
						SystemConfig.Dynamic.LoginFail = 0;
						SystemConfig.Dynamic.NoLoginRequest = 0;
						SystemConfig.Dynamic.NoLoginSuccess = 0;
						SystemConfig.Dynamic.NoLoginFail = 0;
						SystemConfig.Dynamic.TodayRequest = 0;
						SystemConfig.Dynamic.TodaySuccess = 0;
						SystemConfig.Dynamic.TodayFail = 0;
						SystemConfig.Dynamic.DataSyncTime = new TimeSpan(0L);
						SystemConfig.Dynamic.APIRequestTime = new TimeSpan(0L);
						SystemConfig.Dynamic.IdleTime = new TimeSpan(0L);
						SystemConfig.Dynamic.SystemLoad = 0.0;
						SystemConfig.Dynamic.PerAPITime = 0.0;
						SystemConfig.Dynamic.APIAnalyse.Reset();
						_003CappDbContext_003E5__2 = new AppDbContext(optionsBuilder.Options);
						_003C_003E8__1.EXAccountRuns = _003CappDbContext_003E5__2.EXAccountRuns.ToList();
						for (int num6 = 0; num6 < _003C_003E8__1.EXAccountRuns.Count; _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2.EXAccountRuns.Attach(_003C_003E8__1.EXAccountRuns[num6]), EntityState.Modified, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0306), num6++)
						{
							int num7 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003CNowTime_003E5__4, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0315);
							DateTime date = _003C_003E8__1.EXAccountRuns[num6].Date;
							if (num7 == _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref date, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0315))
							{
								int num8 = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003CNowTime_003E5__4, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0314);
								date = _003C_003E8__1.EXAccountRuns[num6].Date;
								if (num8 == _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref date, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0313._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0314))
								{
									_003C_003E8__1.EXAccountRuns[num6].TodayRequest = _003C_003E8__1.EXAccountRuns[num6].Request;
									_003C_003E8__1.EXAccountRuns[num6].TodaySuccess = _003C_003E8__1.EXAccountRuns[num6].Success;
									_003C_003E8__1.EXAccountRuns[num6].TodayFail = _003C_003E8__1.EXAccountRuns[num6].Fail;
									continue;
								}
							}
							_003C_003E8__1.EXAccountRuns[num6].TodayRequest = 0;
							_003C_003E8__1.EXAccountRuns[num6].TodaySuccess = 0;
							_003C_003E8__1.EXAccountRuns[num6].TodayFail = 0;
						}
						awaiter = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_003CappDbContext_003E5__2, default(CancellationToken), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0311_030B).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 7);
							_003C_003Eu__2 = awaiter;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							break;
						}
						goto IL_172e;
					}
					goto IL_1778;
					IL_1778:
					_003Cchronograph_003E5__5.Start();
					_0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(1000, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_0313);
					SystemConfig.Dynamic.IdleTime = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(SystemConfig.Dynamic.IdleTime, _003Cchronograph_003E5__5.Stop(), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030A);
					goto IL_009c;
					IL_081f:
					result = awaiter6.GetResult();
					array = result;
					goto IL_0903;
					IL_08f6:
					result2 = awaiter5.GetResult();
					array = result2;
					goto IL_0903;
				}
			}
			catch (Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CappDbContext_003E5__2 = null;
				_003Cchronograph_003E5__5 = null;
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, ex, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0303);
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0304._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref _003C_003Et__builder, stateMachine, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0304._0300_0300_0300_000D_000A_0300_0300_0300_0300_0313_0305);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private static APIDict AzureAPI;

	private static string[] RequestAPIList;

	private static string[] LoginAPIList;

	private static string[] NoLoginAPIList;

	private static string[] LoginAPIAuthorityList;

	private static string[] NoLoginAPIAuthorityList;

	private static DbContextOptionsBuilder<AppDbContext> optionsBuilder;

	private static HttpClient httpClient;

	private static List<APIRequestAction> aPIRequestActions;

	public static IApplicationBuilder UseKernel(this IApplicationBuilder builder)
	{
		IServiceScope serviceScope = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(builder, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0310._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0311), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0313);
		try
		{
			optionsBuilder.UseFileContextDatabase<CSVSerializer, DefaultFileManager>(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x6F0F790A ^ 0x6F0F6DC4));
		}
		finally
		{
			if (serviceScope != null)
			{
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(serviceScope, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0314);
			}
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		string[] requestAPIList = RequestAPIList;
		foreach (string text in requestAPIList)
		{
			if (!list.Contains(text))
			{
				list.Add(text);
			}
			if (!list2.Contains(text) && AzureAPI.GetValueReference(text).NoLoginAvailable)
			{
				list2.Add(text);
			}
			aPIRequestActions.Add(new APIRequestAction());
		}
		LoginAPIList = list.ToArray();
		NoLoginAPIList = list2.ToArray();
		LoginAPIAuthorityList = AzureAPI.GetAuthority(RequestAPIList, IsLogin: true);
		NoLoginAPIAuthorityList = AzureAPI.GetAuthority(RequestAPIList, IsLogin: false);
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(httpClient, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0315), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0316._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0317).Add(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-51101624 ^ -51096406));
		Thread thread = new Thread(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0317);
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(thread, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030C_0318);
		return builder;
	}

	private static async Task<ReportData[]> _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0315(string P_0, string P_1, string P_2, bool P_3)
	{
		bool RandomAPIContent = true;
		Chronograph chronographTest = new Chronograph();
		Client.TokenResult tokenResult = new Client.TokenResult();
		int[] RandomAPIList = ((!P_3) ? RandomEX.GetValueArray(0, NoLoginAPIList.Length - 1, RandomEX.GetValue(1, NoLoginAPIList.Length)) : RandomEX.GetValueArray(0, LoginAPIList.Length - 1, RandomEX.GetValue(1, LoginAPIList.Length)));
		ReportData[] ReportDataList = new ReportData[RandomAPIList.Length];
		for (int C = 0; C < RandomAPIList.Length; C++)
		{
			APIBase API;
			if (P_3)
			{
				ReportDataList[C] = new ReportData(LoginAPIList[RandomAPIList[C]]);
				API = AzureAPI.GetValueReference(LoginAPIList[RandomAPIList[C]]);
				_ = LoginAPIList[RandomAPIList[C]];
			}
			else
			{
				ReportDataList[C] = new ReportData(NoLoginAPIList[RandomAPIList[C]]);
				API = AzureAPI.GetValueReference(NoLoginAPIList[RandomAPIList[C]]);
				_ = NoLoginAPIList[RandomAPIList[C]];
			}
			if (tokenResult == null || !tokenResult.Valid)
			{
				tokenResult = ((!P_3) ? (await Client.GetTokenByTenantIDClientSecret(P_1, P_0, P_2)) : (await Client.GetTokenByUsernamePassword(P_1, LoginAPIAuthorityList, P_0, P_2, UserType.Organization)));
			}
			if (tokenResult.Valid)
			{
				chronographTest.Start();
				Request.CallResult callResult = ((!P_3) ? Request.HTTPKeepAlive(httpClient, tokenResult.Content, API.URL(RandomAPIContent, P_0), API.Method, API.Content(RandomAPIContent), API.ContentType) : Request.HTTPKeepAlive(httpClient, tokenResult.Content, API.URL(RandomAPIContent), API.Method, API.Content(RandomAPIContent), API.ContentType));
				if (!callResult.Valid)
				{
					tokenResult.Valid = false;
				}
				ReportData obj = ReportDataList[C];
				string reasonPhrase = callResult.ReasonPhrase;
				bool valid = callResult.Valid;
				TimeSpan timeSpan = chronographTest.Stop();
				obj.SetResult(reasonPhrase, valid, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref timeSpan, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0302._0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0303) / 1000.0);
			}
			else
			{
				ReportDataList[C].SetResult(tokenResult.Content, IsSuccess: false, -1.0);
			}
		}
		return ReportDataList;
	}

	private static async Task<ReportData[]> _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0316(string P_0, string P_1, string P_2, bool P_3)
	{
		Client.TokenResult tokenResult = new Client.TokenResult();
		int[] RandomAPIList = ((!P_3) ? RandomEX.GetValueArray(0, NoLoginAPIList.Length - 1, RandomEX.GetValue(1, NoLoginAPIList.Length)) : RandomEX.GetValueArray(0, LoginAPIList.Length - 1, RandomEX.GetValue(1, LoginAPIList.Length)));
		ReportData[] ReportDataList = new ReportData[RandomAPIList.Length];
		int Retry = 3;
		while (Retry > 0 && (tokenResult == null || !tokenResult.Valid))
		{
			tokenResult = ((!P_3) ? (await Client.GetTokenByTenantIDClientSecret(P_1, P_0, P_2)) : (await Client.GetTokenByUsernamePassword(P_1, LoginAPIAuthorityList, P_0, P_2, UserType.Organization)));
			Retry--;
		}
		for (int i = 0; i < ReportDataList.Length; i++)
		{
			APIBase valueReference;
			string aPIName;
			if (P_3)
			{
				valueReference = AzureAPI.GetValueReference(LoginAPIList[RandomAPIList[i]]);
				aPIName = LoginAPIList[RandomAPIList[i]];
			}
			else
			{
				valueReference = AzureAPI.GetValueReference(NoLoginAPIList[RandomAPIList[i]]);
				aPIName = NoLoginAPIList[RandomAPIList[i]];
			}
			aPIRequestActions[i].Start(aPIName, valueReference, tokenResult, P_0, P_3);
		}
		for (int j = 0; j < ReportDataList.Length; j++)
		{
			while (!aPIRequestActions[j].Status)
			{
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(1, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0306_0313);
			}
			ReportDataList[j] = aPIRequestActions[j].reportData;
		}
		return ReportDataList;
	}

	[AsyncStateMachine(typeof(_003CKernelProcess_003Ed__12))]
	private static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0317()
	{
		_003CKernelProcess_003Ed__12 stateMachine = default(_003CKernelProcess_003Ed__12);
		stateMachine._003C_003Et__builder = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0300._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0300._0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0301);
		stateMachine._003C_003E1__state = -1;
		stateMachine._003C_003Et__builder.Start(ref stateMachine);
	}

	static Kernel()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		AzureAPI = StaticValue.DefaultAPI();
		RequestAPIList = AzureAPI.GetAllAPIName();
		optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
		httpClient = new HttpClient();
		aPIRequestActions = new List<APIRequestAction>();
	}
}
