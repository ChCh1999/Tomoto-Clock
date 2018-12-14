using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClock
{
    class WorkPlan
    {
        private string workName { get; set;}
        private int dayTime { get; set; }
        public List<Tomato> tomatolist = new List<Tomato>();    //tomato的动态数组，每个tomato都有一个自己的时间
        public WorkPlan(string wkn,int dt)
        {
            workName = wkn;
            dayTime = dt;
        }
        public WorkPlan() { }
        public void addTomato(float Time,int signNumber)        //将一个番茄加入到番茄的list中
        {
            Tomato t=new Tomato(Time, signNumber);
            tomatolist.Add(t);
        }
    }
    class Tomato
    {
        public float tomatoTime { get; set; }
        public int signNumber { get; set; }          //标记的数字，用来标明该番茄
        public Tomato(float Time,int sN)
        {
            tomatoTime = Time;
            signNumber = sN;
        }
    }
         
    
}
