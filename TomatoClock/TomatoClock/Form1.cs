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
            List<TomatoList> tomatos = new List<TomatoList>();
            List<TCondition> TC = new List<TCondition>();
            TC.Add(new TCondition());
            TomatoList to=new TomatoList(1000,0,TC);
            tomatos.Add(to);
            my.addWorkPlan("尝试", 10, tomatos);
        }
    }
}
