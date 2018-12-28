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
using TomatoClock;

namespace WpfApp1
{
    /// <summary>
    /// TomatoList.xaml 的交互逻辑
    /// </summary>
    public partial class TomatoList : Page
    {
        ClockService clockService = new ClockService();
        public TomatoList()
        {
            InitializeComponent();
            List<WorkPlan> allWP = clockService.getAllWorkPlan();                           //将tomatolist内容导出，写成一个函数调用AddItem方法
            foreach(WorkPlan w in allWP)
            {
                int day = clockService.GetDays(w);
                int finished = clockService.getFinishedTomatoSignNum(w, day).Count();
                int active = clockService.getActiveTomatoSignNum(w, day).Count();
                AddItem(w.workName, "第" + (day + 1) + "天/" + w.NumofDay, "完成度" + finished + "/" + active);
            }
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
            Thickness margin1 = new Thickness(0, 10, 0, 0);
            border.Margin = margin1;
            border.BorderThickness = new Thickness(2);
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

            wrapPanel.AddHandler(WrapPanel.MouseDownEvent, new MouseEventHandler(ChooseWP),true);
            this.ListWrapPanel.Children.Add(border);

        }
        private void ChooseWP(object sender, MouseEventArgs e)
        {
            chooseTomato createTomato = new chooseTomato();
            createTomato.Owner = Application.Current.MainWindow;
            createTomato.ShowDialog();
            
        }


    }
}