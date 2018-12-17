using System;
using System.Timers;

namespace TomatoClock
{
    public class Clock
    {
        //private string workPlan;
        private TimeSpan MIN_TIMESPAN = new TimeSpan(0, 0, 0, 1);       // 1s
        private Timer timer = new Timer(1000);                          // 创建一个间隔为1s的Timer
        public TimeSpan RemainedTime;                                   // 剩余时间
        public DateTime StartTime { set; get; }
        public TimeSpan PlanTime { set; get; }
        public bool isFinished = false;                                // 判断是否完成

        public Clock(DateTime start, TimeSpan plan)                     // 初始化
        {
            StartTime = start;
            PlanTime = plan;
            RemainedTime = plan;
            timer.Elapsed += TimeEvent;
        }

        public void Start()
        {
            timer.Start();
        }

        private void TimeEvent(object sender, ElapsedEventArgs e)       // -1s  到计时
        {
            while (RemainedTime.TotalSeconds == 0)
            {
                isFinished = true;
                timer.Stop();
            }
            RemainedTime = RemainedTime.Subtract(MIN_TIMESPAN);
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}