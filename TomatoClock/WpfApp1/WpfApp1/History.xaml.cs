using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TomatoClock;
namespace WpfApp1
{
    /// <summary>
    /// History.xaml 的交互逻辑
    /// </summary>
    public partial class History : Page
    {
        ClockService clockService = new ClockService();
        
        public History()
        {
            InitializeComponent();

            this.WorkPlans.ItemsSource = clockService.getAllWorkPlan().Select(a => a.workName).ToList();
        }

        private void AddItem(String name, String process)                                        //添加项目
        {
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.HorizontalAlignment = HorizontalAlignment.Center;


            TextBlock nameBlock = new TextBlock();
            nameBlock.Text = name;
            nameBlock.Width = 100;
            nameBlock.FontSize = 17;
            nameBlock.Foreground = Brushes.White;
            wrapPanel.Children.Add(nameBlock);

            TextBlock processBlock = new TextBlock();
            processBlock.Margin = new Thickness(80,0,0,0);
            processBlock.Foreground = Brushes.White;
            processBlock.FontSize = 17;
            processBlock.Width = 100;
            processBlock.Text = process;
            wrapPanel.Children.Add(processBlock);

            this.HistoryList.Children.Add(wrapPanel);


        }

        private MouseEventHandler ShowItemDetail(Border border)
        {

            throw new NotImplementedException();
        }

        private void WorkPlans_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string wpName = WorkPlans.SelectedItem.ToString();
            WorkPlan target = clockService.chooseWorkPlan(wpName);
            int day = clockService.GetDays(target);
            if (day < 7)
            {
                for(int i = 0; i < day+1; i++)
                {
                    int finished = clockService.getFinishedTomatoSignNum(target, day - i).Count();
                    int active = clockService.getActiveTomatoSignNum(target, day - i).Count();
                    if (i == 0)
                    {
                        this.AddItem("today", finished + "/" + active);
                    }
                    else
                    {
                        this.AddItem(i+"天前", finished + "/" + active);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    int finished = clockService.getFinishedTomatoSignNum(target, day - i).Count();
                    int active = clockService.getActiveTomatoSignNum(target, day - i).Count();
                    if (i == 0)
                    {
                        this.AddItem("today", finished + "/" + active);
                    }
                    else
                    {
                        this.AddItem(i + "天前", finished + "/" + active);
                    }
                }
            }
            
        }
    }
}
