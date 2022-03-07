using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Core.Util.Table.Reader;

namespace ClientForm.Config
{
	public abstract class AbstractManager<Key, Value> : ReadByType<Key, Value> where Value : IConfigData
	{
		protected List<string> m_liColumnName = null;

		#region override method
		public override void AddInfo(Key strKey, Value info)
		{
			if (false == ContainsKey(strKey))
				DicInfo.Add(strKey, info);
			else
				DicInfo[strKey] = info;

			SetUpdate(true);
		}

		public override DataTable GetWriteData()
		{
			DataTable dataTable = new DataTable();
			foreach (var columnName in m_liColumnName)
				dataTable.Columns.Add(columnName);

			var liValue = GetValues();
			foreach (var value in liValue)
				value.InsertRow(dataTable);

			return dataTable;
		}

		public override void Clear()
		{
			// 최초 업데이트 시에 clear가 호출 된다. 고로 set update를 다시 초기화 시킨다.
			SetUpdate(false);
			base.Clear();
		}
		#endregion

		#region virtual method
		public virtual bool Remove(Key strKey)
		{
			bool isRemove = DicInfo.Remove(strKey);
			if (true == isRemove)
				SetUpdate(true);

			return isRemove;
		}

		public virtual Value Get(Key strKey)
		{
			Value info = default;
			if (false == TryGetValue(strKey, out info))
				return default;

			return info;
		}
		#endregion
	}
}
