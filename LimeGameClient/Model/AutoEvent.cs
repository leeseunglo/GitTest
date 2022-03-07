using System;
using Core.Util;
using System.Threading;

namespace ClientProtocol.Model
{
	public class AutoEvent
	{
		private Func<bool> m_playFunc = null;
		private Thread m_thread = null;
		private Regulator m_updateTime = null;
		private int m_playCount = 0;
		private bool m_bThreadDoWorkRun = false;

		public AutoEvent(long updateTickMS, Func<bool> playFunc)
		{
			m_updateTime = new Regulator(updateTickMS);
			m_thread = new Thread(new ThreadStart(this.Run));
			m_thread.IsBackground = true;

			m_playFunc = playFunc;
		}

		public void Start()
		{
			if (true == m_bThreadDoWorkRun)
				return;

			m_bThreadDoWorkRun = true;
			m_thread.Start();
		}

		public void Stop()
		{
			if (false == m_bThreadDoWorkRun)
				return;


			m_bThreadDoWorkRun = false;
			m_thread.Join();
		}

		public int GetPlayCount()
		{
			return m_playCount;
		}

		private void Run()
		{
			while (true)
			{
				if (false == m_bThreadDoWorkRun)
					return;

				if (false == m_updateTime.IsUpdate())
					continue;

				if (false == m_playFunc?.Invoke())
					break;

				++m_playCount;
			}
		}
	}
}
