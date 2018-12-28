using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace TomatoClock
{
    class HistoryService
    {
        public void Add(WorkPlan workplan)
        {
            using (var db = new HistoryDB())
            {
                db.workplan.Add(workplan);
                db.SaveChanges();
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
                return db.workplan.Include("Workplan").
                  SingleOrDefault(w => w.workName == wname);
            }
        }

        public List<WorkPlan> GetAllWorkPlan()
        {
            using (var db = new HistoryDB())
                return db.workplan.Include("Workplan").ToList();
        }

        public List<WorkPlan> QueryBySignNumber(long num)
        {
            using (var db = new HistoryDB())
            {
                var query = db.workplan.Include("TomatoList")
                  .Where(w => w.tomatolist.Where(
                    tomato => tomato.signNum.Equals(num)).Count() > 0);
                return query.ToList();
            }
        }

        public TomatoList GetTomato(WorkPlan wp, long signNum)
        {
            using (var db = new HistoryDB())
            {
                return db.workplan.Include("WorkPlan").SingleOrDefault(w => w == wp)
                    .tomatolist.SingleOrDefault(tomato => tomato.signNum == signNum);
            }
        }
    }
}
