using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Core.Util
{
    public class AtomicInt
    {
        private int _value = 0;
        public int Value { get { return _value; } set { Interlocked.Exchange(ref _value, value); } }

        /// 생성자(초기값 0)
        public AtomicInt()
        {
            _value = 0;
        }

        public AtomicInt(int initValue)
        {
            _value = initValue;
        }

        /// CAS on
        public bool CasOn()
        {
#if DEBUG
            Console.WriteLine("CasOn!!!");
#endif

            return Interlocked.CompareExchange(ref _value, 1, 0) == 0;
        }

        /// CAS off
        public bool CasOff()
        {
#if DEBUG
            Console.WriteLine("CasOFF!!!");
#endif
            return Interlocked.CompareExchange(ref _value, 0, 1) == 1;
        }

        public void On()
        {
            Interlocked.Exchange(ref _value, 1);
        }

        public void Off()
        {
            Interlocked.Exchange(ref _value, 0);
        }

        public bool IsOn()
        {
            return _value == 1;
        }

        public bool Test(int value)
        {
            return _value == value;
        }
    }
}
