using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClock
{
    class Tomato
    {
        public List<int> DayRecordlist = new List<int>();    //记录在预期天数里每天这个番茄属性状态情况
        public TimeSpan tomatoTime { get; set; }
        public int signNumber { get; set; }          //标记的数字，用来标明该番茄
        public Tomato(TimeSpan Time, int sN)
        {
            tomatoTime = Time;
            signNumber = sN;
        }
    }
}
