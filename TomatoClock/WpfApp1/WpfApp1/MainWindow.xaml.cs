using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
      {
        
            //private NotifyIcon notifyIcon = null;
            public MainWindow()
            {
            InitialTray();
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

            private void TitleBar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
            {

                  if (e.LeftButton == MouseButtonState.Pressed)
                  {
                        this.DragMove();
                  }
            }

            private void ExitButton_Click(object sender, RoutedEventArgs e)
            {
            System.Windows.Application.Current.Shutdown();
            ico.notifyIcon = null;
            }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            //隐藏主窗体
            this.Visibility = Visibility.Hidden;
            ico.notifyIcon.BalloonTipText = "TomatoClock在后台继续运行..";
            ico.notifyIcon.ShowBalloonTip(2000);
        }

        private void InitialTray()
        {
            //设置托盘的各个属性
            ico.notifyIcon = new NotifyIcon();
            ico.notifyIcon.Text = "TomatoClock";
            ico.notifyIcon.Icon = new System.Drawing.Icon("../../Assets/tomatoico.ico");
            ico.notifyIcon.Visible = true;

            ico.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_MouseClick);

            //显示窗口
            System.Windows.Forms.MenuItem show = new System.Windows.Forms.MenuItem("显示");
            show.Click += new EventHandler(show_click);

            //退出菜单项
            System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("退出");
            exit.Click += new EventHandler(exit_Click);

            //关联托盘控件
            System.Windows.Forms.MenuItem[] childen = new System.Windows.Forms.MenuItem[] { show, exit };
            ico.notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);

            //窗体状态改变时候触发
            this.StateChanged += new EventHandler(SysTray_StateChanged);
        }

        private void show_click(object sender, EventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                this.Visibility = Visibility.Visible;
                this.Activate();
            }
        }

        /// <summary>
        /// 鼠标单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //如果鼠标左键单击
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visibility == Visibility.Visible)
                {
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                    this.Activate();
                }
            }
        }

        /// <summary>
        /// 窗体状态改变时候触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysTray_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Visibility = Visibility.Hidden;
            }
        }


        /// <summary>
        /// 退出选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("Are you sure to exit?",
                                               "application",
                                                MessageBoxButton.YesNo,
                                                MessageBoxImage.Question,
                                                MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
                ico.notifyIcon = null;
            }
        }

        private void SucceedClock()
        {
            ico.notifyIcon.BalloonTipText = "";
        }
    }
}
