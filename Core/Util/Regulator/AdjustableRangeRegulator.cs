using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Util
{
	public class AdjustableRangeRegulator : IRegulator
	{
		public static Int64 AdjustNowMiliSec = 0;

		protected bool m_bEnabled;
		protected Int64 m_lStartUpMs;
		protected Int64 m_lMinUpdateTickMs;
		protected Int64 m_lMaxUpdateTickMs;
		protected Int64 m_lUpdateTickMs;

		public AdjustableRangeRegulator( Int64 lMinUpdateTickMs , Int64 lMaxUpdateTickMs )
		{
			this.RestartUpdateTickMS( lMinUpdateTickMs , lMaxUpdateTickMs );
		}

		protected Int64 GetNowMilisecond()
		{
			return (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) + AdjustableRegulator.AdjustNowMiliSec;
		}

		protected void ChangeUpdateTick( Int64 lMinUpdateTickMs , Int64 lMaxUpdateTickMs )
		{
			if ( lMaxUpdateTickMs - lMinUpdateTickMs > Int32.MaxValue )
			{
				throw new ArgumentException();
			}

			int term = (Int32)( lMaxUpdateTickMs - lMinUpdateTickMs );

			this.m_lMinUpdateTickMs = lMinUpdateTickMs;
			this.m_lMaxUpdateTickMs = lMaxUpdateTickMs;

			/*
			 * Roya
			 * 여기서 왜 m_lUpdateTickMs에.. 랜덤을 붙일까???
			 */
			Random kRand = new Random();
			this.m_lUpdateTickMs = lMinUpdateTickMs + kRand.Next( 0 , term );
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
			this.ChangeUpdateTick( this.m_lMinUpdateTickMs , this.m_lMaxUpdateTickMs );
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

		public void RestartUpdateTickMS( Int64 lMinUpdateTickMs , Int64 lMaxUpdateTickMs )
		{
			this.ChangeUpdateTick( lMinUpdateTickMs , lMaxUpdateTickMs );
			this.Start();
		}


		public bool IsRunning()
		{
			return this.m_bEnabled;
		}
	}
}
