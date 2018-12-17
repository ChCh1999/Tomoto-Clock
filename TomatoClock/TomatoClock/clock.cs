using System;
using System.Timers;

namespace TomatoClock
{
    public class Clock
    {
        //private string workPlan;
        public DateTime StartTime { set; get; }
        public TimeSpan PlanTime { set; get; }
        private TimeSpan MIN_TIMESPAN = new TimeSpan(0, 0, 0, 1);       // +1s
        private Timer timer = new Timer(1000);                          // 创建一个间隔为1s的Timer
        public TimeSpan RemainedTime;                                   // 剩余时间
        private bool result = false;                                    // 判断是否完成

        public Clock(DateTime start, TimeSpan plan,Clock clock) // 初始化
        {
            StartTime = start;
            PlanTime = plan;
            RemainedTime = plan;                              
            timer.Elapsed += TimeEvent;
            timer.Start();
        }

        private void TimeEvent(object sender, ElapsedEventArgs e)            // -1s  到计时
        {
            while (RemainedTime.TotalSeconds == 0)
            {
                timer.Stop();
                result = true;
            }
            RemainedTime = RemainedTime.Subtract(MIN_TIMESPAN);
        }

        public TimeSpan Stop()              // 返回剩余时间
        {
            //强制停止
            if (DateTime.Now - StartTime < PlanTime)
            {
                result = false;
            }
            //到时间结束
            else if (DateTime.Now - StartTime == PlanTime)
            {
                result = true;
            }
            return ReturnTime();
        }

        public TimeSpan ReturnTime()      // 剩余时间
        {
            return PlanTime - (DateTime.Now - StartTime);
        }


    }
}