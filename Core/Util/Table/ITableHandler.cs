using System.Data;

namespace Core.Util.Table
{
	public interface ITableHandler
	{
		bool IsUpdate { get; }

		void SetFileName(string _strFileName);

		string GetFileName();

		void Init();

		void Clear();

		bool Load();

		DataTable GetWriteData();

		bool ResetData(ITableHandler _resetData);

		void Validator();
	}
}
