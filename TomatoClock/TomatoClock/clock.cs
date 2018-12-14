using System;

namespace TomatoClock
{
    public class Clock
    {
        //private string workPlan;
        public DateTime StartTime { set; get; }
        public TimeSpan PlanTime { set; get; }
        private bool result = true;
        private string situation = "";

        public Clock(DateTime start, TimeSpan plan)
        {
            StartTime = start;
            PlanTime = plan;
        }

        private TimeSpan Stop()              // 停止番茄钟
        {
            //强制停止
            if (DateTime.Now - StartTime < PlanTime)
            {
                result = false;
                RemindMethod();
            }
            //到时间结束
            else if (DateTime.Now - StartTime == PlanTime)
            {
                result = true;
                RemindMethod();
            }
            return RemainedTime();
        }

        private string Situation()    //番茄钟简易提醒
        {
            if (result == true)
                situation = "任务已完成！";
            else
                situation = "任务未完成！";
            return situation;
        }

        private void RemindMethod()   //番茄钟正式提醒
        {

        }

        private TimeSpan RemainedTime()      // 返回剩余时间
        {
            return PlanTime - (DateTime.Now - StartTime);
        }
    }
}