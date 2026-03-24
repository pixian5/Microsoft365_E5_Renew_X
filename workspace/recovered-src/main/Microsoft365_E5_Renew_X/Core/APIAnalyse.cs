using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Microsoft365_E5_Renew_X.Core;

public class APIAnalyse
{
	public class APIAnalyseBase
	{
		private double _CostTime;

		private int _RequestNum;

		private int _FailNum;

		public string Name { get; set; }

		public int RequestNum => _RequestNum;

		public int FailNum => _FailNum;

		public float FailPercent
		{
			get
			{
				if (_RequestNum == 0)
				{
					return 0f;
				}
				return (float)FailNum * 100f / (float)RequestNum;
			}
		}

		public double AverageCostTime => _CostTime / (double)RequestNum;

		public double CostTime => _CostTime;

		public APIAnalyseBase(string APIName)
		{
			_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
			base._002Ector();
			Name = APIName;
			Reset();
		}

		public void AddCostTime(double PerCostTime, bool IsSuccess)
		{
			_RequestNum++;
			_CostTime += PerCostTime;
			if (!IsSuccess)
			{
				_FailNum++;
			}
		}

		public void Reset()
		{
			_CostTime = 0.0;
			_RequestNum = 0;
			_FailNum = 0;
		}

		public static APIAnalyseBase Copy(APIAnalyseBase aPIAnalyseBase)
		{
			APIAnalyseBase aPIAnalyseBase2 = new APIAnalyseBase(aPIAnalyseBase.Name);
			aPIAnalyseBase2._RequestNum = aPIAnalyseBase._RequestNum;
			aPIAnalyseBase2._CostTime = aPIAnalyseBase._CostTime;
			aPIAnalyseBase2._FailNum = aPIAnalyseBase._FailNum;
			return aPIAnalyseBase2;
		}
	}

	public Dictionary<string, APIAnalyseBase> Dict;

	public double CostTime
	{
		get
		{
			double num = 0.0;
			foreach (KeyValuePair<string, APIAnalyseBase> item in Dict)
			{
				num += item.Value.CostTime;
			}
			return num;
		}
	}

	public double RequestNum
	{
		get
		{
			double num = 0.0;
			foreach (KeyValuePair<string, APIAnalyseBase> item in Dict)
			{
				num += (double)item.Value.RequestNum;
			}
			return num;
		}
	}

	public double AverageCostTime
	{
		get
		{
			double num = 0.0;
			double num2 = 0.0;
			foreach (KeyValuePair<string, APIAnalyseBase> item in Dict)
			{
				num += item.Value.CostTime;
				num2 += (double)item.Value.RequestNum;
			}
			return num / num2;
		}
	}

	public APIAnalyse(string[] APIList)
	{
		_0300_0300_0300_000D_000A_0300_0300_0300_0300_0304_030A._0300_0300_0300_000D_000A_0300_0300_0300_0300_0316_0310();
		Dict = new Dictionary<string, APIAnalyseBase>();
		base._002Ector();
		Dict = new Dictionary<string, APIAnalyseBase>();
		foreach (string text in APIList)
		{
			Dict.Add(text, new APIAnalyseBase(text));
		}
	}

	public void AddCostTime(string APIName, double CostTime, bool IsSuccess)
	{
		if (CostTime > 0.0)
		{
			Dict[APIName].AddCostTime(CostTime, IsSuccess);
		}
	}

	public void Reset()
	{
		foreach (KeyValuePair<string, APIAnalyseBase> item in Dict)
		{
			item.Value.Reset();
		}
	}

	public List<APIAnalyseBase> ToList()
	{
		List<APIAnalyseBase> list = new List<APIAnalyseBase>();
		foreach (KeyValuePair<string, APIAnalyseBase> item in Dict)
		{
			list.Add(APIAnalyseBase.Copy(item.Value));
		}
		return list.OrderByDescending((APIAnalyseBase s) => s.AverageCostTime).ToList();
	}
}
