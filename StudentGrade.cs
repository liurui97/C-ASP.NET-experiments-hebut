using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrade
{
    class Student
    {
        private string stuno;
        private string name;
        private double grade;
        private static int studentNumber = 0;
        private static double sumGrade = 0;
        private static double avgGrade = 0;

        public Student(string stuno,string name,double grade){
            this.stuno=stuno;
            this.name=name;
            this.grade=grade;
            studentNumber++;
            sumGrade += grade;
        }

        public void studentInfo()
        {
            Console.WriteLine("学号：{0}", stuno);
            Console.WriteLine("姓名：{0}", name);
            Console.WriteLine("成绩：{0}", grade);
        }

        public static void sumInfo()
        {
            Console.WriteLine("学生总人数：{0}", studentNumber);
            Console.WriteLine("学生总成绩：{0}", sumGrade);
            avgGrade=sumGrade/studentNumber;
            Console.WriteLine("平均成绩{0}", avgGrade);
        }
    }
    class Class1
    {
        static void Main(string[] args)
        {
            Student[] student=new Student[3];
            string stuno;
            string name;
            double grade;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("请输入第{0}个学生的学号",i+1);
                stuno = Console.ReadLine();
                Console.WriteLine("请输入第{0}个学生的姓名",i+1);
                name = Console.ReadLine();
                Console.WriteLine("请输入第{0}个学生的成绩", i+1);
                grade = Convert.ToDouble(Console.ReadLine());
                student[i] = new Student(stuno, name, grade);
            }
            for (int j = 0; j <3 ; j++)
            {
                student[j].studentInfo();
            }
            Student.sumInfo();
            Console.ReadLine();
        }
    }
}
