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

namespace WpfApp1
{
    /// <summary>
    /// Temp.xaml 的交互逻辑
    /// </summary>
    public partial class Temp : Page
    {
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

            }

            private void StartButton_Click(object sender, RoutedEventArgs e)
            {
                  StartButton.Visibility = Visibility.Collapsed;
                  StopButton.Visibility = Visibility.Visible;
                  //开始计时，并计入history
                  //将TimeText.Text与倒计时相绑定
            }

            private void StopButton_Click(object sender, RoutedEventArgs e)
            {
                  StartButton.Visibility = Visibility.Visible;
                  StopButton.Visibility = Visibility.Collapsed;
                  TimeText.Text = "00:45:00";
                  //不计入history
            }
      }
            



   }

      
