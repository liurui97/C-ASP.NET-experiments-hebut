//引入头文件
using System;

//定义一个接口
public interface IComparable
{
    int CompareTo(IComparable comp);
}

//定义TimeSpan类，继承接口
public class TimeSpan : IComparable
{
    //定义私有成员
    private uint totalSeconds;

    //定义无参构造函数
    public TimeSpan()
    {
        totalSeconds = 0;
    }

    //定义有参构造函数
    public TimeSpan(uint initialSeconds)
    {
        totalSeconds = initialSeconds;
    }

    //定义属性
    public uint Seconds
    {
        get
        {
            return totalSeconds;
        }
        set
        {
            totalSeconds = value;
        }
    }

    //实现接口中的函数
    public int CompareTo(IComparable comp)
    {
        TimeSpan compareTime = (TimeSpan)comp;

        if (totalSeconds > compareTime.Seconds)
            return 1;
        else if (compareTime.Seconds == totalSeconds)
            return 0;
        else
            return -1;
    }
}
class Tester
{
    public static void Main()
    {
        TimeSpan myTime = new TimeSpan(3450);
        TimeSpan worldRecord = new TimeSpan(1239);

        if (myTime.CompareTo(worldRecord) < 0)
            Console.WriteLine("My time is below the world record");
        else if (myTime.CompareTo(worldRecord) == 0)
            Console.WriteLine("My time is the same as the world record");
        else
            Console.WriteLine("I spent more time than the world record holder");
    }
}
