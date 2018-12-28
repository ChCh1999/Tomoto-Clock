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
        static int i = 0;
        public History()
        {
            InitializeComponent();
            ClockService clockService = new ClockService();
            this.WorkPlans.ItemsSource = clockService.getAllWorkPlan().Select(a => a.workName).ToList();
            AddItem("日期", "完成进度");
        }

        private void AddItem(String name, String process)                                        //添加项目
        {
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Orientation = Orientation.Horizontal;
            wrapPanel.HorizontalAlignment = HorizontalAlignment.Center;

            TextBlock nameBlock = new TextBlock();
            nameBlock.Text = name;
            nameBlock.Margin = new Thickness(10, 0, 0, 0);
            nameBlock.FontSize =18;
            nameBlock.Foreground = Brushes.White;
            nameBlock.Width = 100;
            wrapPanel.Children.Add(nameBlock);

            TextBlock processBlock = new TextBlock();
            processBlock.Margin = new Thickness(100, 0, 0, 0); ;
            processBlock.Foreground = Brushes.White;
            processBlock.FontSize = 18;
            processBlock.Width = 100;
            processBlock.Text =  process;
            wrapPanel.Children.Add(processBlock);

            this.HistoryList.Children.Add(wrapPanel);

        }

        private void WorkPlans_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //private MouseEventHandler ShowItemDetail(Border border)
        //{

        //      throw new NotImplementedException();
        //}
    }
}
