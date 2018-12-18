using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TomatoClock
{
    class ClockService
    {
        private Clock clock;
        private bool isClockExist = false;

        public void StartClock(DateTime start, TimeSpan plan)
        {
            clock = new Clock(start, plan);
            clock.FinishClockEvent += FinishedEvent;
            clock.Start();
        }
        
        public void FinishedEvent()
        {
            // 成功停止的操作
        }

        public void StopClock()
        {
            if(!Object.Equals(clock, default(Clock)))
            {
                clock.timer.Stop();
                // 未完成时的操作
            }
        }
    }
}
