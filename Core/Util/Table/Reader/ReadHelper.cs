using System.IO;
using Core.Util.Table;
using Core.Util.Table.Reader.Extension;

namespace Core.Util.Table.Reader
{
	public class ReadByType<T, U> : BaseTable<T, U>
	{
		protected override Reader CreateReader(string _strFileName, SetDataFunction _loadFunction, SetColumnFunction _setColumnDelegate)
		{
			switch (ReadOption.INST.GetReaderType(_strFileName))
			{
				case EReaderType.CSV: return new CSVReader(_strFileName, _loadFunction, _setColumnDelegate, DicOption);
				//case EReaderType.XLSX: return new XLSXReader(_strFileName, _loadFunction, _setColumnDelegate, DicOption, 1);
				//case EReaderType.DB: return new DBReader(_strFileName, _loadFunction, _setColumnDelegate, DicOption);
			}

			Log.ErrorLog("Not reader format. FileName:{0}", _strFileName);
			return null;
		}
	}

	public class ReadByExtension<T, U> : BaseTable<T, U>
	{
		protected override Reader CreateReader(string _strFileName, SetDataFunction _loadFunction, SetColumnFunction _setColumnDelegate)
		{
			string strFormat = Path.GetExtension(_strFileName);
			switch (strFormat)
			{
				case ".csv": return new CSVReader(_strFileName, _loadFunction, _setColumnDelegate, DicOption);
				//case ".xlsx": return new XLSXReader(_strFileName, _loadFunction, _setColumnDelegate, DicOption, 1);
			}

			Log.ErrorLog("Not reader format. FileName:{0}", _strFileName);
			return null;
		}
	}

	public class ReadHelper
	{
		public static EReaderType GetReaderType(string _strFileName)
		{
			string strFormat = Path.GetExtension(_strFileName);
			switch (strFormat)
			{
				case ".csv": return EReaderType.CSV;
				case ".xlsx": return EReaderType.XLSX;
				case ".xls": return EReaderType.XLSX;
			}

			Log.ErrorLog("Not extension format. FileName:{0}", _strFileName);
			return EReaderType.DB;
		}

		public static string GetColumnSplitWord(string _strColumn, int _index = 0)
		{
			string[] arrSplit = _strColumn.Split('_');
			if (arrSplit.Length <= _index)
				return "";

			string strWord = arrSplit[_index];
			strWord = strWord.ToLower();
			//strWord = strWord.Trim( ' ' );

			return strWord;
		}
	}
}
