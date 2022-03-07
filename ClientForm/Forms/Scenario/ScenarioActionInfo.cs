using System;
using System.Collections.Generic;
using System.Data;
using ClientProtocol.Protocol;
using Core.Util.Table.Reader;
using Newtonsoft.Json;
using ClientForm.Extension;

namespace ClientForm.Scenario
{
	public partial class ScenarioActionInfo
	{
		public int Num { get; private set; }
		public LimeGameScenarioClient UserInfo { get; private set; }
		public eScenarioDetailType DetailType { get; private set; }
		public Request ActionData { get; private set; }
		public bool Send { get; private set; }
		public bool Recv { get; private set; }

		public ScenarioActionInfo() { }

		public ScenarioActionInfo(int num, LimeGameScenarioClient userInfo, eScenarioDetailType detailType, Request actionData, bool sendPass = false)
		{
			Num = num;
			UserInfo = userInfo;
			DetailType = detailType;
			ActionData = actionData;
			Send = sendPass;
			Recv = false;
		}

		public void SendCheck()
		{
			Send = true;
		}

		public void RecvCheck()
		{
			Recv = true;
		}
	}

	public partial class ScenarioActionInfo
	{
		public static List<string> GetColumnNames = new List<string>() { "Num", "UserInfo", "DetailType", "ActionData" };

		public void SetData(RowData _rowData)
		{
			Num			= _rowData.GetValueToInt32("Num");
			UserInfo	= JsonConvert.DeserializeObject<LimeGameScenarioClient>(_rowData.GetValue("UserInfo"));
			DetailType	= _rowData.GetValueToEnum<eScenarioDetailType>(_rowData.GetValue("DetailType"));
			ActionData	= ConvertExtension.MakeRequestByScenarioDetailType(DetailType, _rowData.GetValue("ActionData"));
			Send		= false;
			Recv		= false;
		}

		public void SetSendFlag(bool isSend)
		{
			Send = isSend;
		}

		public void InsertRow(DataTable dataTable)
		{
			DataRow dataRow = dataTable.NewRow();

			int index = 0;
			dataRow[index++] = Num.ToString();
			dataRow[index++] = JsonConvert.SerializeObject(UserInfo);
			dataRow[index++] = DetailType.ToString();
			dataRow[index++] = JsonConvert.SerializeObject(ActionData);
			dataTable.Rows.Add(dataRow);
		}
	}
}
