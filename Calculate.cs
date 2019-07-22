using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    //定义一个委托类型
    public delegate double Calculation(int first,int second);

    class DeleTest
    {
        //计算两数之和
        public double Add(int first,int second)
        {
            return first + second;            
        }

        //计算两数平均值
        public double Average(int first,int second)
        {
            return (first + second) / 2.0;
        }
    }

    public class Result
    {
        static void Main()
        {
            Console.WriteLine("请输入第一个数的值：");
            int first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入第二个数的值：");
            int second = Convert.ToInt32(Console.ReadLine());

            DeleTest deletest = new DeleTest();
            Calculation cal1 = new Calculation(deletest.Add);
            Console.WriteLine("{0}与{1}的和为：{2}", first, second, cal1(first,second));

            Calculation cal2 = new Calculation(deletest.Average);
            Console.WriteLine("{0}与{1}的平均值为：{2}", first, second, cal2(first,second));
        }
    }
}
