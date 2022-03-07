using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;

namespace Core.Util.Table.Writer
{
	public class CSVWriter
	{
		private string m_fileName = "";
		private DataTable m_writerData = null;

		public CSVWriter(string strFileName, DataTable _dataTable)
		{
			if (null == Path.GetExtension(strFileName))
				m_fileName = strFileName + ".csv";
			else
				m_fileName = strFileName;

			m_writerData = _dataTable;
		}

		public void CreateFile()
		{
			if (m_writerData.Rows.Count < 1)
				return;

			FileStream fileStream = new FileStream(m_fileName, FileMode.Create);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);

			int iColCount = m_writerData.Columns.Count;
			for (int i = 0; i < iColCount; ++i)
			{
				streamWriter.Write(m_writerData.Columns[i]);
				if (i < iColCount - 1)
				{
					streamWriter.Write(";");
				}
			}
			streamWriter.Write(streamWriter.NewLine);

			foreach (DataRow dr in m_writerData.Rows)
			{
				for (int i = 0; i < iColCount; ++i)
				{
					if (!Convert.IsDBNull(dr[i]))
					{
						streamWriter.Write(dr[i].ToString());
					}
					if (i < iColCount - 1)
					{
						streamWriter.Write(";");
					}
				}

				streamWriter.Write(streamWriter.NewLine);
			}

			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
		}
	}
}
