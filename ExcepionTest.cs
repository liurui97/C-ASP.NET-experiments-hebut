using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTest
{
    public class Meteorologist
    {
        public int[] rainfall = new int [12];
        public int[] pollution = new int [12];

        //定义有参构造函数
        public Meteorologist(int[] rainfall,int[] pollution)
        {
            try
            {
                for (int i = 0; i < 12; i++)
                {
                    this.rainfall[i] = rainfall[i];
                    this.pollution[i] = pollution[i];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Meteorologist构造函数中数组发生越界！");
            }
            catch (FormatException e)
            {
                Console.WriteLine("月份格式不正确!");
            }
        }

        //返回数组元素
        public int GetRainFall(int index)
        {
            try
            {
                return rainfall[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("GetRainFall函数中数组发生越界！");
                return -1;
            }
            catch (FormatException e)
            {
                Console.WriteLine("污染物格式不正确！");
                return -1;
            }
        }

        //计算降雨量中污染物的含量
        public int GetAveragePollution(int index)
        {
            try
            {
                return pollution[index] / rainfall[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("GetAveragePollution函数中数组发生越界！");
                return -1;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("GetAveragePollution函数中除数为0！");
                return -1;
            }
        }

    }
    public class Test
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("请输入rainfall数组的数值，以空格间隔：");
                string[] rainfallStr=Console.ReadLine().Split(' ');
                int[] rainfall = new int[rainfallStr.Length];
                for (int i = 0; i < rainfallStr.Length; i++)
                {
                    rainfall[i] = Convert.ToInt32(rainfallStr[i]);
                }

                Console.WriteLine("请输入pollution数组的数值，以空格间隔：");
                string[] pollutionStr = Console.ReadLine().Split(' ');
                int[] pollution = new int[pollutionStr.Length];
                for (int i = 0; i < pollutionStr.Length; i++)
                {
                    pollution[i] = Convert.ToInt32(pollutionStr[i]);
                }

                Meteorologist test = new Meteorologist(rainfall,pollution);

                Console.WriteLine();
                //显示数据
                for (int i = 0; i < rainfall.Length; i++)
                {
                    Console.WriteLine("{0}月降雨量为{1}", i + 1, rainfall[i]);
                    
                }
                
                Console.WriteLine("请输入您想查看的月份:");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("{0}月单位降雨量中的污染物含量为：{1}", index, test.GetAveragePollution(index - 1));
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("主函数中格式转换有误！");
            }
            catch (FormatException e)
            {
                Console.WriteLine("数据格式有误！");
            }
        }
    }
}