using System;
using System.Collections;
using System.Collections.Generic;

namespace TomatoClock
{
    class History
    {

        //WorkPlan[] plans = new WorkPlan[31];
        List<WorkPlan> plans = new List<WorkPlan>();
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

        public static void AddTomato(WorkPlan w,TimeSpan ts)
        {
            Tomato addone = new Tomato(ts, w.tomatolist.Count + 1);
        }
        public static void DeleteTomato(WorkPlan w,int Sn)
        {
            foreach(Tomato  a in w.tomatolist)
            {
                if (a.signNumber == Sn)
                    w.tomatolist.Remove(a);
            }
        }
    }

}

