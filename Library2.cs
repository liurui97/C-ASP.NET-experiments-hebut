using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2
{
    class Card
    {
        //定义私有成员
        public string title;
        public string author;
        public int number;

        //定义构造函数
        public Card()
        {
            title = "";
            author = "";
            number = 0;
        }

        //定义有参构造函数
        public Card(string title,string author,int number)
        {
            this.title = title;
            this.author = author;
            this.number = number;
        }

        //定义入库函数
        public void Store()
        {
            Console.WriteLine("《{0}》入库成功!", title);
        }

        //定义出库函数
        public void Show()
        {
            Console.WriteLine("书名：{0}", title);
            Console.WriteLine("作者：{0}", author);
            Console.WriteLine("馆藏数量：{0}", number);
        }

        //按照书名进行排序
        public static void SortTitle(Card[] card)
        {
            Card temp = new Card();
            for (int i = 0; i < card.Length - 1; i++)
            {
                for (int j = 0; j < card.Length - i - 1; j++)
                {
                    if (card[i].title.CompareTo(card[i + 1].title) > 0)
                    {
                        temp = card[i];
                        card[i] = card[i + 1];
                        card[i + 1] = temp;
                    }
                }
            }
        }

        //按照作者进行排序
        public static int partition(Card[] card, int low, int high)
        {
            Card pivot = card[low];
            while (low < high)
            {
                while (low < high && card[high].author.CompareTo(pivot.author) > 0)
                    high--;
                card[low] = card[high];
                while (low < high && card[low].author.CompareTo(pivot.author) <= 0)
                    low++;
                card[high] = card[low];
            }
            card[low] = pivot;
            return low;
        }
        public static void SortAuthor(Card[] card,int low,int high)
        {
            /*Card temp = new Card();
            for (int i = 0; i < card.Length - 1; i++)
            {
                for (int j = 0; j < card.Length - i - 1; j++)
                {
                    if (card[i].author.CompareTo(card[i + 1].author) > 0)
                    {
                        temp = card[i];
                        card[i] = card[i + 1];
                        card[i + 1] = temp;
                    }
                }
            }*/
            int loc = 0;
            if (low < high)
            {
                loc = partition(card, low, high);
                SortAuthor(card, low, loc - 1);
                SortAuthor(card, loc + 1, high);
            }
        }

        //按照入库量进行排序
        public static void SortNumber(Card[] card)
        {
            Card temp = new Card();
            /*for (int i = 0; i < card.Length - 1; i++)
            {
                for (int j = 0; j < card.Length - i - 1; j++)
                {
                    if (card[i].number > card[i + 1].number)
                    {
                        temp = card[i];
                        card[i] = card[i + 1];
                        card[i + 1] = temp;
                    }
                }
            }*/
            for (int i = 0; i < card.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < card.Length; j++)
                {
                    if (card[j].number < card[min].number)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = card[i];
                    card[i] = card[min];
                    card[min] = temp;
                }
            }
        }

        //定义主函数
        static void Main(string[] args)
        {
            Console.WriteLine("请输入将要入库的书的数量：");
            int count = Convert.ToInt32(Console.ReadLine());
            string title;
            string author;
            int number;

            Card[] card = new Card[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("请输入第{0}本入库的书的书名：",i + 1);
                title = Console.ReadLine();
                Console.WriteLine("请输入第{0}本入库的书的作者：", i + 1);
                author = Console.ReadLine();
                Console.WriteLine("请输入第{0}本入库的书的数量：", i + 1);
                number = Convert.ToInt32(Console.ReadLine());

                card[i] = new Card(title, author,number);

                card[i].Store();
                card[i].Show();
            }

            Console.WriteLine("图书入库完毕，请选择查看功能！");
            Console.WriteLine("1.按书名进行排序\t2.按作者进行排序\t3.按入库量进行排序\t4.退出");
            int choice;
            while((choice=Convert.ToInt32(Console.ReadLine()))!=4){
                switch (choice)
                {
                    case 1:
                        Card.SortTitle(card);
                        for (int i = 0; i < count; i++)
                        {
                            card[i].Show();
                        }
                        break;
                    case 2:
                        Card.SortAuthor(card,0,card.Length-1);
                        for (int i = 0; i < count; i++)
                        {
                            card[i].Show();
                        }
                        break;
                    case 3:
                        Card.SortNumber(card);
                        for (int i = 0; i < count; i++)
                        {
                            card[i].Show();
                        }
                        break;
                    default:
                        Console.WriteLine("输入错误，感谢您的使用！");
                        break;
                }
            }
            Console.WriteLine("欢迎下次使用！");
            Console.ReadLine();
        }
    }
}
