using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class Timer
    {
        //定义时、分、秒三个字段
        public int hour;
        public int minute;
        public int second;

        //构造函数
        public Timer(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        //定义时、分、秒三个属性
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
            }
        }

        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                second = value;
            }
        }

        //小时加一
        public void AddHour()
        {
            if (Hour < 23)
            {
                Hour++;
            }
            else
            {
                Hour = 0;
            }
            
        }

        //分钟加一
        public void AddMinute()
        {
            if(Minute<59)
                Minute++;
            else
            {
                AddHour();
                Minute = 0;
            }
        }

        //秒钟加一
        public void AddSecond()
        {
            if(Second<59)
                Second++;
            else
            {
                AddMinute();
                Second = 0;
            }
        }

        //单独显示小时
        public void DisplayHour()
        {
            Console.WriteLine("小时：{0}",hour);
        }

        //单独显示分钟
        public void DisplayMinute()
        {
            Console.WriteLine("分钟：{0}", minute);
        }

        //单独显示秒钟
        public void DisplaySecond()
        {
            Console.WriteLine("秒钟：{0}", second);
        }

        //同时显示时间
        public void DisplayTime()
        {
            Console.WriteLine("当前时间为：{0}时{1}分{2}秒", hour, minute, second);
        }

        static void Main(string[] args)
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            int hours = currentTime.Hour;
            int minutes = currentTime.Minute;
            int seconds = currentTime.Second;

            Timer hms = new Timer(hours, minutes, seconds);
            Console.WriteLine("同时显示时分秒:");
            hms.DisplayTime();
            Console.WriteLine("");

            Console.WriteLine("分别显示时分秒:");
            hms.DisplayHour();
            hms.DisplayMinute();
            hms.DisplaySecond();
            Console.WriteLine("");

            Console.WriteLine("小时加一:");
            hms.AddHour();
            hms.DisplayHour();
            Console.WriteLine("");

            Console.WriteLine("分钟加一:");
            hms.AddMinute();
            hms.DisplayMinute();
            Console.WriteLine("");

            Console.WriteLine("秒钟加一:");
            hms.AddSecond();
            hms.DisplaySecond();
            Console.WriteLine("");

            Console.Write("更改后的时间为:");
            hms.DisplayTime();
            Console.WriteLine("");

            Console.ReadLine();
            //system("pause");
        }
    }
}

