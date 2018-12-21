using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClock
{
    class WorkPlan
    {
        public int currentDay { get; set; }
        public string workName { get; set;}
        public int dayTime { get; set; }
        public List<String> toDolist = new List<string>();       //给每个计划增加一个相当于便条式的属性
        public List<Tomato> tomatolist = new List<Tomato>();    //tomato的动态数组，每个tomato都有一个自己的时间
        public WorkPlan(string wkn,int dt)
        {
            workName = wkn;
            dayTime = dt;
        }
        public WorkPlan() { }
        public void addTomato(TimeSpan Time,int signNumber)        //将一个番茄加入到番茄的list中
        {
            Tomato t=new Tomato(Time, signNumber);
            tomatolist.Add(t);
        }
    }
}
