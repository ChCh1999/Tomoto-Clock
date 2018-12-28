using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace TomatoClock
{
    public class HistoryService
    {
        public void Add(WorkPlan workplan)
        {
            using (var db = new HistoryDB())
            {
                if (db.workplan.Where(a => a.workName == workplan.workName).ToList().Count == 0)
                {
                    db.workplan.Add(workplan);
                    db.SaveChanges();
                }
            }
        }
        public void Delete(string wname)
        {
            using (var db = new HistoryDB())
            {
                var workplan = db.workplan.Include("workplan").SingleOrDefault(w => w.workName == wname);
                var tomato = db.tomatolist.Include("TomatoList").SingleOrDefault(t => t.wid == workplan.wpid);
                db.tcondition.RemoveRange(tomato.tcondition);
                db.tomatolist.RemoveRange(workplan.tomatolist);
                db.workplan.Remove(workplan);
                db.SaveChanges();
            }
        }

        public void Update(WorkPlan workplan)
        {
            using (var db = new HistoryDB())
            {
                db.workplan.Attach(workplan);
                db.Entry(workplan).State = EntityState.Modified;
                workplan.tomatolist.ForEach(t => db.Entry(t).State = EntityState.Modified);
                db.SaveChanges();
            }
        }
        public void Update(string wpName)
        {
            using (var db = new HistoryDB())
            {
                WorkPlan workplan = db.workplan.SingleOrDefault(w => w.workName == wpName);
                db.workplan.Attach(workplan);
                db.Entry(workplan).State = EntityState.Modified;
                workplan.tomatolist.ForEach(t => db.Entry(t).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public void Update(TomatoList tomato)
        {
            using (var db = new HistoryDB())
            {
                db.tomatolist.Attach(tomato);
                db.Entry(tomato).State = EntityState.Modified;
                tomato.tcondition.ForEach(t => db.Entry(t).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public WorkPlan GetWorkPlan(string wname)
        {
            using (var db = new HistoryDB())
            {
                return db.workplan.SingleOrDefault(w => w.workName == wname);
            }
        }
        public int getdays(WorkPlan wp)
        {
            DateTime dt = DateTime.Now.Date;
            DateTime start = DateTime.ParseExact(wp.StartDay, "yyyyMMdd", null);
            return (dt - start).Days;
        }
        public List<WorkPlan> GetAllWorkPlan()
        {
            using (var db = new HistoryDB())
                return db.workplan.ToList();
        }

        //public List<WorkPlan> QueryBySignNumber(long num)
        //{
        //    using (var db = new HistoryDB())
        //    {
        //        var query = db.workplan.Include("TomatoList")
        //          .Where(w => w.tomatolist.Where(
        //            tomato => tomato.signNum.Equals(num)).Count() > 0);
        //        return query.ToList();
        //    }
        //}
        public List<int> getActiveTomatoSignNum(WorkPlan wp,int day)
        {
            List<int> result = new List<int>();
            using (var db = new HistoryDB())
            {
                result = db.workplan.SingleOrDefault(w => w.workName == wp.workName).
                    tomatolist.Where(tomato => tomato.tcondition[day].con !=- 1).Select(s => (int)s.signNum).ToList();
                return result;
            }
        }
        public List<int> getFinishedTomatoSignNum(WorkPlan wp, int day)
        {
            List<int> result = new List<int>();
            using (var db = new HistoryDB())
            {
                result= db.workplan.SingleOrDefault(w => w.workName == wp.workName).
                    tomatolist.Where(tomato => tomato.tcondition[day].con == 1).Select(s => (int)s.signNum).ToList();
                return result;
            }
        }
        public bool getTomatoCon(string wpName,int day,int sn)
        {
            using (var db = new HistoryDB())
            {
                 TomatoList target= db.workplan.SingleOrDefault(w => w.workName == wpName)
                    .tomatolist.SingleOrDefault(tomato => tomato.signNum == sn);
                if (target.tcondition[day - 1].con == 1)
                    return true;
                else
                    return false;
            }
            
        }
        public TomatoList GetTomato(WorkPlan wp, long signNum)
        {
            using (var db = new HistoryDB())
            {
                return db.workplan.SingleOrDefault(w => w.workName == wp.workName)
                    .tomatolist.SingleOrDefault(tomato => tomato.signNum == signNum);
            }
        }
        public void addTomato(string WPName,long time)
        {
            using (var db = new HistoryDB())
            {
                //WorkPlan wp = db.workplan.SingleOrDefault(w => w.workName == WPName);
                //int day = getdays(wp);
                //int sn = wp.tomatolist.Count();//个数作为编号
                //TomatoList target = new TomatoList(time, sn);
                //wp.tomatolist.Add(target);
                //target.wid = wp.wpid;
                //db.tomatolist.Add(target);
                //for (int i = day; i < wp.NumofDay; i++)
                //{
                //    TCondition NewCon = new TCondition();
                //    NewCon.con = 0;
                //    NewCon.toid = target.tid;
                //    target.tcondition.Add(NewCon);
                //    db.tcondition.Add(NewCon);
                //}
                //db.SaveChanges();
            }
        }
        public void DeleteTomato(string WPName,long sn)
        {
            using (var db = new HistoryDB())
            {
                WorkPlan wp= db.workplan.SingleOrDefault(w => w.workName == WPName);
                int day = getdays(wp);
                TomatoList target = wp.tomatolist.SingleOrDefault(tomato => tomato.signNum == sn);
                for (int i = day; day < wp.NumofDay; i++)
                    target.tcondition[i].con = -1;
                Update(wp);
            }
            
        }
    }
}
