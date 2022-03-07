using System.Data;
using Core.Util.Table.Reader;

namespace ClientForm.Config
{
	public interface IConfigData
	{
		void SetData(RowData _rowData);

		void InsertRow(DataTable dataTable);
	}
}
