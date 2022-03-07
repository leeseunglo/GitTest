using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Core.Util
{
	public class Regulator : IRegulator
	{
		private Int64		m_UpdateTickMS;
		private Stopwatch	m_kTimeTick = new Stopwatch();

		public Regulator( Int64 _UpdateTickMS )
		{
			m_UpdateTickMS = _UpdateTickMS;
			m_kTimeTick.Start();
		}

		public void RestartUpdateTickMS( Int64 _UpdateTickMS )
		{
			m_UpdateTickMS = _UpdateTickMS;
			m_kTimeTick.Restart();
		}

		public void Start()
		{
			m_kTimeTick.Start();
		}

		public void Stop()
		{
			m_kTimeTick.Stop();
		}

		public void Reset()
		{
			m_kTimeTick.Reset();
		}

		public void Restart()
		{
			m_kTimeTick.Restart();
		}

		public bool IsUpdate()
		{
			if( false == IsRunning() )
				return false;

			if( GetElapsedMSTick() < m_UpdateTickMS )
				return false;

			Restart();
			return true;
		}

		private Double GetElapsedMSTick()
		{
			return m_kTimeTick.Elapsed.TotalMilliseconds;
		}
		public bool IsRunning()
		{
			return this.m_kTimeTick.IsRunning;
		}
	}
}
