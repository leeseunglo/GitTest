using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Util;
using Core.Util.Table;
using Core.Util.Table.Writer;

namespace ClientForm.Config
{
    public partial class ConfigData : TSingleton<ConfigData>
	{
        private const string m_strPath = "Config";

        #region manager instance
        public GameCodeManager GameCodeMgr { get; private set; }
        public ServerInfoManager ServerInfoMgr { get; private set; }
        public LoginUserManager LoginUserMgr { get; private set; }
        #endregion

        private Dictionary<string, ITableHandler> m_dicContainer = new Dictionary<string, ITableHandler>();

        public ConfigData()
        {
            m_dicContainer.Add("game_code", GameCodeMgr = new GameCodeManager());
            m_dicContainer.Add("server_info", ServerInfoMgr = new ServerInfoManager());
            m_dicContainer.Add("login_user_info", LoginUserMgr = new LoginUserManager());
        }

        public string Load()
        {
            try
            {
                Init();

                FileHelper.CreateDirectory(m_dicContainer.First().Value.GetFileName());

                Log.InfoLog("Load template:");
                foreach (var container in m_dicContainer)
                {
                    string fileName = container.Value.GetFileName();
                    if (false == FileHelper.ExistFile(fileName))
                        continue;

                    if (false == container.Value.Load())
                        throw new Exception(string.Format("Load fail. FileName:{0}", container.Value.GetFileName()));
                }

                Validator();
                Clear();
            }
            catch (Exception ex)
            {
                Log.ErrorLog("LoadTableData fail. Msg:{0}", ex.ToString());
                return ex.Message;
            }

            return string.Empty;
        }

        private void Init()
        {
            foreach (var container in m_dicContainer)
            {
                container.Value.SetFileName($"{m_strPath}/{container.Key}.csv");
                container.Value.Init();
            }
        }

        private void Validator()
        {
            foreach (var container in m_dicContainer)
                container.Value.Validator();
        }

        private void Clear()
        {
            foreach (var container in m_dicContainer)
                container.Value.Clear();
        }
    }

    public partial class ConfigData
    {
        public void Save()
        {
            Log.InfoLog("config data save.");
            foreach (var container in m_dicContainer)
            {
                if (false == container.Value.IsUpdate)
                    continue;

                string strFileName = container.Value.GetFileName();
                var writeData = container.Value.GetWriteData();
                if (null == writeData)
                    continue;

                FileHelper.DeleteFile(strFileName);

                CSVWriter writer = new CSVWriter(strFileName, container.Value.GetWriteData());
                writer.CreateFile();
            }
        }
    }
}
