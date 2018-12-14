using System;

class WorkpPlan
{
    public int days;
    public string name;
    public DateTime time;
}
class History
{

    WorkpPlan[] plans = new WorkpPlan[31];

    public int getDays(WorkpPlan w)
    {
        return w.days;
    }

    public void setDays(WorkpPlan w,int days)
    {
        w.days = days;
    }

    public string getName(WorkpPlan w)
    {
        return w.name;
    }

    public void setName(WorkpPlan w,string name)
    {
        w.name = name;
    }

    public DateTime getTime(WorkpPlan w)
    {
        return w.time;
    }

    public void setTime(WorkpPlan w,DateTime time)
    {
        w.time = time;
    }
}

