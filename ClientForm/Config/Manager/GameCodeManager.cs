using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Core.Util.Table.Reader;

namespace ClientForm.Config
{
	public class GameCodeInfo : IConfigData
	{
		public static List<string> GetColumnNames = new List<string>() { "Name", "Code" };

		public string Name { get; private set; } = string.Empty;
		public string Code { get; private set; } = string.Empty;

		public GameCodeInfo()
		{

		}

		public GameCodeInfo(string strGameName, string strGameCode)
		{
			Name = strGameName;
			Code = strGameCode;
		}

		public void SetData(RowData _rowData)
		{
			Name = _rowData.GetValue("Name");
			Code = _rowData.GetValue("Code");
		}

		public void InsertRow(DataTable dataTable)
		{
			DataRow dataRow = dataTable.NewRow();

			int index = 0;
			dataRow[index++] = Name;
			dataRow[index++] = Code;
			dataTable.Rows.Add(dataRow);
		}
	}

	public partial class GameCodeManager : AbstractManager<string, GameCodeInfo>
	{
		public GameCodeManager()
		{
			m_liColumnName = GameCodeInfo.GetColumnNames;
		}

		protected override void OnProcess(RowData _rowData)
		{
			GameCodeInfo info = new GameCodeInfo();
			info.SetData(_rowData);
			AddInfo(info);
		}

		public void AddInfo(GameCodeInfo info)
		{
			AddInfo(info.Name, info);
		}
	}
}