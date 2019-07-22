using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        //定义图书isbn、标题、作者、出版社、价格等私有数据成员
        private readonly string isbn;
        private string title;
        private string author;
        private string press;
        private double price;

        //定义isbn属性只读
        public string Isbn
        {
            get
            {
                return isbn;
            }
        }

        //定义书名属性
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                    title = value;
            }
        }

        //定义作者属性
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (author != value)
                    author = value;
            }
        }

        //定义出版社属性
        public string Press
        {
            get
            {
                return press;
            }
            set
            {
                if (press != value)
                    press = value;
            }
        }

        //定义价格属性
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price != value)
                {
                    price = value;
                }
            }
        }

        //定义无参构造函数
        public Book(){
            title = "未知";
            author = "未知";
            press = "未知";
            price = 0;
            isbn = "未知";
        }

        //定义有参构造函数
        public Book(string isbn):this()
        {
            this.isbn = isbn;
        }

        //定义成员方法
        public void Show()
        {
            Console.WriteLine("书号：{0}",isbn);
            Console.WriteLine("书名：{0}", title);
            Console.WriteLine("作者：{0}", author);
            Console.WriteLine("出版社：{0}", press);
            Console.WriteLine("价格：{0}", price);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("第一个构造函数：");
            Book book1 = new Book();
            book1.Show();
            Console.WriteLine("");

            Console.WriteLine("第二个构造函数：\n请输入图书的isbn：");      
            Book book2 = new Book(Console.ReadLine());
            book2.Show();

            Console.ReadLine();
        }
    }
}
