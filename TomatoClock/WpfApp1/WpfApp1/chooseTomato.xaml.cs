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
using System.Windows.Shapes;
using TomatoClock;
namespace WpfApp1
{
    /// <summary>
    /// chooseTomato.xaml 的交互逻辑
    /// </summary>
    public partial class chooseTomato : Window
    {
        
        string current;
        short tid;
        ClockService clockService = new ClockService();
        public chooseTomato()
        {
            InitializeComponent();
        }
        public string getName(string name)
        {
            current = name;
            WorkPlan wp = clockService.chooseWorkPlan(current);
            int day = clockService.GetDays(wp);
            List<int>times= clockService.GetTodayTimes(name);
            tomatos.ItemsSource = times;
            this.WPName.Content = name;
            return current;
        }

        private void tomatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)//退出
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//删除
        {
            clockService.deleteWorkPlan(current);
            this.Close();
        }
    }
}
