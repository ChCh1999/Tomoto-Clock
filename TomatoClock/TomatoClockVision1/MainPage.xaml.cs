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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace TomatoClockVision1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
                  this.InitializeComponent();
                  MyFrame.Navigate(typeof(TomatoList));
                  BackButton.Visibility = Visibility.Collapsed;
                  TomatoList.IsSelected = true;
                  TitleTextBlock.Text = "Tomato List";
        }

            private void HamburgerButton_Click(object sender, RoutedEventArgs e)
            {
                  MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            }

            private void BackButton_Click(object sender, RoutedEventArgs e)
            {
                  if (MyFrame.CanGoBack)
                  {
                        MyFrame.GoBack();
                        TomatoList.IsSelected = true ;
                  }
            }

            private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

                  if(TomatoList.IsSelected)
                  {
                        BackButton.Visibility = Visibility.Collapsed;
                        MyFrame.Navigate(typeof(TomatoList));
                        TitleTextBlock.Text = "Tomato List";
                  }

                  else if(TomatoHistory.IsSelected)
                  {
                        MyFrame.Navigate(typeof(TomatoHistory));
                        BackButton.Visibility = Visibility.Visible;
                        TitleTextBlock.Text = "Tomato History";
                  }

                  else if(TemporaryTomato.IsSelected)
                  {
                        MyFrame.Navigate(typeof(TemporaryTomato));
                        BackButton.Visibility = Visibility.Visible;
                        TitleTextBlock.Text = "Temporary Tomato";
                  }

            }
      }
}
