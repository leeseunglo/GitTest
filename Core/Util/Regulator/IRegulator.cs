using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Util
{
	public interface IRegulator
	{
		void Start();
		void Stop();
		void Reset();
		void Restart();
		bool IsUpdate();
		bool IsRunning();
	}
}
