using System;
using System.ComponentModel;
using System.Threading;

namespace TomatoClock
{
    public class Clock : INotifyPropertyChanged
    {
        //private string workPlan;
        private readonly TimeSpan MIN_TIMESPAN = new TimeSpan(0, 0, 0, 1);       // 1s
        public Timer timer;                           // 创建一个间隔为1s的Timer
        public TimeSpan RemainedTime { get; set; }    // 剩余时间
        public TimeSpan PlanTime { set; get; }

        public Clock(TimeSpan plan)                     // 初始化
        {
            PlanTime = RemainedTime = plan;
        }

        private void TimeEvent(object sender)       // -1s  到计时
        {
            while (RemainedTime.TotalSeconds <= 0)
            {
                SucceedFinishClockEvent();
                timer.Dispose();
            }
            RemainedTime = RemainedTime.Subtract(MIN_TIMESPAN);
        }

        public void Start()
        {
            timer = new Timer(TimeEvent, null, 0, 1000);
        }

        public void Stop()
        {
            timer.Dispose();
        }

        public delegate void SucceedFinishClockHandler();
        public event SucceedFinishClockHandler SucceedFinishClockEvent;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}