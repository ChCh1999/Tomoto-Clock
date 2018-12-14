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
        private TimeSpan MIN_TIMESPAN = new TimeSpan(0, 0, 0, 1);       // +1s
        private Timer timer = new Timer(1000);                          // 创建一个间隔为1s的Timer
        public TimeSpan RemainedTime;                                   // 剩余时间

        public ClockService(Clock clock)
        {
            RemainedTime = clock.PlanTime;                              // 初始化剩余时间
            timer.Elapsed += TimeEvent;
            timer.Start();
        }

        private void TimeEvent(object sender, ElapsedEventArgs e)            // -1s
        {
            while (RemainedTime.TotalSeconds == 0)
                timer.Stop();
            RemainedTime = RemainedTime.Subtract(MIN_TIMESPAN);
        }

        public void Pause()
        {
            timer.Enabled = false;
        }

        public void Resume()
        {
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Stop();
            // 停止后的操作
        }
    }
}
