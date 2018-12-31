using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TomatoClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClockService my = new ClockService();
            HistoryService myh = new HistoryService();
            for(int i = 0; i < 5; i++)
            {
                List<TomatoList> tomatos = new List<TomatoList>();
                for(int r = 0; r < i + 1; r++)
                {
                    List<TCondition> TC = new List<TCondition>();
                    for (int j = 0; j < 10; j++)
                        TC.Add(new TCondition());
                    TomatoList to = new TomatoList(30, 0, TC);
                    tomatos.Add(to);
                }
                myh.Add(new WorkPlan("Wp"+i, 10, tomatos));
                List<WorkPlan> w = myh.GetAllWorkPlan();
                this.Text = w.Count().ToString();
            }
            
            
        }
    }
}
