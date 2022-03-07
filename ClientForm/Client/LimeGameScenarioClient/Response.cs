using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;
using Core;

namespace ClientForm.Scenario
{
	public partial class LimeGameScenarioClient
	{
		private T GetValidResponseData<T>(Response res) where T : class
		{
			try
			{
				if (false == res is T)
					throw new Exception($"template type fail. {res.GetType().Name}");

				return res as T;
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"GetValidResponseData. exception Msg:{ex.Message}");
				return null;
			}
		}
	}
}
