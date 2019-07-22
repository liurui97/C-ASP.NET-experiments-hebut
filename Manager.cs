using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    //定义雇员基类
    public class Employee
    {
        //定义共有数据成员
        public string name;
        public string address;
        public string birthtime;
        public double wage;

        //定义共同的属性
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!name.Equals(value))
                    name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (!address.Equals(value))
                    address = value;
            }
        }

        public string Birthtime
        {
            get
            {
                return birthtime;
            }
            set
            {
                if (!birthtime.Equals(value))
                    birthtime = value;
            }
        }
        
        //定义无参构造函数
        public Employee()
        {
            name = "";
            address = "";
            birthtime = "";
        }

        //定义有参构造函数
        public Employee(string name, string address, string birthtime)
        {
            this.name = name;
            this.address = address;
            this.birthtime = birthtime;
        }

        //计算工资函数
        public virtual void CalWage(double wage){
            
        }
        //定义输出函数
        public void Show(){
            Console.WriteLine("姓名：{0}",name);
            Console.WriteLine("地址：{0}",address);
            Console.WriteLine("生日：{0}",birthtime);
            Console.WriteLine("工资：{0:C}",wage);
            Console.WriteLine();
        }
    }

    //定义程序员类
    public class Programmer : Employee
    {
        public double basicSalary = 2000;
        public double commission;

        //定义构造函数
        public Programmer(string name, string address, string birthtime)
            : base(name, address, birthtime)
        {

        }
        //计算程序员工资函数
        public override void CalWage(double commission)
        {
            wage = basicSalary + commission;
            Console.WriteLine("程序员工资情况：");
        }
    }
    public class Secretary : Employee
    {
        public double basicSalary = 3000;
        
        //定义构造函数
        public Secretary(string name, string address, string birthtime)
            : base(name, address, birthtime)
        {

        }

        //计算秘书工资
        public new void CalWage()
        {
            wage = basicSalary;
            Console.WriteLine("秘书工资情况：");
        }
    }
    
    //定义高级管理类
    public class Topmanagor : Employee
    {
        public double basicSalary = 5000;
        public double commission;

        //定义构造函数
        public Topmanagor(string name, string address, string birthtime)
            : base(name, address, birthtime)
        {

        }
        public override void CalWage(double commission)
        {
            wage = basicSalary + commission;
            Console.WriteLine("高级主管的工资情况：");
        }
    }

    //定义清洁工类
    public class Cleaner : Employee
    {
        public double basicSalary = 1000;

        //定义构造函数
        public Cleaner(string name, string address, string birthtime)
            : base(name, address, birthtime)
        {

        }
        public new  void CalWage()
        {
            wage = basicSalary;
            Console.WriteLine("清洁工的工资情况：");
        }
    }

    public class test
    {
        static void Main()
        {
            Programmer programmer = new Programmer("刘蕊", "河北工业大学", "1997-07-07");
            programmer.CalWage(10000);
            programmer.Show();
            Topmanagor topmanager = new Topmanagor("史清杰", "河北工业大学", "1998-12-22");
            topmanager.CalWage(10000);
            topmanager.Show();
            Secretary secretary = new Secretary("陈岩", "河北工业大学", "1998-03-17");
            secretary.CalWage();
            secretary.Show();
            Cleaner cleaner = new Cleaner("马思雨", "河北工业大学", "1998-07-11");
            cleaner.CalWage();
            cleaner.Show();
            Console.ReadLine();
        }
               
    }
}
