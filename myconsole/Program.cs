using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Net;
using NHibernate;
using NHibernate.Cfg;
namespace myconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region   反射类
            ////  反射类
            //Type t = typeof(MyClass);
            //MyClass my = new MyClass(2, 4);
            //// 反射                               如果有重载的方法 后面的是参数类型的 就能够确定调用那个方法了。
            //MethodInfo method = t.GetMethod("Sum", new Type[] { typeof(int), typeof(int) });

            //MethodInfo method1 = t.GetMethod("Sum",null);
            //Console.WriteLine(method.Invoke(my, new object[] { 1, 2 }));

            //// 反射枚举
            //Type t1 = typeof(Myenum);
            //FieldInfo[] fin = t1.GetFields(BindingFlags.GetField);
            //foreach (FieldInfo item in fin)
            //{
            //    Console.WriteLine(item.Name + "--" + (int)item.GetValue(null));
            //}

            //Console.ReadKey();

            //// 委托
            //// 无参数
            //Action a = new Action(Alert);
            //Action aa = () => { Console.WriteLine("拉买不到、"); };
            //a();
            ////有参数
            //Action<string> a1 = new Action<string>(Alert1);
            //a1("KG");

            //Func<int, int, int> f = new Func<int, int, int>(Add);

            //int c = f(1, 2);
            //Console.WriteLine(c);

            //HttpWebRequest hwb = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
            //WebClient clicent = new WebClient();
            //string html = clicent.DownloadString("http://www.baidu.com");

            //Console.Write(html); 
            #endregion

            Configuration cfg = new Configuration();
            cfg.Configure();

            Console.ReadKey();

        }

#region    反射类的
		        ////没有返回值,没有参数的的方法
        //public static void Alert()
        //{
        //    Console.WriteLine("Alert");
        //}

        //// 有参数的返回值
        //public static void Alert1(string name)
        //{
        //    Console.WriteLine("Alert1：" + name);
        //}

        //public static int Add(int a, int b)
        //{
        //    return (a + b);
        //}

        //public enum Myenum
        //{
        //    Yes = 1,
        //    NO = 0

        //}
        //class MyClass
        //{
        //    int x;
        //    int y;
        //    public MyClass(int i, int j)
        //    {
        //        this.x = i;
        //        this.y = j;
        //    }
        //    public int Sum()
        //    {
        //        return x + y;
        //    }

        //    public int Sum(int a, int b)
        //    {
        //        return a + b;
        //    }

        //    public void Show()
        //    {
        //        Console.WriteLine("x: " + x + "  y:  " + y);
        //    } 
	#endregion
      //  }
    }
}
