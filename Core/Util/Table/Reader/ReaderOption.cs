using System.Collections.Generic;
using System.IO;

namespace Core.Util.Table.Reader
{
	public enum EReaderType
	{
		XLSX,
		CSV,
		DB
	}

	public class ReadOption : TSingleton<ReadOption>
	{
		public string FolderAddress { get; private set; }

		Dictionary<string, EReaderType> m_dicReaderType = new Dictionary<string, EReaderType>();
		Dictionary<string, string> m_dicFileName = new Dictionary<string, string>();

		public void Init()
		{
			m_dicReaderType.Clear();
			m_dicFileName.Clear();
		}

		public void SetFolderAddress(string _strAddrss)
		{
			FolderAddress = _strAddrss;
		}

		public void AddReaderType(string _strFileName, EReaderType _eType)
		{
			if (m_dicReaderType.ContainsKey(_strFileName))
			{
				Log.ErrorLog("Reader type overlap. FileName:{0}", _strFileName);
				return;
			}

			m_dicReaderType.Add(_strFileName, _eType);
		}

		public void AddFileName(string _strFileName, string _strFileAdress)
		{
			if (m_dicFileName.ContainsKey(_strFileName))
			{
				Log.ErrorLog("Reader file adress overlap. FileName:{0}", _strFileName);
				return;
			}

			m_dicFileName.Add(_strFileName, _strFileAdress);
		}

		public void AddReaderType(List<string> _liFileName, EReaderType _eType)
		{
			for (int i = 0; i < _liFileName.Count; ++i)
			{
				AddReaderType(_liFileName[i], _eType);
			}
		}

		public EReaderType GetReaderType(string _strFileName)
		{
			if (false == m_dicReaderType.ContainsKey(_strFileName))
				return EReaderType.CSV;

			return m_dicReaderType[_strFileName];
		}

		public string GetFileName(string _strFileName)
		{
			if (false == m_dicFileName.ContainsKey(_strFileName))
				return string.Empty;

			return m_dicFileName[_strFileName];
		}

		public void AddFolder(string _folderPath)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(_folderPath);
			foreach (var file in dirInfo.GetFiles())
			{
				AddFileName(Path.GetFileNameWithoutExtension(file.Name), file.FullName);
				AddReaderType(Path.GetFileNameWithoutExtension(file.Name), ReadHelper.GetReaderType(file.Name));
			}
		}
	}
}
