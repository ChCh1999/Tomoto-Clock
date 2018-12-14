using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClock
{
    class Tomato
    {
        public TimeSpan tomatoTime { get; set; }
        public int signNumber { get; set; }          //标记的数字，用来标明该番茄
        public Tomato(TimeSpan Time, int sN)
        {
            tomatoTime = Time;
            signNumber = sN;
        }
    }
}
