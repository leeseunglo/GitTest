using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Core.Util.Table.Reader;

namespace Core.Util.Table
{
	#region interface method
	public abstract partial class BaseTable<T, U> : ITableHandler
	{
		protected string FileName = "";
		protected Dictionary<T, U> DicInfo = new Dictionary<T, U>();
		protected Dictionary<string, SetDataFunction> DicLoadProcess = new Dictionary<string, SetDataFunction>();
		protected Dictionary<string, SetColumnFunction> DicSetColumnProcess = new Dictionary<string, SetColumnFunction>();

		public bool IsUpdate { get; private set; } = false;
		public virtual void SetFileName(string _strFileName)
		{
			this.FileName = _strFileName;
		}
		public virtual string GetFileName()
		{
			return FileName;
		}
		public virtual void Init()
		{
			DicInfo.Clear();
		}
		public virtual void Clear() { }
		public bool Load()
		{
			if (false == OnLoadProcess(FileName, OnProcess, OnSetColumnProcess))
				return false;

			foreach (var loadInfo in DicLoadProcess)
			{
				SetColumnFunction setColumnDelegate;
				DicSetColumnProcess.TryGetValue(loadInfo.Key, out setColumnDelegate);
				if (false == Load(loadInfo.Key, loadInfo.Value, setColumnDelegate))
					return false;
			}

			return true;
		}
		public virtual DataTable GetWriteData()
		{
			return null;
		}
		public virtual void Validator() { }
		public virtual bool ResetData(ITableHandler _resetData)
		{
			BaseTable<T, U> baseData = _resetData as BaseTable<T, U>;
			if (null == baseData)
			{
				Log.ErrorLog("ResetData fail FileName:{0}", FileName);
				return false;
			}

			DicInfo = baseData.DicInfo;
			return true;
		}
	}
	#endregion

	public abstract partial class BaseTable<T, U> : ITableHandler
	{
		protected bool OnLoadProcess(string _strFileName, SetDataFunction _loadFunction, SetColumnFunction _setColumnDelegate)
		{
			Reader.Reader reader = CreateReader(_strFileName, _loadFunction, _setColumnDelegate);
			if (null == reader || false == reader.OnParser())
				return false;

			return true;
		}

		protected abstract Reader.Reader CreateReader(string _strFileName, SetDataFunction _loadFunction, SetColumnFunction _setColumnDelegate);

		public void AddLoadFile(string _strFileName, SetDataFunction _funcLoadProcess)
		{
			if (true == DicLoadProcess.ContainsKey(_strFileName))
			{
				Log.ErrorLog("LoadProcess overlap file name fail. FileName:{0}", _strFileName);
				return;
			}

			DicLoadProcess.Add(_strFileName, _funcLoadProcess);
		}

		private bool Load(string _strFileName = "", SetDataFunction _loadFunction = null, SetColumnFunction _setColumnDelegate = null)
		{
			SetFileName(_strFileName);
			if (false == OnLoadProcess(FileName, _loadFunction, _setColumnDelegate))
				return false;

			return true;
		}

		protected virtual void OnSetColumnProcess(string[] _arrColumn) { }
		protected virtual void OnProcess(RowData _rowData) { }
		protected virtual void SetUpdate(bool isUpdate)
		{
			this.IsUpdate = isUpdate;
		}

		public virtual void AddInfo(T _key, U _info)
		{
			if (true == DicInfo.ContainsKey(_key))
			{
				Log.ErrorLog("Template key is duplicated. Key:{0}, FileName:{1}", _key, FileName);
				return;
			}

			DicInfo.Add(_key, _info);
		}

		public virtual bool TryGetValue(T _key, out U _info, bool _isErrorDisplay = true)
		{
			if (false == DicInfo.TryGetValue(_key, out _info))
			{
				if (_isErrorDisplay)
					Log.ErrorLog("Not found template data. Key:{0}, FileName:{1}", _key, FileName);

				return false;
			}

			return true;
		}

		public T[] GetKeys()
		{
			return DicInfo.Keys.ToArray();
		}

		public U[] GetValues()
		{
			return DicInfo.Values.ToArray();
		}

		public Dictionary<T, U> GetDicInfo()
		{
			return DicInfo;
		}

		public bool ContainsKey(T _key)
		{
			return DicInfo.ContainsKey(_key);
		}
	}

	#region read option class
	public abstract partial class BaseTable<T, U>
	{
		protected Dictionary<EReadOptionType, bool> DicOption { get; private set; } = new Dictionary<EReadOptionType, bool>();

		public void SetOption(EReadOptionType _eType, bool _isOption)
		{
			if (false == DicOption.ContainsKey(_eType))
				DicOption.Add(_eType, _isOption);
			else
				DicOption[_eType] = _isOption;
		}
	}
	#endregion
}
