using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Core.Util.Table.Reader
{
	public delegate void SetColumnFunction(string[] _arrColumn);
	public delegate void SetDataFunction(RowData _rowData);
	public delegate void OnSetRepeatDataFunc(int _index);

	public enum EReadOptionType
	{
		ExcludeText,
		FileStaticAddress,
	}

	public class RowData
	{
		string strFileName = "";
		public Dictionary<string, string> DicData { get; private set; } = new Dictionary<string, string>();

		public RowData(string _strFileName)
		{
			strFileName = _strFileName;
		}

		public void SetRepeatData(string _strExistCloumnName, OnSetRepeatDataFunc _setFunc)
		{
			string strCloumnName = "";
			bool isNonRepeatData = true;
			for (int i = 1; ; ++i)
			{
				strCloumnName = _strExistCloumnName + i;
				if (false == IsContainsKey(strCloumnName))
					break;

				isNonRepeatData = false;
				_setFunc(i);
			}

			if (true == isNonRepeatData)
				Log.ErrorLog("Non repeat data. CloumnName:{0}", _strExistCloumnName);
		}

		public int GetCloumnCount(string _strFormat, int _firstIndex = 1)
		{
			string strCloumnName = "";
			for (int i = _firstIndex; ; ++i)
			{
				strCloumnName = string.Format(_strFormat, i);
				if (false == IsContainsKey(strCloumnName))
					return i - _firstIndex;
			}
		}

		public string GetFirstKey()
		{
			return DicData.First().Key;
		}

		public bool IsContainsKey(string _strKey)
		{
			return DicData.ContainsKey(_strKey);
		}

		public bool SetKey(string _strKey)
		{
			if (true == string.IsNullOrEmpty(_strKey))
				return false;

			DicData.Add(_strKey, "");
			return true;
		}

		public void SetValue(string _strKey, string _strValue)
		{
			if (true == DicData.ContainsKey(_strKey))
				DicData[_strKey] = _strValue;
		}

		public string GetValue(string _strKey)
		{
			if (false == DicData.ContainsKey(_strKey))
			{
				Log.ErrorLog(string.Format("Not found column. Key:{0}, FileName:{1}", _strKey, strFileName));
				return "";
			}

			return DicData[_strKey];
		}

		public string[] GetKeys()
		{
			return DicData.Keys.ToArray();
		}

		#region [GetValue Function]
		public bool GetValueToBool(string _strKey)
		{
			return 1 == GetValueToByte(_strKey) ? true : false;
		}
		public short GetValueToInt16(string _strKey)
		{
			short retValue = 0;
			if (false == short.TryParse(GetValue(_strKey), out retValue))
			{
				Log.ErrorLog(string.Format("Convert to short fail. Key:{0}, Value:{1}", _strKey, GetValue(_strKey)));
				return 0;
			}

			return retValue;
		}
		public int GetValueToInt32(string _strKey)
		{
			int retValue = 0;
			if (false == int.TryParse(GetValue(_strKey), out retValue))
			{
				Log.ErrorLog(string.Format("Convert to int fail. Key:{0}, Value:{1}", _strKey, GetValue(_strKey)));
				return 0;
			}

			return retValue;
		}
		public long GetValueToInt64(string _strKey)
		{
			long retValue = 0;
			if (false == long.TryParse(GetValue(_strKey), out retValue))
			{
				Log.ErrorLog(string.Format("Convert to long fail. Key:{0}, Value:{1}", _strKey, GetValue(_strKey)));
				return 0;
			}

			return retValue;
		}
		public float GetValueToSingle(string _strKey)
		{
			float retValue = 0;
			if (false == float.TryParse(GetValue(_strKey), out retValue))
			{
				Log.ErrorLog(string.Format("Convert to float fail. Key:{0}, Value:{1}", _strKey, GetValue(_strKey)));
				return 0;
			}

			return retValue;
		}
		public double GetValueToDouble(string _strKey)
		{
			double retValue = 0;
			if (false == double.TryParse(GetValue(_strKey), out retValue))
			{
				Log.ErrorLog(string.Format("Convert to double fail. Key:{0}, Value:{1}", _strKey, GetValue(_strKey)));
				return 0;
			}

			return retValue;
		}
		public byte GetValueToByte(string _strKey)
		{
			byte retValue = 0;
			if (false == byte.TryParse(GetValue(_strKey), out retValue))
			{
				Log.ErrorLog(string.Format("Convert to byte fail. Key:{0}, Value:{1}", _strKey, GetValue(_strKey)));
				return 0;
			}

			return retValue;
		}
		public sbyte GetValueToSByte(string _strKey)
		{
			sbyte retValue = 0;
			if (false == sbyte.TryParse(GetValue(_strKey), out retValue))
			{
				Log.ErrorLog(string.Format("Convert to sbyte fail. Key:{0}, Value:{1}", _strKey, GetValue(_strKey)));
				return 0;
			}

			return retValue;
		}
		public T GetValueToEnum<T>(string _strKey)
		{
			return (T)Enum.Parse(typeof(T), _strKey);
		}
		#endregion [GetValue Function]
	}

	public class Reader
	{
		string m_strFileName = "";
		SetDataFunction m_setDataDelegate = null;
		SetColumnFunction m_setColumnDelegate = null;

		RowData m_rowData = null;
		Dictionary<EReadOptionType, bool> m_dicOption = null;

		protected string FileName { get { return m_strFileName; } }

		public Reader(string _strFileName, SetDataFunction _setDataDelegate, SetColumnFunction _setColumnDelegate, Dictionary<EReadOptionType, bool> _dicOption)
		{
			m_dicOption = _dicOption;
			m_strFileName = _strFileName;
			m_setDataDelegate = _setDataDelegate;
			m_setColumnDelegate = _setColumnDelegate;

			m_rowData = new RowData(_strFileName);
		}

		public string GetFileAddress(string _strExtension = "")
		{
			string strFileName = ReadOption.INST.GetFileName(m_strFileName);
			if (false == string.IsNullOrEmpty(strFileName))
				return strFileName;

			if (GetOption(EReadOptionType.FileStaticAddress))
				return ReadOption.INST.FolderAddress + m_strFileName + _strExtension;
			else
				return m_strFileName;
		}

		public virtual bool OnParser()
		{
			return false;
		}

		public void ErrorMessage(string _strMsg)
		{
			Log.ErrorLog(string.Format("Reader error File:{0}, Message:{1}", m_strFileName, _strMsg));
		}

		protected bool SetRowKeyDataList(string[] _arrObject)
		{
			for (int i = 0; i < _arrObject.Length; ++i)
			{
				if (false == SetKey(_arrObject[i], i))
					return false;
			}

			if (null != m_setColumnDelegate)
				m_setColumnDelegate(m_rowData.GetKeys());

			return true;
		}

		protected bool SetRowKeyDataList(object[] _arrObject)
		{
			for (int i = 0; i < _arrObject.Length; ++i)
			{
				if (false == SetKey(_arrObject[i].ToString(), i))
					return false;
			}

			if (null != m_setColumnDelegate)
				m_setColumnDelegate(m_rowData.GetKeys());

			return true;
		}

		protected bool SetRowKeyDataList(DataColumnCollection _dataColumn)
		{
			for (int i = 0; i < _dataColumn.Count; ++i)
			{
				if (false == SetKey(_dataColumn[i].ToString(), i))
					return false;
			}

			if (null != m_setColumnDelegate)
				m_setColumnDelegate(m_rowData.GetKeys());

			return true;
		}

		protected bool SetRowValueData(string _strColumnName, string _strColumnValue)
		{
			if (true == string.IsNullOrEmpty(_strColumnValue))
				return false;

			m_rowData.SetValue(_strColumnName, _strColumnValue);
			return true;
		}

		protected void ProcessCallbackFunction()
		{
			m_setDataDelegate(m_rowData);
		}

		private bool SetKey(string _strColumnName, int _columnIndex)
		{
			string strKey = "";
			try
			{
				if (true == RenameColumnKey(_strColumnName, _columnIndex, out strKey))
					return true;
			}
			catch (Exception e)
			{
				ErrorMessage(string.Format("Reader set key fail. Name:{0}, Index:{1}, Message:{2}", m_strFileName, _columnIndex, e.Message));
				return false;
			}

			m_rowData.SetKey(strKey);
			return true;
		}

		private bool RenameColumnKey(string _strColumn, int _columnIndex, out string _strKey)
		{
			_strKey = _strColumn;
			string strDataType = ReadHelper.GetColumnSplitWord(_strColumn);
			switch (strDataType)
			{
				case "int":
				case "short":
				case "double":
				case "float":
				case "bool":
				case "char":
				case "byte":
				case "sbyte":
					{
						return false;
					}

				case "ref":
					{
						_strKey = _strColumn + "_" + _columnIndex;
						break;
					}

				case "text":
					{
						if (false == GetOption(EReadOptionType.ExcludeText))
							return false;

						_strKey = _strColumn + "_" + _columnIndex;
						break;
					}

				default:
					{
						return false;
					}
			}

			return true;
		}

		private bool GetOption(EReadOptionType _eType)
		{
			if (false == m_dicOption.ContainsKey(_eType))
				return true;

			return m_dicOption[_eType];
		}
	}
}
