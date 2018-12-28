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
      /// MainWindow.xaml 的交互逻辑
      /// </summary>
      public partial class MainWindow : Window
      {
            ClockService clockService = new ClockService();
            public MainWindow()
            {
                  InitializeComponent();
                  this.MyFrame.Navigate(new Uri("TomatoList.xaml", UriKind.Relative));
                  BitmapImage bti = new BitmapImage();
                  bti.BeginInit();
                  bti.UriSource = new Uri("Assets/bg2.jpg", UriKind.Relative);
                  bti.EndInit();
                  BgImage.Source = bti;
            }

            private void HistoryButton_Click(object sender, RoutedEventArgs e)
            {
                  this.MyFrame.Navigate(new Uri("History.xaml", UriKind.Relative));
                  BitmapImage bti = new BitmapImage();
                  bti.BeginInit();
                  bti.UriSource = new Uri("Assets/HitoryBg.jpg", UriKind.Relative);
                  bti.EndInit();
                  BgImage.Source = bti;
            }

            private void ListButton_Click(object sender, RoutedEventArgs e)
            {
                  this.MyFrame.Navigate(new Uri("TomatoList.xaml", UriKind.Relative));
                  BitmapImage bti = new BitmapImage();
                  bti.BeginInit();
                  bti.UriSource = new Uri("Assets/bg2.jpg", UriKind.Relative);
                  bti.EndInit();
                  BgImage.Source = bti;
                 
            }

            private void TempButton_Click(object sender, RoutedEventArgs e)
            {
                  

                  this.MyFrame.Navigate(new Uri("Temp.xaml", UriKind.Relative));
                  BitmapImage bti = new BitmapImage();
                  bti.BeginInit();
                  bti.UriSource= new Uri("Assets/TempBg.jpg", UriKind.Relative);
                  bti.EndInit();
                  BgImage.Source = bti;
            }

            private void TitleBar_MouseMove(object sender, MouseEventArgs e)
            {

                  if (e.LeftButton == MouseButtonState.Pressed)
                  {
                        this.DragMove();
                  }
            }

            private void ExitButton_Click(object sender, RoutedEventArgs e)
            {
                  Application.Current.Shutdown();
            }

      }
}
