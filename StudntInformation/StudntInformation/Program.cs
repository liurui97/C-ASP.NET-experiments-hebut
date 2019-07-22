using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudntInformation
{
    class Student
    {
        //定义学生类字段
        private string stuno;
        private string name;
        private string sex;

        public string Stuno
        {
            get
            {
                return stuno;
            }
            set
            {
                stuno = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        public Student(string stuno, string name, string sex)
        {
            this.stuno = stuno;
            this.name = name;
            this.sex = sex;
        }

        public void StudentInfo()
        {
            Console.WriteLine("学生信息如下");
            Console.WriteLine("学号：{0}", stuno);
            Console.WriteLine("姓名：{0}", name);
            Console.WriteLine("性别：{0}", sex);
        }
    }
    class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入学生的学号：");
            string stuno = Console.ReadLine();
            Console.WriteLine("请输入学生的姓名：");
            string name = Console.ReadLine();
            Console.WriteLine("请输入学生的性别：");
            string sex = Console.ReadLine();

            Student student = new Student(stuno, name, sex);
            student.StudentInfo();
            Console.WriteLine();

            //修改学生信息
            student.Stuno = "164574";
            student.Sex = "男";
            
            Console.WriteLine("修改后的学生信息为：");
            student.StudentInfo();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
