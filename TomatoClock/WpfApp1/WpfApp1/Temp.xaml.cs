using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;
using System.Diagnostics;//引入Process 类


namespace WpfApp1
{
      
    /// <summary>
    /// Temp.xaml 的交互逻辑
    /// </summary>
    public partial class Temp : Page
    {
        //新写的
        private TimeCount timeCount;
        private DispatcherTimer timer;
        private Process[] MyProcesses;
        private Stopwatch stopwatch;
        //新写的
        public Temp()
            {
                  InitializeComponent();
                  String[] arry = { "你越不在乎别人的看法，生活就会变的越简单。",
                        "黑夜过后的光芒有多美。",
                        "最困难的时刻也许就是拐点的开始，改变一下思维方式就可能迎来转机。以平常心看世界，花开花谢都是风景。",
                        "既然选择了追求，就不要哭泣。坚持一下，扛过今天，幸福就更近一步。真正能把人累垮的，是心里的绝望。",
                              "每天给自己一个希望，试着不为明天而烦恼，不为昨天而叹息，只为今天更美好。",
                  "别小看任何人，越不起眼的人、往往会做些让人想不到的事。",
                  "不要去听别人的忽悠，你人生的每一步都必须靠自己的能力完成。自己肚子里没有料，手上没本事，认识再多人也没用。",
                  "耐心是一切聪明才智的基础。",
                  "得而不喜，失而不忧，则幸福常在。",
                  "每个人都会有缺陷，就像被上帝咬过的苹果，有的人缺陷比较大，正是因为上帝特别喜欢他的芬芳。",
                  "有时候你以为天要塌下来了，其实是自己站歪了。",
                  "有时候，人生中最艰难的事，反而锻造了最坚强的你。",
                  "即使能力有限，也不要忘记有梦想的自己。",
                  "人生只有回不去的过去，没有过不去的当下。",
                  "只要路是对的，就不害怕遥远。只要认准是值得的，就不在乎沧桑变化。"};
                   Random rd = new Random();
                   int i = rd.Next(0, 15);
                  JiTang.Text = arry[i];
            MyProcesses = Process.GetProcessesByName("Google Chrome.exe");//需要监控的程序名，该方法带出该程序所有用到的进程
            foreach (Process myprocess in MyProcesses)
            {
                if (myprocess.ProcessName.ToLower() == "Google Chrome.exe")
                {
                    MessageBox.Show("SajetManager");
                    myprocess.EnableRaisingEvents = true;//设置进程终止时触发的时间
                    myprocess.Exited += new EventHandler(myprocess_Exited);//发现外部程序关闭即触发方法myprocess_Exited
                }
            }

        }

        private void myprocess_Exited(object sender, EventArgs e)//被触发的程序
        {
            MessageBox.Show("SajetManager close");
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
            {
            string content = Button.Content.ToString();
            if (content == "结束")
            {
                Button.Content = "开始";
                timer.Stop();
                ico.notifyIcon.BalloonTipText = "没有完成呢~";
                ico.notifyIcon.ShowBalloonTip(2000);
                ResetClock();
            }
            else if(content == "开始")
            {
                Button.Content = "结束";
                //开始计时，并计入history
                //将TimeText.Text与倒计时相绑定
                MainWin_Loaded(sender, e);
                StartClock();

                //新写的
                //这个是执行倒计时的操作
            }
        }

        //新写的
        private void MainWin_Loaded(object sender, RoutedEventArgs e)
         {
            //设置定时器
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(10000000);   //事件间隔为一秒钟
            timer.Tick += new EventHandler(timer_Tick);
        }
        //委托
        public delegate bool CountDownHandler();
        //事件
        public event CountDownHandler CountDown;
        public bool OnCountDown()
        {
             if (CountDown != null)
                return CountDown();
 
            return false;
        }

        //Timer触发的事件
         private void timer_Tick(object sender, EventArgs e)
         {
             if (OnCountDown())
             {
                 HourArea.Text = timeCount.GetHour();
                 MinuteArea.Text = timeCount.GetMinute();
                 SecondArea.Text = timeCount.GetSecond();
             }
             else
            {
                SecondArea.Text = timeCount.GetSecond();
                ico.notifyIcon.BalloonTipText = "完成目标啦！";
                ico.notifyIcon.ShowBalloonTip(2000);
                ResetClock();
                Button.Content = "开始";
                timer.Stop();
            }
         }

        private void ResetClock()
        {
            HourArea.Text = "00";
            MinuteArea.Text = "15";
            SecondArea.Text = "00";
        }

        private void StartClock()
        {
            int mins = int.Parse(sTime.Text);
            if (mins / 60 == 0)
            {
                this.HourArea.Text = "00";
            }
            else
                this.HourArea.Text = (mins / 60).ToString();
            if (mins % 60 == 0)
            {
                this.MinuteArea.Text = "00";
            }
            else
                this.MinuteArea.Text = (mins % 60).ToString();
            this.SecondArea.Text = "00";
            //转换成秒数
            Int32 hour = Convert.ToInt32(HourArea.Text);
            Int32 minute = Convert.ToInt32(MinuteArea.Text);
            Int32 second = Convert.ToInt32(SecondArea.Text);

            //处理倒计时的类
            timeCount = new TimeCount(hour * 3600 + minute * 60 + second);
            CountDown += new CountDownHandler(timeCount.ProcessCountDown);

            //开启定时器
            timer.Start();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int mins = int.Parse(setTime.Text);
            //if(mins / 60 == 0)
            //{
            //    this.HourArea.Text = "00";
            //}
            //else
            //this.HourArea.Text = (mins / 60).ToString();
            //if (mins % 60 == 0)
            //{
            //    this.MinuteArea.Text = "00";
            //}
            //else
            //this.MinuteArea.Text = (mins % 60).ToString();
            //this.SecondArea.Text = "00";
        }
    }
   }

      
