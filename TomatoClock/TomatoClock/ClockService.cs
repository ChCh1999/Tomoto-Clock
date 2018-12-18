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
		public History history = new History();
        public WorkPlan currentWP;//当前工作计划
        //TODO history.init();

        //工作计划相关操作
        public WorkPlan chooseWorkPlan(String WPName)
        {
            return history.SearchWorkplan(WPName);
        }//根据名称查询工作
        public void addWorkPlan(String name, int days, List<TimeSpan> tomatoList)
        {
            history.AddWorkplan(name, days, tomatoList);
        }//添加WP
        public void deleteWorkPlan(String Name)
        {
            history.DeleteWorkplan(Name);
        }//删除WP
        public bool ChangeWPName(String nameBefore,String nameNew)
        {
            WorkPlan target= history.SearchWorkplan(nameBefore);
            if (target == null)
                return false;
            History.setName(target, nameNew);
            return true;
        }//修改工作计划名
        public bool ChangeWPDays(String WPName, int days)
        {
            WorkPlan target = history.SearchWorkplan(WPName);
            if (target == null)
                return false;
            History.setDays(target, days);
            return true;
        }//修改工作计划天数
        
        //具体番茄的操作
        public void deleteTomato(WorkPlan wp, int sn,int day)
        {
            history.DeleteTomato(wp, sn,day);
        }
        public void addTomato(WorkPlan wp,TimeSpan ts,int day)
        {
            history.AddTomato(wp, ts, day);
        }
        public List<int> getActiveTomatoSignNum(WorkPlan wp, int day)
        {
            List<int> result = new List<int>();
            result = (from Tomato a in wp.tomatolist where a.DayRecordlist[day] != -1 select a.signNumber).ToList();
            return result;
        }//获取某天某计划所有番茄的代号
        public bool showTomato(WorkPlan wp, int day, int tomatoSignNumber)
        {
            Tomato target = History.getTomato(wp, tomatoSignNumber);
            if (target == null)
            {
                return false;
            }//无结果
            if (target.DayRecordlist[day] == 1)
                return true;
            else
                return false;
        }//获取某番茄某天的状态
		
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
            if(!(Object.Equals(clock,default(Clock))))
            {
                clock.timer.Start();
            }
        }
        
        public void SucceedFinishedEvent()
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
