using System;
//using System.Threading.Timers;

namespace TomatoClock
{
    public class Clock
    {
        private string workPlan;
        private readonly TimeSpan MIN_TIMESPAN = new TimeSpan(0, 0, 0, 1);       // 1s
        //public Timer timer = new Timer(1000);                           // 创建一个间隔为1s的Timer
        public TimeSpan RemainedTime;                                   // 剩余时间
        public TimeSpan PlanTime { set; get; }

        public Clock(TimeSpan plan)                     // 初始化
        {
            PlanTime = plan;
            RemainedTime = plan;
            //timer.Elapsed += TimeEvent;
        }

        //private void TimeEvent(object sender, ElapsedEventArgs e)       // -1s  到计时
        //{
        //    while (RemainedTime.TotalSeconds <= 0)
        //    {
        //        SucceedFinishClockEvent();
        //        timer.Stop();
        //    }
        //    RemainedTime = RemainedTime.Subtract(MIN_TIMESPAN);
        //}

        public delegate void SucceedFinishClockHandler();
        public event SucceedFinishClockHandler SucceedFinishClockEvent;
    }
}