using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Core.Util.Table.Reader;

namespace ClientForm.Config
{
	public class ServerInfo : IConfigData
	{
		public static List<string> GetColumnNames = new List<string>() { "Name", "Address" };

        public string Name { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;

		public ServerInfo() { }

        public ServerInfo(string strName, string strAddress)
        {
            Name	= strName;
            Address	= strAddress;
        }

        public void SetData(RowData _rowData)
        {
            Name	= _rowData.GetValue("Name");
            Address = _rowData.GetValue("Address");
        }

		public void InsertRow(DataTable dataTable)
		{
			DataRow dataRow = dataTable.NewRow();

			int index = 0;
			dataRow[index++] = Name;
			dataRow[index++] = Address;
			dataTable.Rows.Add(dataRow);
		}
	}

	public partial class ServerInfoManager : AbstractManager<string, ServerInfo>
	{
		public ServerInfoManager()
		{
			m_liColumnName = ServerInfo.GetColumnNames;
		}

		protected override void OnProcess(RowData _rowData)
		{
			ServerInfo info = new ServerInfo();
			info.SetData(_rowData);
			AddInfo(info);
		}

		public void AddInfo(ServerInfo info)
		{
			AddInfo(info.Name, info);
		}
	}
}
