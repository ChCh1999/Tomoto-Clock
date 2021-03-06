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
        string current;
        public TomatoList()
        {
            InitializeComponent();
            //List<WorkPlan> allWP = clockService.getAllWorkPlan();  
            HistoryService history = new HistoryService();//将tomatolist内容导出，写成一个函数调用AddItem方法
            List<WorkPlan> allWP =clockService.getAllWorkPlan();
            foreach (WorkPlan w in allWP)
            {
                int day = clockService.GetDays(w);
                int finished = clockService.getFinishedTomatoSignNum(w, day).Count();
                int active = clockService.getActiveTomatoSignNum(w, day).Count();
                AddItem(w.workName, "第" + (day + 1) + "天/" + w.NumofDay, finished + "/" + active);
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

            //Border border = new Border();
            //Thickness margin1 = new Thickness(0, 10, 0, 0);
            //border.Margin = margin1;
            //border.BorderThickness = new Thickness(2);
            //border.BorderBrush = new SolidColorBrush(Colors.White);                                     //加入边框

            TextBlock nameBlock = new TextBlock();
            nameBlock.Text = name;
            nameBlock.FontSize = 16;
            nameBlock.Width = 70;
            nameBlock.Foreground = Brushes.White;
            wrapPanel.Children.Add(nameBlock);

            TextBlock timeBlock = new TextBlock();
            timeBlock.Text = time;
            timeBlock.FontSize = 16;
            timeBlock.Foreground = Brushes.White;
            Thickness margin = new Thickness(20, 0, 0, 0);
            timeBlock.Margin = margin;
            timeBlock.Width = 90;
            wrapPanel.Children.Add(timeBlock);

            TextBlock processBlock = new TextBlock();
            processBlock.Margin = margin;
            processBlock.Foreground = Brushes.White;
            processBlock.FontSize = 16;
            processBlock.Width = 50;
            processBlock.Text = process;
            wrapPanel.Children.Add(processBlock);


            wrapPanel.Name = name;
            wrapPanel.AddHandler(WrapPanel.MouseDownEvent, new MouseButtonEventHandler(ChooseWP),true);
            this.ListWrapPanel.Children.Add(wrapPanel);

        }
        private void ChooseWP(object sender, MouseButtonEventArgs e)
        {
            chooseTomato createTomato = new chooseTomato();
            createTomato.Owner = Application.Current.MainWindow;
            foreach(WrapPanel a in ListWrapPanel.Children)
            {
                if (sender == a)
                    current = a.Name;
            }
            createTomato.getName(current);
            createTomato.ShowDialog();
        }
    }
}
