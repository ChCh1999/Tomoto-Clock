using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClock
{   
    //实现倒计时功能的类

    public class TimeCount
    {
        private Int32 _TotalSecond;
        public Int32 TotalSecond
       {
            get { return _TotalSecond; }
            set { _TotalSecond = value; }
        }

        public TimeCount(Int32 totalSecond)
        {
            this._TotalSecond = totalSecond;
        }

        //减秒
        public bool ProcessCountDown()
         {
             if (_TotalSecond == 0)
                 return false;
             else
             {
                 _TotalSecond--;
                 return true;
             }
        }

         /// 获取小时显示值
        public string GetHour()
        {
             return String.Format("{0:D2}", (_TotalSecond / 3600));
        }
 
         /// 获取分钟显示值
         public string GetMinute()
         {
             return String.Format("{0:D2}", (_TotalSecond % 3600) / 60); 
         }
 
         /// 获取秒显示值
        public string GetSecond()
         {
             return String.Format("{0:D2}", _TotalSecond % 60);
         }
    }
}
