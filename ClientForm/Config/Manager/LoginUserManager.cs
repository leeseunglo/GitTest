using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using Core;
using ClientForm.Extension;
using Core.Util.Table.Reader;

namespace ClientForm.Config
{
	public class LoginUserInfo : IConfigData
	{
		public static List<string> GetColumnNames = new List<string>() { "ServerName", "GameName", "ServerKey", "LoginID", "Password", "CharacterID", "NickName" };

		public string ServerName { get; set; } = string.Empty;
		public string GameName { get; set; } = string.Empty;
		public string ServerKey { get; set; } = string.Empty;
		public string LoginID { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string CharacterID { get; set; } = string.Empty;
		public string NickName { get; set; } = string.Empty;

		public LoginUserInfo() { }

		public LoginUserInfo(string serverName, string gameName, string serverKey, string loginId, string password, string strCharID, string nickName)
		{
			ServerName	= serverName;
			GameName	= gameName;
			ServerKey	= serverKey;
			LoginID		= loginId;
			Password	= password;
			CharacterID = strCharID;
			NickName	= nickName;
		}

		public void SetData(RowData _rowData)
		{
			ServerName	= _rowData.GetValue("ServerName");
			GameName	= _rowData.GetValue("GameName");
			ServerKey	= _rowData.GetValue("ServerKey");
			LoginID		= _rowData.GetValue("LoginID");
			Password	= _rowData.GetValue("Password");
			CharacterID = _rowData.GetValue("CharacterID");
			NickName	= _rowData.GetValue("NickName");
		}

		public void InsertRow(DataTable dataTable)
		{
			DataRow dataRow = dataTable.NewRow();

			int index = 0;
			dataRow[index++] = ServerName;
			dataRow[index++] = GameName;
			dataRow[index++] = ServerKey;
			dataRow[index++] = LoginID;
			dataRow[index++] = Password;
			dataRow[index++] = CharacterID;
			dataRow[index++] = NickName;
			dataTable.Rows.Add(dataRow);
		}
	}

	public partial class LoginUserManager : AbstractManager<string, LoginUserInfo>
	{
		public LoginUserManager()
		{
			m_liColumnName = LoginUserInfo.GetColumnNames;
		}

		protected override void OnProcess(RowData _rowData)
		{
			LoginUserInfo info = new LoginUserInfo();
			info.SetData(_rowData);
			AddInfo(info);
		}

		public void AddInfo(LoginUserInfo info)
		{
			string strKey = info.GetUserKey();
			if (false == ContainsKey(strKey))
				Log.DebugLog($"Add user info. Data:{info}");
			else
				Log.DebugLog($"Update user info. Data:{info}");

			AddInfo(strKey, info);
		}
	}
}
