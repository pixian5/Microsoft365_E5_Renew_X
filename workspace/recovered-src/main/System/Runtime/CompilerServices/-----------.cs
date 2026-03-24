using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using AzureCore;

namespace System.Runtime.CompilerServices;

internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_030F : ValidationAttribute
{
	public override bool IsValid(object P_0)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, "", _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		string text = (string)P_0;
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(text, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030F) > 64)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x5C62098A ^ 0x5C621AF2), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
			return false;
		}
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, Client.IsUserNameString(text), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0311) != null && _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0311), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030F) > 0)
		{
			return false;
		}
		return true;
	}

	public _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_030F()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0310 : ValidationAttribute
{
	public override bool IsValid(object P_0)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, "", _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		string clientID = (string)P_0;
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, Client.IsClientIDString(clientID), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0311) != null && _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0311), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030F) > 0)
		{
			return false;
		}
		return true;
	}

	public _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0310()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0311 : ValidationAttribute
{
	public override bool IsValid(object P_0)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, "", _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		string text = (string)P_0;
		if (text == null)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x1AB723A ^ 0x1AB61AC), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		}
		if (Client.IsChinese(text))
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-223900797 ^ -223897563), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		}
		if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(text, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-126246818 ^ -126241906), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030B))
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x1FC875A1 ^ 0x1FC86607), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		}
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0311) != null && _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0311), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030F) > 0)
		{
			return false;
		}
		return true;
	}

	public _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0311()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0312 : ValidationAttribute
{
	public override bool IsValid(object P_0)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, "", _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		string text = (string)P_0;
		if (text == null || _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(text, "", _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313))
		{
			return true;
		}
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(text, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030F) > 64)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-711109303 ^ -711113035), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
			return false;
		}
		if (Client.IsChinese(text))
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x2B5A42CC ^ 0x2B5A56D6), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		}
		if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(text, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x6A55C8D ^ 0x6A55D5F), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030B))
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-358695575 ^ -358700715), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		}
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0311) != null && _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0311), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030E._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_030F) > 0)
		{
			return false;
		}
		return true;
	}

	public _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0312()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0313 : ValidationAttribute
{
	public override bool IsValid(object P_0)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, "", _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		int num = 0;
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(P_0, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0305), ref num, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0313))
		{
			if (num < 1 || num > 999)
			{
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x7B11A49C ^ 0x7B11B0C4), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
				return false;
			}
			return true;
		}
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(-126246818 ^ -126241752), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		return false;
	}

	public _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0313()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0314 : ValidationAttribute
{
	public override bool IsValid(object P_0)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, "", _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		int num = 0;
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(P_0, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0303._0300_0300_0300_000D_000A_0300_0300_0300_0300_0307_0305), ref num, _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0312._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0313))
		{
			if (num < 30 || num > 999)
			{
				_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x14231C79 ^ 0x142308F7), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
				return false;
			}
			return true;
		}
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(this, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x61DD3E79 ^ 0x61DD2A0F), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_030F._0300_0300_0300_000D_000A_0300_0300_0300_0300_030B_0310);
		return false;
	}

	public _0300_0300_0300_000D_000A_0300_0300_0300_0300_0300_0314()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		base._002Ector();
	}
}
internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309
{
	internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0317
	{
		private BinaryReader g4HFsbiGpd;

		public _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0317(Stream P_0)
		{
			g4HFsbiGpd = new BinaryReader(P_0);
		}

		[SpecialName]
		internal Stream cQ1FCQpbdV()
		{
			return g4HFsbiGpd.BaseStream;
		}

		internal byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0318(int P_0)
		{
			return g4HFsbiGpd.ReadBytes(P_0);
		}

		internal int _0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0300(byte[] P_0, int P_1, int P_2)
		{
			return g4HFsbiGpd.Read(P_0, P_1, P_2);
		}

		internal int _0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0301()
		{
			return g4HFsbiGpd.ReadInt32();
		}

		internal void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0302()
		{
			g4HFsbiGpd.Close();
		}
	}

	private delegate void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0303(object o);

	internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0304
	{
		internal static string _0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0305(string P_0, string P_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(P_0);
			byte[] key = new byte[32]
			{
				82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
				51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
				34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
				1, 88
			};
			byte[] iV = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0310(Encoding.Unicode.GetBytes(P_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0303();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iV;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	private static uint[] IG9XuDRWC;

	private static Dictionary<int, int> QCPgjEiEW;

	private static Assembly WuIoji1kM;

	private static byte[] Bfk8PDaqM;

	private static int mEihBfJSV;

	private byte[] QfgTXToUk;

	private static object W7BNIhWxk;

	private static bool J89r2HJ74;

	private static List<string> Jrli8lK4c;

	private static object texPtHRnJ;

	private byte[] scu7E2hGv;

	private static List<int> tW1R3NG64;

	private static byte[] HtxKLM9A5;

	private static bool tmMURxKtO;

	private static RSACryptoServiceProvider onxH1g7yu;

	static _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309()
	{
		IG9XuDRWC = new uint[64]
		{
			3614090360u, 3905402710u, 606105819u, 3250441966u, 4118548399u, 1200080426u, 2821735955u, 4249261313u, 1770035416u, 2336552879u,
			4294925233u, 2304563134u, 1804603682u, 4254626195u, 2792965006u, 1236535329u, 4129170786u, 3225465664u, 643717713u, 3921069994u,
			3593408605u, 38016083u, 3634488961u, 3889429448u, 568446438u, 3275163606u, 4107603335u, 1163531501u, 2850285829u, 4243563512u,
			1735328473u, 2368359562u, 4294588738u, 2272392833u, 1839030562u, 4259657740u, 2763975236u, 1272893353u, 4139469664u, 3200236656u,
			681279174u, 3936430074u, 3572445317u, 76029189u, 3654602809u, 3873151461u, 530742520u, 3299628645u, 4096336452u, 1126891415u,
			2878612391u, 4237533241u, 1700485571u, 2399980690u, 4293915773u, 2240044497u, 1873313359u, 4264355552u, 2734768916u, 1309151649u,
			4149444226u, 3174756917u, 718787259u, 3951481745u
		};
		tmMURxKtO = false;
		J89r2HJ74 = false;
		QCPgjEiEW = null;
		W7BNIhWxk = new object();
		WuIoji1kM = typeof(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309).Assembly;
		Bfk8PDaqM = new byte[0];
		onxH1g7yu = null;
		HtxKLM9A5 = new byte[0];
		texPtHRnJ = new object();
		Jrli8lK4c = null;
		tW1R3NG64 = null;
		mEihBfJSV = 0;
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	internal _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309()
	{
	}

	private void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_030F()
	{
	}

	internal static byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030A(byte[] P_0)
	{
		uint[] array = new uint[16];
		uint num = (uint)((448 - P_0.Length * 8 % 512 + 512) % 512);
		if (num == 0)
		{
			num = 512u;
		}
		uint num2 = (uint)(P_0.Length + num / 8 + 8);
		ulong num3 = (ulong)P_0.Length * 8uL;
		byte[] array2 = new byte[num2];
		for (int i = 0; i < P_0.Length; i++)
		{
			array2[i] = P_0[i];
		}
		array2[P_0.Length] |= 128;
		for (int num4 = 8; num4 > 0; num4--)
		{
			array2[num2 - num4] = (byte)((num3 >> (8 - num4) * 8) & 0xFF);
		}
		uint num5 = (uint)(array2.Length * 8) / 32u;
		uint num6 = 1732584193u;
		uint num7 = 4023233417u;
		uint num8 = 2562383102u;
		uint num9 = 271733878u;
		for (uint num10 = 0u; num10 < num5 / 16; num10++)
		{
			uint num11 = num10 << 6;
			for (uint num12 = 0u; num12 < 61; num12 += 4)
			{
				array[num12 >> 2] = (uint)((array2[num11 + (num12 + 3)] << 24) | (array2[num11 + (num12 + 2)] << 16) | (array2[num11 + (num12 + 1)] << 8) | array2[num11 + num12]);
			}
			uint num13 = num6;
			uint num14 = num7;
			uint num15 = num8;
			uint num16 = num9;
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num6, num7, num8, num9, 0u, 7, 1u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num9, num6, num7, num8, 1u, 12, 2u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num8, num9, num6, num7, 2u, 17, 3u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num7, num8, num9, num6, 3u, 22, 4u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num6, num7, num8, num9, 4u, 7, 5u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num9, num6, num7, num8, 5u, 12, 6u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num8, num9, num6, num7, 6u, 17, 7u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num7, num8, num9, num6, 7u, 22, 8u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num6, num7, num8, num9, 8u, 7, 9u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num9, num6, num7, num8, 9u, 12, 10u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num8, num9, num6, num7, 10u, 17, 11u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num7, num8, num9, num6, 11u, 22, 12u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num6, num7, num8, num9, 12u, 7, 13u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num9, num6, num7, num8, 13u, 12, 14u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num8, num9, num6, num7, 14u, 17, 15u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref num7, num8, num9, num6, 15u, 22, 16u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num6, num7, num8, num9, 1u, 5, 17u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num9, num6, num7, num8, 6u, 9, 18u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num8, num9, num6, num7, 11u, 14, 19u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num7, num8, num9, num6, 0u, 20, 20u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num6, num7, num8, num9, 5u, 5, 21u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num9, num6, num7, num8, 10u, 9, 22u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num8, num9, num6, num7, 15u, 14, 23u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num7, num8, num9, num6, 4u, 20, 24u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num6, num7, num8, num9, 9u, 5, 25u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num9, num6, num7, num8, 14u, 9, 26u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num8, num9, num6, num7, 3u, 14, 27u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num7, num8, num9, num6, 8u, 20, 28u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num6, num7, num8, num9, 13u, 5, 29u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num9, num6, num7, num8, 2u, 9, 30u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num8, num9, num6, num7, 7u, 14, 31u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref num7, num8, num9, num6, 12u, 20, 32u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num6, num7, num8, num9, 5u, 4, 33u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num9, num6, num7, num8, 8u, 11, 34u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num8, num9, num6, num7, 11u, 16, 35u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num7, num8, num9, num6, 14u, 23, 36u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num6, num7, num8, num9, 1u, 4, 37u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num9, num6, num7, num8, 4u, 11, 38u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num8, num9, num6, num7, 7u, 16, 39u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num7, num8, num9, num6, 10u, 23, 40u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num6, num7, num8, num9, 13u, 4, 41u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num9, num6, num7, num8, 0u, 11, 42u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num8, num9, num6, num7, 3u, 16, 43u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num7, num8, num9, num6, 6u, 23, 44u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num6, num7, num8, num9, 9u, 4, 45u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num9, num6, num7, num8, 12u, 11, 46u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num8, num9, num6, num7, 15u, 16, 47u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref num7, num8, num9, num6, 2u, 23, 48u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num6, num7, num8, num9, 0u, 6, 49u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num9, num6, num7, num8, 7u, 10, 50u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num8, num9, num6, num7, 14u, 15, 51u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num7, num8, num9, num6, 5u, 21, 52u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num6, num7, num8, num9, 12u, 6, 53u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num9, num6, num7, num8, 3u, 10, 54u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num8, num9, num6, num7, 10u, 15, 55u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num7, num8, num9, num6, 1u, 21, 56u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num6, num7, num8, num9, 8u, 6, 57u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num9, num6, num7, num8, 15u, 10, 58u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num8, num9, num6, num7, 6u, 15, 59u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num7, num8, num9, num6, 13u, 21, 60u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num6, num7, num8, num9, 4u, 6, 61u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num9, num6, num7, num8, 11u, 10, 62u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num8, num9, num6, num7, 2u, 15, 63u, array);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref num7, num8, num9, num6, 9u, 21, 64u, array);
			num6 += num13;
			num7 += num14;
			num8 += num15;
			num9 += num16;
		}
		byte[] array3 = new byte[16];
		Array.Copy(BitConverter.GetBytes(num6), 0, array3, 0, 4);
		Array.Copy(BitConverter.GetBytes(num7), 0, array3, 4, 4);
		Array.Copy(BitConverter.GetBytes(num8), 0, array3, 8, 4);
		Array.Copy(BitConverter.GetBytes(num9), 0, array3, 12, 4);
		return array3;
	}

	private static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030B(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030F(P_0 + ((P_1 & P_2) | (~P_1 & P_3)) + P_7[P_4] + IG9XuDRWC[P_6 - 1], P_5);
	}

	private static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030C(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030F(P_0 + ((P_1 & P_3) | (P_2 & ~P_3)) + P_7[P_4] + IG9XuDRWC[P_6 - 1], P_5);
	}

	private static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030D(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030F(P_0 + (P_1 ^ P_2 ^ P_3) + P_7[P_4] + IG9XuDRWC[P_6 - 1], P_5);
	}

	private static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030E(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030F(P_0 + (P_2 ^ (P_1 | ~P_3)) + P_7[P_4] + IG9XuDRWC[P_6 - 1], P_5);
	}

	private static uint _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030F(uint P_0, ushort P_1)
	{
		return (P_0 >> 32 - P_1) | (P_0 << (int)P_1);
	}

	internal static byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0310(byte[] P_0)
	{
		if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0312())
		{
			return new MD5CryptoServiceProvider().ComputeHash(P_0);
		}
		return _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_030A(P_0);
	}

	private static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0311()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	internal static bool _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0312()
	{
		if (!tmMURxKtO)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0302();
			tmMURxKtO = true;
		}
		return J89r2HJ74;
	}

	internal byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0313()
	{
		_ = "{11111-22222-40001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0314()
	{
		_ = "{11111-22222-40001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0315()
	{
		_ = "{11111-22222-50001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0316()
	{
		_ = "{11111-22222-50001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	public static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0317(RuntimeTypeHandle P_0)
	{
		try
		{
			Type typeFromHandle = Type.GetTypeFromHandle(P_0);
			if (QCPgjEiEW == null)
			{
				lock (W7BNIhWxk)
				{
					Dictionary<int, int> dictionary = new Dictionary<int, int>();
					BinaryReader binaryReader = new BinaryReader(typeof(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309).Assembly.GetManifestResourceStream("8\u0317\u0305\u030cg\u0317\u030b\u0300j\u0306rn9\u030bcd3\u0318.\u03136\u0312\u0300f\u0312\u030c\u0303\u0308i\u0318o\u0314\u0313rr\u03071"));
					binaryReader.BaseStream.Position = 0L;
					byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
					binaryReader.Close();
					if (array.Length != 0)
					{
						int num = array.Length % 4;
						int num2 = array.Length / 4;
						byte[] array2 = new byte[array.Length];
						uint num3 = 0u;
						uint num4 = 0u;
						if (num > 0)
						{
							num2++;
						}
						uint num5 = 0u;
						for (int i = 0; i < num2; i++)
						{
							int num6 = i * 4;
							uint num7 = 255u;
							int num8 = 0;
							if (i == num2 - 1 && num > 0)
							{
								num4 = 0u;
								for (int j = 0; j < num; j++)
								{
									if (j > 0)
									{
										num4 <<= 8;
									}
									num4 |= array[^(1 + j)];
								}
							}
							else
							{
								num5 = (uint)num6;
								num4 = (uint)((array[num5 + 3] << 24) | (array[num5 + 2] << 16) | (array[num5 + 1] << 8) | array[num5]);
							}
							num3 = num3;
							uint num9 = num3;
							uint num10 = num3;
							uint num11 = 500586567u;
							uint num12 = num10;
							uint num13 = 1636293233u;
							uint num14 = 415672285u;
							uint num15 = 350574872u;
							uint num16 = 1399577934u;
							uint num17 = num11 & 0xFF00FF;
							uint num18 = num11 & 0xFF00FF00u;
							num17 = ((num17 >> 8) | (num18 << 8)) ^ num15;
							num11 = (num11 << 11) | (num11 >> 21);
							num13 -= num14;
							num13 = 2987 * (num13 & 0x3FFFF) + (num13 >> 18);
							num11 = 10422 * (num11 & 0x3FFFF) - (num11 >> 18);
							num11 = 4823 * num11 - num13;
							num15 = (num11 - num11) ^ 0xB8EB312;
							ulong num19 = 1188293690uL;
							num19 |= 1;
							num16 = (uint)(num16 * num16 % num19);
							num12 ^= num12 << 2;
							num12 += num14;
							num12 ^= num12 >> 21;
							num12 += num15;
							num12 ^= num12 << 9;
							num12 += num16;
							num12 = (((num15 << 17) - num14) ^ num14) - num12;
							num3 = num9 + (uint)(double)num12;
							if (i == num2 - 1 && num > 0)
							{
								uint num20 = num3 ^ num4;
								for (int k = 0; k < num; k++)
								{
									if (k > 0)
									{
										num7 <<= 8;
										num8 += 8;
									}
									array2[num6 + k] = (byte)((num20 & num7) >> num8);
								}
							}
							else
							{
								uint num21 = num3 ^ num4;
								array2[num6] = (byte)(num21 & 0xFF);
								array2[num6 + 1] = (byte)((num21 & 0xFF00) >> 8);
								array2[num6 + 2] = (byte)((num21 & 0xFF0000) >> 16);
								array2[num6 + 3] = (byte)((num21 & 0xFF000000u) >> 24);
							}
						}
						array = array2;
						array2 = null;
						int num22 = array.Length / 8;
						_0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0317 obj = new _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0317(new MemoryStream(array));
						for (int l = 0; l < num22; l++)
						{
							int key = obj._0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0301();
							int value = obj._0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0301();
							dictionary.Add(key, value);
						}
						obj._0300_0300_0300_000D_000A_0300_0300_0300_0300_0303_0302();
					}
					QCPgjEiEW = dictionary;
				}
			}
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			foreach (FieldInfo fieldInfo in fields)
			{
				int metadataToken = fieldInfo.MetadataToken;
				int num23 = QCPgjEiEW[metadataToken];
				bool flag = (num23 & 0x40000000) > 0;
				num23 &= 0x3FFFFFFF;
				MethodInfo methodInfo = (MethodInfo)typeof(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309).Module.ResolveMethod(num23, typeFromHandle.GetGenericArguments(), new Type[0]);
				if (methodInfo.IsStatic)
				{
					fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
					continue;
				}
				ParameterInfo[] parameters = methodInfo.GetParameters();
				int num24 = parameters.Length + 1;
				Type[] array3 = new Type[num24];
				if (methodInfo.DeclaringType.IsValueType)
				{
					array3[0] = methodInfo.DeclaringType.MakeByRefType();
				}
				else
				{
					array3[0] = typeof(object);
				}
				for (int n = 0; n < parameters.Length; n++)
				{
					array3[n + 1] = parameters[n].ParameterType;
				}
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, skipVisibility: true);
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				for (int num25 = 0; num25 < num24; num25++)
				{
					switch (num25)
					{
					case 0:
						iLGenerator.Emit(OpCodes.Ldarg_0);
						break;
					case 1:
						iLGenerator.Emit(OpCodes.Ldarg_1);
						break;
					case 2:
						iLGenerator.Emit(OpCodes.Ldarg_2);
						break;
					case 3:
						iLGenerator.Emit(OpCodes.Ldarg_3);
						break;
					default:
						iLGenerator.Emit(OpCodes.Ldarg_S, num25);
						break;
					}
				}
				iLGenerator.Emit(OpCodes.Tailcall);
				iLGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
				iLGenerator.Emit(OpCodes.Ret);
				fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	internal static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0300()
	{
	}

	private static int _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0301()
	{
		return 5;
	}

	internal static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0302()
	{
		try
		{
			J89r2HJ74 = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	internal static SymmetricAlgorithm _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0303()
	{
		SymmetricAlgorithm symmetricAlgorithm = null;
		if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0312())
		{
			return new AesCryptoServiceProvider();
		}
		try
		{
			return new RijndaelManaged();
		}
		catch
		{
			return new AesCryptoServiceProvider();
		}
	}

	private byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0304()
	{
		_ = "{11111-22222-20001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	private byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0305()
	{
		_ = "{11111-22222-20001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0306(HashAlgorithm P_0, Stream P_1, uint P_2, byte[] P_3)
	{
		while (P_2 != 0)
		{
			int num = ((P_2 > (uint)P_3.Length) ? P_3.Length : ((int)P_2));
			P_1.Read(P_3, 0, num);
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0307(P_0, P_3, 0, num);
			P_2 -= (uint)num;
		}
	}

	internal static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0307(HashAlgorithm P_0, byte[] P_1, int P_2, int P_3)
	{
		P_0.TransformBlock(P_1, P_2, P_3, P_1, P_2);
	}

	internal static uint _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0308(uint P_0, int P_1, long P_2, BinaryReader P_3)
	{
		for (int i = 0; i < P_1; i++)
		{
			P_3.BaseStream.Position = P_2 + (i * 40 + 8);
			uint num = P_3.ReadUInt32();
			uint num2 = P_3.ReadUInt32();
			P_3.ReadUInt32();
			uint num3 = P_3.ReadUInt32();
			if (num2 <= P_0 && P_0 < num2 + num)
			{
				return num3 + P_0 - num2;
			}
		}
		return 0u;
	}

	private static Stream _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0309()
	{
		return new MemoryStream();
	}

	private static byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_030A(string P_0)
	{
		using FileStream fileStream = new FileStream(P_0, FileMode.Open, FileAccess.Read, FileShare.Read);
		int num = 0;
		int num2 = (int)fileStream.Length;
		byte[] array = new byte[num2];
		while (num2 > 0)
		{
			int num3 = fileStream.Read(array, num, num2);
			num += num3;
			num2 -= num3;
		}
		return array;
	}

	internal static object _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_030B(object P_0)
	{
		try
		{
			if (File.Exists(((Assembly)P_0).Location))
			{
				return ((Assembly)P_0).Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(((Assembly)P_0).GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return ((Assembly)P_0).GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(P_0.GetType().GetProperty("Location").GetValue(P_0, new object[0])
				.ToString()))
			{
				return P_0.GetType().GetProperty("Location").GetValue(P_0, new object[0])
					.ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	private static byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_030C(Stream P_0)
	{
		return ((MemoryStream)P_0).ToArray();
	}

	internal byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_030D()
	{
		_ = "{11111-22222-30001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_030E()
	{
		_ = "{11111-22222-30001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_030F(Stream P_0)
	{
		int num = 2;
		int num2 = num;
		BinaryReader binaryReader = default(BinaryReader);
		byte[] array2 = default(byte[]);
		int num5 = default(int);
		byte[] array5 = default(byte[]);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				binaryReader = new BinaryReader(P_0);
				num2 = 1;
				if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 1:
				try
				{
					_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0313(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0312(binaryReader), 0L);
					int num3 = 49;
					if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
					{
						num3 = 37;
					}
					while (true)
					{
						int num6;
						switch (num3)
						{
						case 74:
							return;
						case 89:
							array2[3] = (byte)num5;
							num3 = 118;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 195;
							}
							break;
						case 197:
							array2[27] = (byte)num5;
							num3 = 8;
							break;
						case 168:
							array2[8] = 141;
							num3 = 36;
							break;
						case 236:
							num5 = 202 - 67;
							num3 = 45;
							break;
						case 34:
							array2[12] = 140;
							num3 = 63;
							break;
						case 70:
							array2[8] = (byte)num5;
							num3 = 24;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 123;
							}
							break;
						case 202:
							num5 = 226 - 75;
							num3 = 0;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 0;
							}
							break;
						case 160:
							num5 = 211 - 70;
							num3 = 123;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 140;
							}
							break;
						case 154:
							array2[15] = 139;
							num3 = 46;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 4;
							}
							break;
						case 25:
							array2[0] = 129;
							num3 = 210;
							break;
						case 149:
							num5 = 201 - 67;
							num3 = 130;
							break;
						case 31:
							num5 = 194 - 64;
							num3 = 21;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 16;
							}
							break;
						case 213:
							array2[14] = (byte)num5;
							num6 = 127;
							goto IL_0074;
						case 161:
							array2[1] = (byte)num5;
							num3 = 217;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 135;
							}
							break;
						case 103:
							array2[16] = (byte)num5;
							num3 = 12;
							break;
						case 204:
							array2[12] = 182;
							num3 = 34;
							break;
						case 166:
							array2[26] = (byte)num5;
							num3 = 186;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 118;
							}
							break;
						case 138:
							num5 = 47 - 40;
							num3 = 71;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 76;
							}
							break;
						case 144:
							num5 = 173 - 57;
							num3 = 37;
							break;
						case 174:
							array2[16] = 170;
							num3 = 193;
							break;
						case 36:
							num5 = 196 + 44;
							num3 = 70;
							break;
						case 162:
							array2[6] = (byte)num5;
							num3 = 29;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 3;
							}
							break;
						case 95:
							array2[17] = (byte)num5;
							num3 = 100;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 203;
							}
							break;
						case 97:
							array2[19] = 158;
							num3 = 184;
							break;
						case 22:
							array2[23] = 172;
							num3 = 136;
							break;
						case 26:
							num5 = 157 - 52;
							num3 = 143;
							break;
						case 105:
							num5 = 111 + 4;
							num3 = 88;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 88;
							}
							break;
						case 44:
							num5 = 129 + 93;
							num3 = 95;
							break;
						case 235:
							num5 = 252 - 84;
							num3 = 187;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 218;
							}
							break;
						case 8:
							num5 = 168 - 56;
							num3 = 114;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 129;
							}
							break;
						case 198:
							array2[2] = 214;
							num3 = 71;
							break;
						case 212:
							num5 = 221 - 73;
							num3 = 42;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 23;
							}
							break;
						case 115:
							array2[31] = (byte)num5;
							num3 = 3;
							break;
						case 18:
							num5 = 86 + 52;
							num3 = 107;
							break;
						case 176:
							array2[3] = 56;
							num3 = 98;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 120;
							}
							break;
						case 60:
							array2[15] = 185;
							num3 = 44;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 141;
							}
							break;
						case 136:
							num5 = 67 + 81;
							num3 = 96;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 200;
							}
							break;
						case 163:
							array2[7] = 121;
							num3 = 211;
							break;
						case 178:
							array2[26] = (byte)num5;
							num3 = 23;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 30;
							}
							break;
						case 167:
							num5 = 88 + 46;
							num3 = 73;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 114;
							}
							break;
						case 152:
							num5 = 124 - 65;
							num3 = 220;
							break;
						case 29:
							array2[6] = 197;
							num3 = 175;
							break;
						case 59:
							num5 = 87 - 74;
							num3 = 65;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 61;
							}
							break;
						case 7:
							num5 = 10 + 85;
							num3 = 41;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 4;
							}
							break;
						case 196:
							array2[4] = (byte)num5;
							num3 = 15;
							break;
						case 146:
							num5 = 180 + 31;
							num3 = 197;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 4;
							}
							break;
						case 183:
							array2[7] = 153;
							num3 = 18;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 32;
							}
							break;
						case 141:
							num5 = 201 - 67;
							num3 = 103;
							break;
						case 206:
							array2[9] = (byte)num5;
							num3 = 70;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 72;
							}
							break;
						case 127:
							num5 = 118 + 56;
							num3 = 153;
							break;
						case 117:
							array2[11] = 216;
							num3 = 1;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 51;
							}
							break;
						case 233:
							array2[10] = 167;
							num3 = 235;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 186;
							}
							break;
						case 63:
							array2[12] = 118;
							num6 = 58;
							goto IL_0074;
						case 17:
							array2[21] = 136;
							num3 = 58;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 159;
							}
							break;
						case 158:
							num5 = 114 + 39;
							num3 = 227;
							break;
						case 82:
							num5 = 180 - 92;
							num3 = 128;
							break;
						case 83:
							array2[25] = 225;
							num3 = 112;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 39;
							}
							break;
						case 177:
							array2[18] = (byte)num5;
							num3 = 101;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 167;
							}
							break;
						case 24:
							num5 = 159 - 53;
							num3 = 16;
							break;
						case 57:
							num5 = 90 + 63;
							num3 = 165;
							break;
						case 28:
							num5 = 180 - 60;
							num3 = 0;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 6;
							}
							break;
						case 137:
							array2[20] = 156;
							num3 = 75;
							break;
						case 201:
							array2[22] = 204;
							num3 = 99;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 21;
							}
							break;
						case 169:
							array2[0] = 117;
							num3 = 7;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 25;
							}
							break;
						case 126:
							array2[6] = 20;
							num3 = 135;
							break;
						case 200:
							array2[24] = (byte)num5;
							num3 = 10;
							break;
						case 148:
							num5 = 97 + 7;
							num3 = 55;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 190;
							}
							break;
						case 140:
							array2[3] = (byte)num5;
							num6 = 62;
							goto IL_0074;
						case 110:
							array2[13] = 44;
							num6 = 96;
							goto IL_0074;
						case 72:
							num5 = 121 + 75;
							num6 = 84;
							goto IL_0074;
						case 4:
							num5 = 150 + 50;
							num3 = 24;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 206;
							}
							break;
						case 189:
							array2[19] = (byte)num5;
							num3 = 231;
							break;
						case 230:
							num5 = 200 + 52;
							num3 = 86;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 102;
							}
							break;
						case 116:
							array2[31] = 119;
							num3 = 164;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 54;
							}
							break;
						case 172:
							array2[23] = 146;
							num3 = 21;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 47;
							}
							break;
						case 209:
							array2[11] = (byte)num5;
							num3 = 52;
							break;
						case 130:
							array2[21] = (byte)num5;
							num3 = 148;
							break;
						case 47:
							array2[23] = 115;
							num6 = 64;
							goto IL_0074;
						case 179:
							num5 = 161 - 53;
							num3 = 161;
							break;
						case 214:
							array2[26] = 62;
							num3 = 107;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 150;
							}
							break;
						case 108:
							array2[8] = (byte)num5;
							num3 = 168;
							break;
						case 159:
							array2[21] = 135;
							num3 = 14;
							break;
						case 184:
							num5 = 128 - 42;
							num3 = 80;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 47;
							}
							break;
						case 65:
							array2[4] = (byte)num5;
							num3 = 124;
							break;
						case 86:
							num5 = 27 + 12;
							num6 = 166;
							goto IL_0074;
						case 109:
							array2[6] = (byte)num5;
							num3 = 126;
							break;
						case 73:
							array2[15] = (byte)num5;
							num6 = 69;
							goto IL_0074;
						case 187:
							num5 = 3 + 89;
							num3 = 10;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 92;
							}
							break;
						case 145:
							num5 = 60 + 64;
							num3 = 33;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 90;
							}
							break;
						case 101:
							num5 = 5 + 61;
							num3 = 27;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 3;
							}
							break;
						case 229:
							num5 = 82 + 47;
							num3 = 132;
							break;
						case 194:
							array2 = new byte[32];
							num6 = 35;
							goto IL_0074;
						case 77:
							array2[17] = 162;
							num6 = 202;
							goto IL_0074;
						case 78:
							array2[27] = 47;
							num3 = 31;
							break;
						case 11:
							array2[1] = (byte)num5;
							num3 = 179;
							break;
						case 30:
							array2[26] = 111;
							num3 = 214;
							break;
						case 195:
							num5 = 182 - 60;
							num3 = 134;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 196;
							}
							break;
						case 67:
							num5 = 223 - 74;
							num3 = 213;
							break;
						case 157:
							num5 = 107 - 36;
							num3 = 98;
							break;
						case 215:
							num5 = 254 - 84;
							num3 = 185;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 64;
							}
							break;
						case 224:
							array2[6] = 117;
							num3 = 23;
							break;
						case 62:
							num5 = 181 - 66;
							num3 = 89;
							break;
						case 232:
							array2[17] = 144;
							num3 = 44;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 42;
							}
							break;
						case 38:
							array2[18] = 128;
							num3 = 2;
							break;
						case 216:
							array2[9] = (byte)num5;
							num3 = 3;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 4;
							}
							break;
						case 118:
							num5 = 220 - 73;
							num3 = 46;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 94;
							}
							break;
						case 234:
							array2[0] = 120;
							num3 = 122;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 37;
							}
							break;
						case 113:
							num5 = 189 - 63;
							num3 = 216;
							break;
						case 156:
							array2[15] = (byte)num5;
							num3 = 60;
							break;
						case 225:
							array2[15] = (byte)num5;
							num6 = 229;
							goto IL_0074;
						case 203:
							array2[18] = 167;
							num6 = 38;
							goto IL_0074;
						case 111:
							num5 = 236 - 78;
							num6 = 189;
							goto IL_0074;
						case 231:
							array2[19] = 133;
							num6 = 97;
							goto IL_0074;
						case 223:
							num5 = 29 + 59;
							num3 = 40;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 39;
							}
							break;
						case 191:
							array2[1] = (byte)num5;
							num3 = 74;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 82;
							}
							break;
						case 88:
							array2[8] = (byte)num5;
							num3 = 17;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 19;
							}
							break;
						case 123:
							num5 = 42 + 120;
							num3 = 192;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 156;
							}
							break;
						case 53:
							num5 = 143 - 47;
							num3 = 44;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 73;
							}
							break;
						case 124:
							num5 = 175 - 58;
							num3 = 57;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 68;
							}
							break;
						case 135:
							num5 = 89 + 119;
							num3 = 100;
							break;
						case 54:
							array2[27] = 164;
							num3 = 78;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 78;
							}
							break;
						case 16:
							array2[22] = (byte)num5;
							num3 = 201;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 158;
							}
							break;
						case 6:
							array2[20] = (byte)num5;
							num3 = 57;
							break;
						case 2:
							num5 = 112 + 22;
							num3 = 38;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 177;
							}
							break;
						case 87:
							array2[30] = (byte)num5;
							num3 = 24;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 188;
							}
							break;
						case 125:
							array2[24] = (byte)num5;
							num3 = 144;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 37;
							}
							break;
						case 220:
							array2[30] = (byte)num5;
							num3 = 96;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 104;
							}
							break;
						case 51:
							num5 = 230 - 76;
							num3 = 209;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 41;
							}
							break;
						case 46:
							num5 = 229 - 76;
							num3 = 156;
							break;
						case 188:
							array2[30] = 112;
							num3 = 13;
							break;
						case 9:
							num5 = 75 + 79;
							num3 = 39;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 38;
							}
							break;
						case 185:
							array2[25] = (byte)num5;
							num3 = 7;
							break;
						case 81:
							array2[19] = 59;
							num3 = 5;
							break;
						case 55:
							num5 = 196 - 65;
							num3 = 87;
							break;
						case 21:
							array2[27] = (byte)num5;
							num3 = 158;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 48;
							}
							break;
						case 49:
							array5 = (byte[])_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0315(binaryReader, (int)_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0314(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0312(binaryReader)));
							num3 = 194;
							break;
						case 92:
							array2[13] = (byte)num5;
							num3 = 205;
							break;
						case 12:
							num5 = 91 + 25;
							num3 = 173;
							break;
						case 13:
							num5 = 96 + 95;
							num3 = 228;
							break;
						case 23:
							array2[6] = 186;
							num3 = 180;
							break;
						case 217:
							num5 = 123 + 84;
							num3 = 91;
							break;
						case 199:
							array2[29] = 130;
							num3 = 157;
							break;
						case 15:
							array2[4] = 154;
							num3 = 33;
							break;
						case 222:
							array2[2] = 115;
							num3 = 139;
							break;
						case 96:
							array2[14] = 137;
							num3 = 131;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 83;
							}
							break;
						case 40:
							array2[25] = (byte)num5;
							num3 = 101;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 30;
							}
							break;
						case 79:
							array2[0] = (byte)num5;
							num3 = 169;
							break;
						case 181:
							array2[22] = 201;
							num6 = 24;
							goto IL_0074;
						case 165:
							array2[20] = (byte)num5;
							num3 = 142;
							break;
						case 104:
							array2[31] = 115;
							num3 = 116;
							break;
						case 14:
							array2[21] = 152;
							num3 = 181;
							break;
						case 75:
							num5 = 96 + 84;
							num3 = 20;
							break;
						case 52:
							array2[11] = 193;
							num3 = 1;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 1;
							}
							break;
						case 129:
							array2[28] = (byte)num5;
							num3 = 221;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 121;
							}
							break;
						case 99:
							array2[23] = 97;
							num3 = 172;
							break;
						case 32:
							array2[7] = 213;
							num3 = 18;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 18;
							}
							break;
						case 175:
							num5 = 202 - 67;
							num3 = 109;
							break;
						case 193:
							array2[16] = 6;
							num3 = 77;
							break;
						case 171:
							num5 = 249 - 83;
							num3 = 125;
							break;
						case 190:
							array2[21] = (byte)num5;
							num3 = 236;
							break;
						case 128:
							array2[1] = (byte)num5;
							num3 = 50;
							break;
						case 61:
							num5 = 18 + 28;
							num3 = 147;
							break;
						case 132:
							array2[15] = (byte)num5;
							num3 = 128;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 154;
							}
							break;
						case 42:
							array2[29] = (byte)num5;
							num3 = 199;
							break;
						case 147:
							array2[23] = (byte)num5;
							num3 = 22;
							break;
						case 219:
							array2[16] = 95;
							num6 = 174;
							goto IL_0074;
						case 84:
							array2[10] = (byte)num5;
							num3 = 26;
							break;
						case 48:
							num5 = 5 + 16;
							num3 = 11;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 7;
							}
							break;
						case 205:
							num5 = 136 - 45;
							num3 = 207;
							break;
						case 186:
							num5 = 73 + 14;
							num3 = 178;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 56;
							}
							break;
						case 131:
							num5 = 170 - 56;
							num3 = 93;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
							{
								num3 = 47;
							}
							break;
						case 71:
							array2[2] = 108;
							num3 = 66;
							break;
						case 56:
							array2[20] = (byte)num5;
							num3 = 149;
							break;
						case 98:
							array2[29] = (byte)num5;
							num3 = 55;
							break;
						case 106:
							array2[2] = (byte)num5;
							num3 = 198;
							break;
						case 139:
							num5 = 38 + 104;
							num3 = 106;
							break;
						case 112:
							array2[26] = 87;
							num3 = 86;
							break;
						case 133:
							array2[27] = 117;
							num3 = 146;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 15;
							}
							break;
						case 208:
							array2[18] = 31;
							num3 = 111;
							break;
						case 221:
							array2[28] = 115;
							num6 = 118;
							goto IL_0074;
						case 120:
							num5 = 132 - 44;
							num3 = 125;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 170;
							}
							break;
						case 76:
							array2[24] = (byte)num5;
							num3 = 215;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 119;
							}
							break;
						case 20:
							array2[20] = (byte)num5;
							num6 = 9;
							goto IL_0074;
						case 69:
							num5 = 117 + 49;
							num3 = 225;
							break;
						case 19:
							num5 = 150 - 50;
							num3 = 108;
							break;
						case 80:
							array2[19] = (byte)num5;
							num3 = 81;
							break;
						case 91:
							array2[1] = (byte)num5;
							num3 = 85;
							break;
						case 207:
							array2[13] = (byte)num5;
							num3 = 110;
							break;
						case 164:
							num5 = 39 - 13;
							num3 = 115;
							break;
						case 182:
							array2[12] = (byte)num5;
							num3 = 64;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 204;
							}
							break;
						case 153:
							array2[14] = (byte)num5;
							num3 = 134;
							break;
						case 27:
							array2[25] = (byte)num5;
							num3 = 83;
							break;
						case 122:
							num5 = 232 - 77;
							num3 = 34;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 79;
							}
							break;
						case 119:
							array2[8] = 132;
							num3 = 105;
							break;
						case 100:
							array2[7] = (byte)num5;
							num3 = 183;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 29;
							}
							break;
						case 43:
							array2[5] = 76;
							num3 = 230;
							break;
						case 90:
							array2[3] = (byte)num5;
							num3 = 176;
							break;
						case 227:
							array2[27] = (byte)num5;
							num3 = 133;
							break;
						case 211:
							array2[7] = 207;
							num3 = 93;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 119;
							}
							break;
						case 58:
							array2[13] = 96;
							num3 = 30;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 187;
							}
							break;
						case 134:
							num5 = 96 + 67;
							num3 = 151;
							break;
						case 68:
							array2[5] = (byte)num5;
							num3 = 43;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 226;
							}
							break;
						case 170:
							array2[3] = (byte)num5;
							num3 = 160;
							break;
						case 226:
							array2[5] = 101;
							num3 = 43;
							break;
						default:
							array2[17] = (byte)num5;
							num3 = 232;
							break;
						case 94:
							array2[28] = (byte)num5;
							num3 = 155;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 48;
							}
							break;
						case 155:
							array2[28] = 167;
							num3 = 212;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 39;
							}
							break;
						case 228:
							array2[30] = (byte)num5;
							num3 = 88;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 152;
							}
							break;
						case 33:
							array2[4] = 134;
							num3 = 48;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 59;
							}
							break;
						case 218:
							array2[11] = (byte)num5;
							num3 = 117;
							break;
						case 10:
							array2[24] = 145;
							num3 = 171;
							break;
						case 41:
							array2[25] = (byte)num5;
							num3 = 223;
							break;
						case 50:
							array2[2] = 123;
							num3 = 222;
							break;
						case 66:
							array2[3] = 112;
							num3 = 10;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 145;
							}
							break;
						case 93:
							array2[14] = (byte)num5;
							num3 = 10;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 67;
							}
							break;
						case 1:
							num5 = 154 - 51;
							num3 = 182;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 114;
							}
							break;
						case 143:
							array2[10] = (byte)num5;
							num3 = 233;
							break;
						case 37:
							array2[24] = (byte)num5;
							num3 = 138;
							break;
						case 142:
							num5 = 65 + 63;
							num3 = 56;
							break;
						case 151:
							array2[14] = (byte)num5;
							num3 = 44;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 53;
							}
							break;
						case 102:
							array2[5] = (byte)num5;
							num3 = 224;
							break;
						case 35:
							num5 = 50 + 110;
							num6 = 121;
							goto IL_0074;
						case 107:
							array2[7] = (byte)num5;
							num3 = 163;
							break;
						case 45:
							array2[21] = (byte)num5;
							num3 = 17;
							break;
						case 64:
							array2[23] = 91;
							num3 = 61;
							break;
						case 180:
							num5 = 10 + 65;
							num3 = 101;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 162;
							}
							break;
						case 210:
							array2[0] = 118;
							num3 = 48;
							break;
						case 39:
							array2[20] = (byte)num5;
							num3 = 28;
							break;
						case 114:
							array2[18] = (byte)num5;
							num3 = 208;
							if (!_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310())
							{
								num3 = 72;
							}
							break;
						case 192:
							array2[9] = (byte)num5;
							num3 = 37;
							if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() == null)
							{
								num3 = 113;
							}
							break;
						case 173:
							array2[16] = (byte)num5;
							num6 = 219;
							goto IL_0074;
						case 121:
							array2[0] = (byte)num5;
							num6 = 234;
							goto IL_0074;
						case 85:
							num5 = 251 - 83;
							num3 = 191;
							break;
						case 150:
							array2[26] = 169;
							num3 = 54;
							break;
						case 5:
							array2[19] = 226;
							num3 = 137;
							break;
						case 3:
							{
								byte[] array = array2;
								byte[] array3 = new byte[16]
								{
									118, 0, 0, 0, 0, 0, 0, 0, 0, 0,
									0, 0, 0, 0, 0, 0
								};
								int num4 = 251 - 83;
								array3[0] = (byte)num4;
								array3[0] = 245;
								num4 = 16 + 103;
								array3[1] = (byte)num4;
								num4 = 175 - 58;
								array3[1] = (byte)num4;
								array3[1] = 109;
								array3[1] = 150;
								num4 = 16 + 105;
								array3[1] = (byte)num4;
								num4 = 67 - 53;
								array3[1] = (byte)num4;
								num4 = 212 - 70;
								array3[2] = (byte)num4;
								num4 = 121 + 23;
								array3[2] = (byte)num4;
								array3[2] = 102;
								num4 = 141 - 47;
								array3[2] = (byte)num4;
								array3[2] = 106;
								array3[2] = 177;
								num4 = 241 - 80;
								array3[3] = (byte)num4;
								num4 = 251 - 83;
								array3[3] = (byte)num4;
								array3[3] = 81;
								num4 = 60 + 64;
								array3[3] = (byte)num4;
								array3[3] = 106;
								array3[3] = 142;
								num4 = 7 + 94;
								array3[4] = (byte)num4;
								num4 = 60 + 66;
								array3[4] = (byte)num4;
								array3[4] = 130;
								array3[5] = 94;
								num4 = 187 - 62;
								array3[5] = (byte)num4;
								num4 = 212 - 70;
								array3[5] = (byte)num4;
								num4 = 223 - 74;
								array3[5] = (byte)num4;
								array3[5] = 142;
								array3[5] = 166;
								array3[6] = 83;
								array3[6] = 95;
								num4 = 179 - 59;
								array3[6] = (byte)num4;
								num4 = 175 - 58;
								array3[6] = (byte)num4;
								array3[6] = 30;
								num4 = 95 + 88;
								array3[7] = (byte)num4;
								num4 = 65 + 56;
								array3[7] = (byte)num4;
								num4 = 200 - 66;
								array3[7] = (byte)num4;
								array3[7] = 233;
								array3[8] = 112;
								array3[8] = 208;
								num4 = 85 + 101;
								array3[8] = (byte)num4;
								num4 = 26 + 99;
								array3[9] = (byte)num4;
								array3[9] = 158;
								num4 = 195 - 65;
								array3[9] = (byte)num4;
								array3[9] = 144;
								num4 = 205 - 68;
								array3[10] = (byte)num4;
								num4 = 136 - 45;
								array3[10] = (byte)num4;
								num4 = 111 + 4;
								array3[10] = (byte)num4;
								num4 = 150 - 50;
								array3[10] = (byte)num4;
								array3[10] = 141;
								num4 = 188 + 44;
								array3[10] = (byte)num4;
								num4 = 169 - 56;
								array3[11] = (byte)num4;
								array3[11] = 162;
								num4 = 159 - 53;
								array3[11] = (byte)num4;
								num4 = 240 - 80;
								array3[11] = (byte)num4;
								array3[11] = 136;
								num4 = 131 + 30;
								array3[11] = (byte)num4;
								num4 = 67 + 122;
								array3[12] = (byte)num4;
								num4 = 226 - 75;
								array3[12] = (byte)num4;
								num4 = 122 - 86;
								array3[12] = (byte)num4;
								array3[13] = 156;
								num4 = 28 + 113;
								array3[13] = (byte)num4;
								array3[13] = 186;
								num4 = 107 + 103;
								array3[13] = (byte)num4;
								num4 = 20 + 63;
								array3[14] = (byte)num4;
								num4 = 186 - 62;
								array3[14] = (byte)num4;
								array3[14] = 71;
								array3[15] = 68;
								num4 = 39 + 106;
								array3[15] = (byte)num4;
								num4 = 232 - 77;
								array3[15] = (byte)num4;
								array3[15] = 147;
								num4 = 117 + 118;
								array3[15] = (byte)num4;
								byte[] array4 = array3;
								if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0317(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0316(WuIoji1kM), null))
								{
									mEihBfJSV = 80;
								}
								HtxKLM9A5 = new _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309(array, array4)._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0311(array5);
								num3 = 74;
								if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
								{
									num3 = 46;
								}
								break;
							}
							IL_0074:
							num3 = num6;
							break;
						}
					}
				}
				finally
				{
					int num7;
					if (binaryReader == null)
					{
						num7 = 1;
						if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311() != null)
						{
							num7 = 0;
						}
						goto IL_2a9e;
					}
					goto IL_2ad3;
					IL_2a9e:
					switch (num7)
					{
					case 1:
						goto end_IL_2a79;
					case 2:
						goto end_IL_2a79;
					}
					goto IL_2ad3;
					IL_2ad3:
					_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0318(binaryReader);
					int num8 = 2;
					num7 = num8;
					goto IL_2a9e;
					end_IL_2a79:;
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(int P_0)
	{
		if (HtxKLM9A5.Length == 0)
		{
			Jrli8lK4c = new List<string>();
			tW1R3NG64 = new List<int>();
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_030F(typeof(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309).GetTypeInfo().Assembly.GetManifestResourceStream("\u0312y594\u0307\u0301\u030c\u030b9u53\u030frvlk.rw\u0316\u0318c\u030a\u0302\u030doyr\u03000i\u0305\u030bq2"));
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		}
		if (mEihBfJSV < 75)
		{
			if (WuIoji1kM != new StackFrame(1).GetMethod().DeclaringType.Assembly)
			{
				throw new Exception();
			}
			mEihBfJSV++;
		}
		lock (texPtHRnJ)
		{
			int num = BitConverter.ToInt32(HtxKLM9A5, P_0);
			if (num < tW1R3NG64.Count && tW1R3NG64[num] == P_0)
			{
				return Jrli8lK4c[num];
			}
			try
			{
				byte[] array = new byte[num];
				Array.Copy(HtxKLM9A5, P_0 + 4, array, 0, num);
				string text = Encoding.Unicode.GetString(array, 0, array.Length);
				Jrli8lK4c.Add(text);
				tW1R3NG64.Add(P_0);
				Array.Copy(BitConverter.GetBytes(Jrli8lK4c.Count - 1), 0, HtxKLM9A5, P_0, 4);
				return text;
			}
			catch
			{
			}
		}
		return "";
	}

	private _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309(byte[] P_0, byte[] P_1)
	{
		scu7E2hGv = P_0;
		QfgTXToUk = P_1;
	}

	private byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0311(byte[] P_0)
	{
		if (P_0.Length == 0)
		{
			return new byte[0];
		}
		int num = P_0.Length % 4;
		int num2 = P_0.Length / 4;
		byte[] array = new byte[P_0.Length];
		int num3 = scu7E2hGv.Length / 4;
		uint num4 = 0u;
		uint num5 = 0u;
		uint num6 = 0u;
		if (num > 0)
		{
			num2++;
		}
		uint num7 = 0u;
		for (int i = 0; i < num2; i++)
		{
			int num8 = i % num3;
			int num9 = i * 4;
			num7 = (uint)(num8 * 4);
			num5 = (uint)((scu7E2hGv[num7 + 3] << 24) | (scu7E2hGv[num7 + 2] << 16) | (scu7E2hGv[num7 + 1] << 8) | scu7E2hGv[num7]);
			if (i == num2 - 1 && num > 0)
			{
				num6 = 0u;
				uint num10 = 255u;
				int num11 = 0;
				for (int j = 0; j < num; j++)
				{
					if (j > 0)
					{
						num6 <<= 8;
					}
					num6 |= P_0[^(1 + j)];
				}
				num4 += num5;
				num4 += _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0312(num4);
				uint num12 = num4 ^ num6;
				for (int k = 0; k < num; k++)
				{
					if (k > 0)
					{
						num10 <<= 8;
						num11 += 8;
					}
					array[num9 + k] = (byte)((num12 & num10) >> num11);
				}
			}
			else
			{
				num7 = (uint)num9;
				num6 = (uint)((P_0[num7 + 3] << 24) | (P_0[num7 + 2] << 16) | (P_0[num7 + 1] << 8) | P_0[num7]);
				num4 += num5;
				num4 += _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0312(num4);
				uint num13 = num4 ^ num6;
				array[num9] = (byte)(num13 & 0xFF);
				array[num9 + 1] = (byte)((num13 & 0xFF00) >> 8);
				array[num9 + 2] = (byte)((num13 & 0xFF0000) >> 16);
				array[num9 + 3] = (byte)((num13 & 0xFF000000u) >> 24);
			}
		}
		return array;
	}

	private uint _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0312(uint P_0)
	{
		uint num = P_0;
		uint num2 = 973202305u;
		uint num3 = 1582787682u;
		uint num4 = 1577548636u;
		uint num5 = 332884210u;
		ulong num6 = num4 * 1313243236;
		num6 |= 1;
		num3 = (uint)(num3 * num3 % num6);
		ulong num7 = 1907532890 * num4;
		if (num7 == 0L)
		{
			num7--;
		}
		_ = 698203908u % num7;
		num2 = (uint)(-502326134 - num3);
		ulong num8 = num3 * 183835789;
		num8 |= 1;
		num4 = (uint)(num4 * num4 % num8);
		uint num9 = ((num5 >> 6) | (num5 << 26)) ^ num3;
		uint num10 = num9 & 0xF0F0F0F;
		num5 = ((num9 & 0xF0F0F0F0u) >> 4) | (num10 << 4);
		num ^= num << 3;
		num += num2;
		num ^= num << 11;
		num += num4;
		num ^= num >> 27;
		num += num5;
		return (((num2 << 11) - num3) ^ num4) - num;
	}

	internal static string _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0313(string P_0)
	{
		"{11111-22222-50001-00000}".Trim();
		byte[] array = Convert.FromBase64String(P_0);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	private static byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0314(byte[] P_0)
	{
		return new _0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309(new byte[32]
		{
			123, 5, 74, 12, 244, 156, 221, 154, 121, 221,
			183, 41, 121, 65, 9, 43, 67, 81, 23, 43,
			74, 63, 64, 23, 95, 185, 226, 244, 45, 194,
			211, 43
		}, new byte[16]
		{
			117, 254, 41, 121, 65, 52, 9, 43, 221, 154,
			12, 54, 68, 241, 68, 66
		})._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0311(P_0);
	}

	private byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0315()
	{
		return null;
	}

	private byte[] _0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0316()
	{
		return null;
	}

	internal static object _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0312(object P_0)
	{
		return ((BinaryReader)P_0).BaseStream;
	}

	internal static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0313(object P_0, long P_1)
	{
		((Stream)P_0).Position = P_1;
	}

	internal static long _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0314(object P_0)
	{
		return ((Stream)P_0).Length;
	}

	internal static object _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0315(object P_0, int P_1)
	{
		return ((BinaryReader)P_0).ReadBytes(P_1);
	}

	internal static object _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0316(object P_0)
	{
		return ((Assembly)P_0).EntryPoint;
	}

	internal static bool _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0317(object P_0, object P_1)
	{
		return (MethodInfo?)P_0 == (MethodInfo?)P_1;
	}

	internal static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0318(object P_0)
	{
		((IDisposable)P_0).Dispose();
	}

	internal static bool _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0310()
	{
		return (object)null == null;
	}

	internal static object _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_0311()
	{
		return null;
	}
}
internal class _0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A
{
	private static bool XhYBtHM2bi;

	internal static void _0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310()
	{
		if (XhYBtHM2bi)
		{
			XhYBtHM2bi = true;
			TimeSpan timeSpan = _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0308._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0301._0300_0300_0300_000D_000A_0300_0300_0300_0300_0309_0302), new DateTime(2022, 5, 30), _0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0308._0300_0300_0300_000D_000A_0300_0300_0300_0300_030D_0309);
			if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_030D._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030C._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(ref timeSpan, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030C._0300_0300_0300_000D_000A_0300_0300_0300_0300_0312_030D), _0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_030D._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_030E) >= 14)
			{
				throw new Exception(_0300_0300_0300_000D_000A_0300_0300_0300_0300_0301_0309._0300_0300_0300_000D_000A_0300_0300_0300_0300_0302_0310(0x38A70265 ^ 0x38A730AF));
			}
		}
	}
}
