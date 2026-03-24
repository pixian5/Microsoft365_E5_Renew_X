using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzureCore;

public class APIDict
{
	private Dictionary<string, APIBase> Dict;

	public APIDict()
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		Dict = new Dictionary<string, APIBase>();
		base._002Ector();
	}

	public void Add(string APIName, APIBase API)
	{
		Dict.Add(APIName, API);
	}

	public bool Remove(string APIName)
	{
		return Dict.Remove(APIName);
	}

	public APIBase GetValue(string APIName)
	{
		return new APIBase(Dict[APIName]);
	}

	public APIBase GetValueReference(string APIName)
	{
		return Dict[APIName];
	}

	public string[] GetAllAPIName()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, APIBase> item in Dict)
		{
			list.Add(item.Key);
		}
		return list.ToArray();
	}

	public string[] GetAllAPIClass()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, APIBase> item in Dict)
		{
			string[] array = _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0311._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(item.Key, '.', StringSplitOptions.None, _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0311._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0312);
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				if (_0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0300(list[i], array[0], _0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0305._0300_0300_0300_000D_000A_0300_0300_0300_0300_0305_0313))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(array[0]);
			}
		}
		return list.ToArray();
	}

	public string[] GetAuthority(string[] APINameList, bool IsLogin)
	{
		List<string> list = new List<string>();
		foreach (string key in APINameList)
		{
			string text = "";
			try
			{
				text = Dict[key].Authority;
			}
			catch (Exception)
			{
				continue;
			}
			if (IsLogin)
			{
				if (!list.Contains(text))
				{
					list.Add(text);
				}
			}
			else if (!list.Contains(text) && Dict[key].NoLoginAvailable)
			{
				list.Add(text);
			}
			list.Sort();
		}
		return list.ToArray();
	}
}
