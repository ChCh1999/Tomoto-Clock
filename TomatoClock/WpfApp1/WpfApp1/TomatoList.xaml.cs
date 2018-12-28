﻿using System;
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

namespace WpfApp1
{
    /// <summary>
    /// TomatoList.xaml 的交互逻辑
    /// </summary>
    /// 
    
    public partial class TomatoList : Page
    {
        public TomatoList()
        {
            InitializeComponent();
            List<WorkPlan> allWP = clockService.getAllWorkPlan();
            foreach (WorkPlan wp in allWP)
            {
                int day = clockService.GetDays(wp);
                int finished = clockService.getFinishedTomatoSignNum(wp, day).Count();
                int active = clockService.getActiveTomatoSignNum(wp, day).Count();
                AddItem(wp.workName, "第" + (day + 1) + "天" + "/" + wp.NumofDay, finished + "/" + active);
            }
            //将tomatolist内容导出，写成一个函数调用AddItem方法
        }

        private void CreateNewItem_Click(object sender, RoutedEventArgs e)
        {

        }



        private void AddItem(String name, String time, String process)                                        //添加项目
        {
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Orientation = Orientation.Horizontal;
            wrapPanel.HorizontalAlignment = HorizontalAlignment.Center;

            Border border = new Border();
            border.Name = name;
            Thickness margin1 = new Thickness(0, 10, 0, 0);
            border.Margin = margin1;
            border.BorderThickness = new Thickness(1);
            border.BorderBrush = new SolidColorBrush(Colors.White);                                     //加入边框

            TextBlock nameBlock = new TextBlock();
            nameBlock.Text = name;
            nameBlock.FontSize = 16;
            nameBlock.Foreground = Brushes.White;
            wrapPanel.Children.Add(nameBlock);

            TextBlock timeBlock = new TextBlock();
            timeBlock.Text = time;
            timeBlock.FontSize = 16;
            timeBlock.Foreground = Brushes.White;
            Thickness margin = new Thickness(20, 0, 0, 0);
            timeBlock.Margin = margin;
            wrapPanel.Children.Add(timeBlock);

            TextBlock processBlock = new TextBlock();
            processBlock.Margin = margin;
            processBlock.Foreground = Brushes.White;
            processBlock.FontSize = 16;
            processBlock.Text = "完成进度：" + process;
            wrapPanel.Children.Add(processBlock);

            border.Child = wrapPanel;
            //border.GotMouseCapture += ShowItemDetail(border);
            wrapPanel.AddHandler(WrapPanel.MouseLeftButtonDownEvent,
                   new MouseButtonEventHandler(MouseDown), true);
            this.ListWrapPanel.Children.Add(border);

        }

        private new void MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChooseTomato chooseWin = new ChooseTomato();
            chooseWin.Owner = Application.Current.MainWindow;
            chooseWin.ShowDialog();
        }
        //private MouseEventHandler ShowItemDetail(Border border)
        //{

        //      throw new NotImplementedException();
        //}
    }
}
