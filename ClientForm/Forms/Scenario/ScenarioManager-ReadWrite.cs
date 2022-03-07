using System;
using System.Data;
using Core;
using Core.Util.Table.Reader;
using Core.Util.Table.Writer;
using Newtonsoft.Json;

namespace ClientForm.Scenario
{
	public class ScenarioReaderManager : ReadByType<int, ScenarioActionInfo>
	{
		public ScenarioReaderManager()
		{
			SetOption(EReadOptionType.FileStaticAddress, false);
		}

		protected override void OnProcess(RowData _rowData)
		{
			ScenarioActionInfo info = new ScenarioActionInfo();
			info.SetData(_rowData);
			AddInfo(info.Num, info);
		}

		public override void Clear()
		{
			DicInfo.Clear();
		}
	}

	public partial class ScenarioManager
	{
		public void OpenFile(string fileName)
		{
			try
			{
				if (m_liScenarioActionInfo.Count > 0)
					Reset();

				var readerMgr = new ScenarioReaderManager();
				readerMgr.SetFileName(fileName);

				if (false == readerMgr.Load())
					throw new Exception("load fail");

				var liScenarioActionInfo = readerMgr.GetValues();
				foreach (var scenarioInfo in liScenarioActionInfo)
				{
					string userKey = scenarioInfo.UserInfo.GetUserKey();

					// 시나리오 관련 데이터 추가.
					if (false == AddScenarioItemData(userKey, scenarioInfo.DetailType, scenarioInfo.ActionData, scenarioInfo.UserInfo.UserInfo))
						continue;

					// 시나리오 추가.
					AddScenarioData(scenarioInfo);
				}

				readerMgr.Clear();
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"ScenarioManager open file fail. Msg:{ex.Message}");
			}
		}

		public void SaveFile(string fileName)
		{
			try
			{
				if (0 > m_liScenarioActionInfo.Count)
					throw new Exception("no scenario fail");

				Log.InfoLog("Save Scenario Info");
				CSVWriter writer = new CSVWriter(fileName, GetWriteData());
				writer.CreateFile();
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"ScenarioManager save file fail. Msg:{ex.Message}");
			}
		}

		private DataTable GetWriteData()
		{
			DataTable dataTable = new DataTable();
			var liColumnName = ScenarioActionInfo.GetColumnNames;
			foreach (var columnName in liColumnName)
				dataTable.Columns.Add(columnName);

			foreach (var info in m_liScenarioActionInfo)
				info.InsertRow(dataTable);

			return dataTable;
		}
	}
}
