using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TomatoClock
{
    public class ClockService
    {
        //工作计划相关操作
        public HistoryService history = new HistoryService();
        public WorkPlan currentWP;//当前工作计划
        public List<WorkPlan> getAllWorkPlan() {
            return history.GetAllWorkPlan();
        }
        //获取天数
        public int GetDays(WorkPlan wp)
        {
            return history.getdays(wp);
        }
        //根据名称查询工作
        public WorkPlan chooseWorkPlan(String WPName)
        {
            return history.GetWorkPlan(WPName);
        }

        // 添加WP
        public void addWorkPlan(String name, int days, List<TomatoList> tomatoList)
        {
            WorkPlan workPlan = new WorkPlan(name, (short)days,tomatoList);
            history.Add(workPlan);
        }
        
        // 删除WP
        public void deleteWorkPlan(String Name)
        {
            history.Delete(Name);
        }
        public List<int>GetTodayTimes(string name)
        {
            return history.getTodayTimes(name);
        }
        
        //修改工作计划名
        public bool ChangeWPName(String nameBefore, String nameNew)
        {
            WorkPlan target = history.GetWorkPlan(nameBefore);
            if (target == null)
                return false;
            target.workName = nameNew;
            history.Update(target);
            return true;
        }

        
        //修改工作计划天数
        public bool ChangeWPDays(String WPName, int days)
        {
            WorkPlan target = history.GetWorkPlan(WPName);
            if (target == null)
                return false;
            target.NumofDay = (short)days;
            history.Update(target);
            return true;
        }

        //具体番茄的操作
        public void deleteTomato(string wp, int sn, int day)
        {
            history.DeleteTomato(wp, sn);
        }

        public void addTomato(WorkPlan wp, int seconds)
        {
            history.addTomato(wp.workName,seconds);
        }

        //获取某天某计划所有番茄的代号
        public List<int> getFinishedTomatoSignNum(WorkPlan wp, int day)
        {
            return history.getFinishedTomatoSignNum(wp,day);
        }
        public List<int> getActiveTomatoSignNum(WorkPlan wp, int day)
        {
            return history.getActiveTomatoSignNum(wp, day);
        }

        //获取某番茄某天的状态
        public bool GetTomatoCon(WorkPlan wp, int day, int sn)
        {
            return history.getTomatoCon(wp.workName, day, sn);
        }

        //时钟相关操作
        private Clock clock;

        public void initClock()
        {
            clock = new Clock(new TimeSpan(0, 0, 15, 0));           // 初始化一个15分钟的定时器
            clock.SucceedFinishClockEvent += SucceedFinishedEvent;  // 添加在成功完成定时器的任务
        }

        public void ChangeClockTime(TimeSpan plan)
        {
            clock.PlanTime = plan;
        }

        public void StartClock()
        {
            if (!(Object.Equals(clock, default(Clock))))
            {
                clock.Start();
            }
        }

        public void SucceedFinishedEvent()
        {
            //成功停止的操作
        }

        public void StopClock()
        {
            if (!Object.Equals(clock, default(Clock)))
            {
                //未完成时的操作
                clock.Stop();
            }
        }
    }
}
