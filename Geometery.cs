using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    //定义基类圆
    public class Circle
    {
        public double radius;

        public Circle(double radius){
            this.radius=radius;
        }
    }

    //定义派生类球
    class Sphere : Circle
    {
        public Sphere(double radius):base(radius)
        {
        }

        //求面积函数
        public double Square()
        {
            return 4 * Math.PI * radius * radius;
        }

        //球体积函数
        public double Volume()
        {
            return 4/3 * Math.PI * radius * radius * radius;
        }

        //显示函数
        public void Show()
        {
            Console.WriteLine("球体面积为：{0}", Square());
            Console.WriteLine("体积为：{0}", Volume());
        }
    }

    //定义派生类圆柱体
    public class Cylinder : Circle
    {
        public double height;

        public Cylinder(double height,double radius):base(radius)
        {
            this.height = height;
        }
        
        //面积
        public double Square(){
            return 2 * Math.PI * radius * radius + 2 * Math.PI * radius * height;
        }

        //体积
        public double Volume()
        {
            return Math.PI * radius * radius * height;
        }
        public void Show()
        {
            Console.WriteLine("圆柱体面积为：{0}", Square());
            Console.WriteLine("体积为：{0}", Volume());
        }
    }

    //定义一个圆锥体
    public class Cone : Circle
    {
        public double height;
      
        public Cone(double height,double radius):base(radius)
        {
            this.height = height;
        }

        //面积
        public double Square()
        {
            return Math.PI * radius * height + Math.PI * radius * radius;
        }

        //体积
        public double Volume()
        {
            return (1 / 3.0) * Math.PI * radius * radius * height;
        }

        public void Show()
        {
            Console.WriteLine("圆锥面积为：{0}", Square());
            Console.WriteLine("体积为：{0}", Volume());
        }
    }
    public class Calculate{
        public static void Main(){

            Console.WriteLine("请输入球体半径：");
            try
            {
                double radious = Convert.ToDouble(Console.ReadLine());
                Sphere sphere=new Sphere(radious);
                sphere.Show();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("球体半径格式有误!");
            }

            try
            {
                Console.WriteLine("请输入圆柱体半径、高：");
                double radious = Convert.ToDouble(Console.ReadLine());
                double height = Convert.ToDouble(Console.ReadLine());
                Cylinder cylinder = new Cylinder(radious, height);
                cylinder.Show();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("圆柱体半径、高格式有误!");
            }

            try
            {
                Console.WriteLine("请输入圆锥体半径、高：");
                double radious = Convert.ToDouble(Console.ReadLine());
                double height = Convert.ToDouble(Console.ReadLine());
                Cone cone = new Cone(radious,height);
                cone.Show();
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("圆锥体半径、高格式有误!");
                Console.ReadLine();
            }
        }
        
    }
}