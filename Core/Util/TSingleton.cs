using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util
{
	public class TSingleton<T> where T : class, new()
	{
		private static T _inst = new T();
		public static T INST
		{
			get
			{
				if (_inst == null)
				{
					_inst = new T();
				}
				return _inst;
			}
		}
	}
}
