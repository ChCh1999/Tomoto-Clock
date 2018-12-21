using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TomatoClock
{
    class History
    {

        //WorkPlan[] plans = new WorkPlan[31];
        public List<WorkPlan> plans = new List<WorkPlan>();
        public static int getDays(WorkPlan w)
        {
            return w.dayTime;
        }

        public static void setDays(WorkPlan w, int days)
        {
            w.dayTime = days;
        }

        public static string getName(WorkPlan w)
        {
            return w.workName;
        }

        public static void setName(WorkPlan w, string name)
        {
            w.workName = name;
        }

        public static List<Tomato> getTomatoList(WorkPlan w)
        {
            return w.tomatolist;
        }
        public static Tomato getTomato(WorkPlan wp,int sn)
        {
            foreach(Tomato t in wp.tomatolist)
            {
                if (t.signNumber == sn)
                    return t;
            }
            return null;
        }
        public void AddTomato(WorkPlan w,TimeSpan ts,int day)
        {
            Tomato addone = new Tomato(ts, w.tomatolist.Count + 1);
            for (int i = 0; i < day; i++)
                addone.DayRecordlist[i] = -1;
        }
        public void DeleteTomato(WorkPlan w,int Sn,int day)
        {
            foreach(Tomato  a in w.tomatolist)
            {
                if (a.signNumber == Sn)
                    for(int i=day; i < w.dayTime; i++)
                    {
                        a.DayRecordlist[i] = -1;
                    }
                    
            }
        }
        
        //删除对应名字的计划。
        public void DeleteWorkplan(String Name)
        {
            WorkPlan w = SearchWorkplan(Name);
            plans.Remove(w);
        }
        //查找对应的workname
        public WorkPlan SearchWorkplan(String name)
        {
            var W1 = from n in plans
                     where n.workName == name
                     select n;
            WorkPlan W2 = null;
            foreach (WorkPlan ele in W1) W2 = ele;
            return W2;
            //foreach (WorkPlan WP in  plans)
            //{
            //    if (WP.workName == name)
            //        return WP;
            //}
            //return null;//备选方案
        }
        public void AddWorkplan(String wn,int t,List<TimeSpan> T)
        {
            WorkPlan newWorkplan=new WorkPlan(wn, t);
            for (int i = 0; i < T.Count; i++)
            {
                newWorkplan.tomatolist.Add(new Tomato(T[i], newWorkplan.tomatolist.Count + 1));
            }
        }
    }

}

