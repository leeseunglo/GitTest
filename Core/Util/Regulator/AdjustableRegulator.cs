using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Util
{
	public class AdjustableRegulator : IRegulator
	{
		public static Int64 AdjustNowMiliSec = 0;

		protected bool m_bEnabled;
		protected Int64 m_lStartUpMs;
		protected Int64 m_lUpdateTickMs;

		public AdjustableRegulator( Int64 lUpdateTickMs )
		{
			this.RestartUpdateTickMS( lUpdateTickMs );
		}

		protected Int64 GetNowMilisecond()
		{
			return (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) + AdjustableRegulator.AdjustNowMiliSec;
		}

		protected void ChangeUpdateTick( Int64 lUpdateTickMs )
		{
			this.m_lUpdateTickMs = lUpdateTickMs;
		}

		protected Int64 GetElapsedTime()
		{
			if ( false == this.m_bEnabled )
			{
				return 0;
			}
			return this.GetNowMilisecond() - this.m_lStartUpMs;
		}

		public void Start()
		{
			this.m_lStartUpMs = this.GetNowMilisecond();
			this.m_bEnabled = true;
		}

		public void Stop()
		{
			this.m_bEnabled = false;
		}

		public void Reset()
		{
			this.m_bEnabled = false;
			this.m_lStartUpMs = this.GetNowMilisecond();
		}

		public void Restart()
		{
			this.Start();
		}

		public bool IsUpdate()
		{
			if ( false == this.m_bEnabled )
			{
				return false;
			}

			if ( this.GetElapsedTime() < this.m_lUpdateTickMs )
			{
				return false;
			}

			this.Start();
			return true;
		}

		public void RestartUpdateTickMS( Int64 lUpdateTickMs )
		{
			this.ChangeUpdateTick( lUpdateTickMs );
			this.Start();
		}

		public bool IsRunning()
		{
			return this.m_bEnabled;
		}
	}
}
