using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Newtonsoft.Json;
using ClientProtocol.Model;
using ClientProtocol.Protocol;
using ClientForm.Common;
using ClientForm.Extension;

namespace ClientForm.Client
{
	public partial class LimeGameClient : IChatClient
	{
		private List<string> m_liIgnoreResponse = new List<string>();
		private void SetIgnoreResponse()
		{
			m_liIgnoreResponse.Add("SendMessageResponse");
			m_liIgnoreResponse.Add("SendWhisperResponse");
			m_liIgnoreResponse.Add("GameReportResponse");
			m_liIgnoreResponse.Add("CreateOneOnOneRoomWithUserResponse");
		}

		protected bool ignoreResponse(string responseName)
		{
			return m_liIgnoreResponse.Contains(responseName);
		}

		private string GetMessageTitle(ServerNotiMessageResponse resData)
		{
			// 귓속말
			if (eMessageSubType.WHISPER.ToString() == resData.subType)
				return "Whisper";

			string roomName = m_limeGameRoomKey.GetGameRoomName(resData.gameRoomKeyInfo);
			// 1:1 채팅 방
			if (eGameRoomType.ONE_ON_ONE.ToString() == resData.gameRoomKeyInfo.type)
			{
				if (string.Empty == roomName && resData.playNcCharId != UserInfo.CharacterID)
					AddGameRoom(GetGameRoomName(resData.gameRoomKeyInfo), resData.gameRoomKeyInfo);

				return "1:1";
			}

			// 그룹 채팅 방
			return roomName;
		}

		protected void ResponseLog(object response)
		{
			Log.DebugLog($"Response >> {UserInfo.NickName}, {response.GetType().Name}, {JsonConvert.SerializeObject(response)}");
		}

		private T GetValidResponseData<T>(Response res) where T : class
		{
			try
			{
				if (false == res is T)
					throw new Exception($"template type fail. {res.GetType().Name}");

				return res as T;
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"GetValidResponseData. exception Msg:{ex.Message}");
				return null;
			}
		}

		public void OnLoginWithTokenResponse(Response res)
		{
			var resData = GetValidResponseData<LoginWithTokenResponse>(res);
			if (null == resData)
				return;

			ResponseLog(resData);
			if (null != resData.gameRoomInfoList)
                resData.gameRoomInfoList.ForEach(x => m_limeGameRoomKey.Add(x.name, x.gameRoomKeyInfo));
		}

		public void OnLogoutWithTokenResponse(Response res)
		{
			var resData = GetValidResponseData<LogoutWithTokenResponse>(res);
			if (null == resData)
				return;

			m_clientProxy.Dispose();
			m_actionLogout?.Invoke(GetUserKey());
        }

		#region [ChatGroupResponseMethod]
		public void OnCreateRoomResponse(Response res)
		{
			var resData = GetValidResponseData<CreateRoomResponse>(res);
			if (null == resData)
				return;

			AddGameRoom(resData.gameRoomInfo.name, resData.gameRoomInfo.gameRoomKeyInfo);
		}

		public void OnJoinRoomResponse(Response res)
		{
			var resData = GetValidResponseData<JoinRoomResponse>(res);
			if (null == resData)
				return;

			AddGameRoom(resData.gameRoomInfo.name, resData.gameRoomInfo.gameRoomKeyInfo);
		}

		public void OnLeaveRoomResponse(Response res)
		{
			var resData = GetValidResponseData<LeaveRoomResponse>(res);
			if (null == resData)
				return;

			LeaveGameRoom(resData.gameRoomInfo.name);
		}

		public void OnGetJoinedRoomListResponse(Response res)
		{
			var resData = GetValidResponseData<GetJoinedRoomListResponse>(res);
			if (null == resData)
				return;

			if (null != resData.gameRoomInfoList)
				resData.gameRoomInfoList.ForEach(x => AddGameRoom(x.name, x.gameRoomKeyInfo));
		}
		#endregion [ChatGroupResponseMethod]

		public void OnCreateOneOnOneRoomWithUserResponse(Response res)
		{
			var resData = GetValidResponseData<CreateOneOnOneRoomWithUserResponse>(res);
			if (null == resData)
				return;

			AddGameRoom(resData.gameRoomInfo.name, resData.gameRoomInfo.gameRoomKeyInfo);
		}

		public void OnServerNotiMessageResponse(Response res)
		{
			try
			{
				var resData = GetValidResponseData<ServerNotiMessageResponse>(res);
				if (null == resData)
					throw new Exception("response format fail");

				var roomKeyInfo = resData.gameRoomKeyInfo;
				if (null == roomKeyInfo)
					throw new Exception("game room key info null");

				string roomName = GetMessageTitle(resData);
				if (string.Empty == roomName)
					throw new Exception($"game room name empty. GameRoomKeyInfo:{roomKeyInfo.GetInfo()}");

				DisplayMessage(roomName, new MessageInfo(roomKeyInfo, resData.guid, resData.userName, resData.content));
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"OnServerNotiMessageResponse. exception Msg:{ex.Message}");
			}
		}
	}
}
