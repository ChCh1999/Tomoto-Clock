using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace TomatoClockVision1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class TemporaryTomato : Page
    {
        public TemporaryTomato()
        {
            this.InitializeComponent();
        }

            private void StartButton_Click(object sender, RoutedEventArgs e)
            {
                  var time = TemporaryTomatoTimeSet.Time;
                  TemporaryTomatoTimeSet.Visibility = Visibility.Collapsed;
                  TomatoProgress.Visibility = Visibility.Visible;
                  ButtonStackPanel.Visibility = Visibility.Visible;
                  StartButton.Visibility = Visibility.Collapsed;
                  
                  // 并且开始计时，将  时间/设定时间的比例与进度条绑定

            }

            private void PauseButton_Click(object sender, RoutedEventArgs e)
            {

            }

            private void StopButton_Click(object sender, RoutedEventArgs e)
            {

            }
      }
}
