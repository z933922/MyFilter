using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Net;
using NHibernate;
using NHibernate.Cfg;
using Foundation;
using System.Collections;
using System.IO;
using Spring.Context;
using Spring.Context.Support;
using Spring.Core.IO;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Xml;

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

            //Configuration cfg = new Configuration();
            //cfg.Configure();

            TrunAbstract myclass = new TrunAbstract();

            #region   迭代器
            int[] myarray = { 10,1, 2, 3, 4 };
            IEnumerator myie = myarray.GetEnumerator();
            
            myarray[4] = 20;
            myie.Reset();
            while (myie.MoveNext())
            {
                int tempint = (int)myie.Current;
              
               //Console.WriteLine(tempint);
            }

            #endregion

            #region 多继承接口
            //   XianshiClass xianshi = new XianshiClass();
            //   IMyinterface Myinterface = new XianshiClass();
            //    // 全类目实现的接口 只能用借口来调用的


            //   Base baseclass = new Base();
            //   Console.WriteLine(" Base :");
            //   baseclass.ShowNum();

            //   IMoreInter morebase = new Base();
            // //  Console.WriteLine(" IMoreInter-base :");
            //   morebase.ShowNum();
            //   morebase.ShowStr();

            //   SonClass son = new SonClass();

            //  // Console.WriteLine(" SonClass :");
            //   son.ShowNum();
            //   IMoreInter more = new SonClass();

            ////   Console.WriteLine(" IMoreInter-SonClass :");
            //   more.ShowNum();
            //   more.ShowStr();


            //   TclassInter tclass = new TclassInter(520);
            //       Console.WriteLine("TclassInter:");
            //   tclass.ShowNum();

            //   tclass.ShowStr();
            //   ITest20 It20 = tclass as ITest20;
            //   Console.WriteLine("ITest20:");
            //   It20.ShowNum();
            //   It20.ShowStr();
            //   Console.WriteLine("ITest22:");
            //   ITest22 I222 = tclass as ITest22;
            //   I222.ShowNum();

            #endregion


            #region  继承 类的
            //TclassSon son = new TclassSon();
            //son.SayHi();

            //Tclassbase father = new Tclassbase();
            //father.SayHi();
            //father = son as TclassSon;
            //father.SayHi();

            //D3sonClass d3son = new D3sonClass();
            //d3son.ShowNum1();
            //d3son.ShowNum2();

            //Console.WriteLine("_______________________");
            //D3class d3base = new D3sonClass();
            //d3base.ShowNum1();
            //d3base.ShowNum2();

            //Console.WriteLine("_______________________");

            //D3class d3 = new D3class();
            //d3.ShowNum1();
            //d3.ShowNum2(); 
            #endregion


            #region  联系 反射 

            //  Type classType = typeof(fanshe);

            //  fanshe shiti = new fanshe();

            // MethodInfo  method=classType.GetMethod("ShowNum",new Type[] { });
            //  method.Invoke(shiti,null);
            //   method = classType.GetMethod("ShowNum", new Type[] { typeof(string) });
            //  method.Invoke(shiti, new object[] { "2"});

            //  method = classType.GetMethod("ReturnNum", new Type[] { typeof(int) });
            //int num = (int)method.Invoke(shiti, new object[] { 2 });   // 这种情况 效率一定 低 因为要拆箱
            //  #endregion

            //  #region IO的一些操作
            //  DirectoryInfo dir = Directory.CreateDirectory("D://test.text");
            //  foreach (string  item in Directory.GetFileSystemEntries("D://test.text"))
            //  {
            //      if (File.Exists(item))
            //      {
            //         // File.Delete(item);
            //      }
            //      else
            //      {

            //      }
            //  }

            //  string[] names = Directory.GetFiles("D://test.text");
            //  string[] names3 = Directory.GetFileSystemEntries("D://test.text");

            //  foreach (string item in names)
            //  {
            //      if (File.Exists(item))
            //      {

            //          using (StreamWriter  sw=File.CreateText(item))
            //          {
            //              sw.WriteLine(" 你是个大傻逼");
            //              sw.WriteLine(" 你是个大傻逼ff");
            //          }
            //      }

            //      if (File.Exists(item))
            //      {
            //          using (StreamReader sr=File.OpenText(item))
            //          {
            //              sr.Read();
            //          }

            //      }
            //  }
            #endregion


            Father sontofather = new son();
           var tt=   sontofather.num;
            sontofather.ShowNum();
            sontofather.ShowStr();

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int r1 = 0;
            int r2 = 100;

            int tempt = 0;
            IList<Func<int>> funcs = new List<Func<int>>();
            funcs.Add(() => { return (tempt + 1); });
            funcs.Add(() => { return (tempt -2); });

            foreach (var f in funcs)
            {
                int tint = f();
                Console.WriteLine(" 此时此刻的 的返回值："+tint.ToString());
            }

            var attems = AppDomain.CurrentDomain.GetAssemblies();
            //foreach (Assembly item in attems)
            //{
            //    foreach (Type type in item.GetTypes())
            //    {
            //        foreach (MemberInfo infor in type.GetMembers())
            //        {
            //            //Console.WriteLine("名称： {0}，Type：{1}",infor.Name,infor.MemberType.ToString());
            //        }
            //    }
            //}


            string second = new string('T', 5);

            var Tl = Toss<string>("你是个大傻逼");


             int i = 100;
            object o = i;
            i = 200;
            int i1 = (int)o;


            #region 联系spring.net

            IResource input = new FileSystemResource("Objects.xml");  //路径----这里使用的是相对路径，也可以使用绝对路径，如果路径错了会报异常

            IObjectFactory factory = new XmlObjectFactory(input);
            IService person = factory.GetObject("EFUserInfoDal") as EFUserInfoDal;

            IApplicationContext ctx = ContextRegistry.GetContext();
             IService service = ctx.GetObject("EFUserInfoDal") as EFUserInfoDal;

            //No context registered.Use the 'RegisterContext' method or the 'spring/context' section from your configuration file.
           service.Show();


            #endregion



            Console.ReadKey();

        }

        public static string ToStr<T>(List<T> @object, char differentiate = '=', char separator = '&')
             where T : new()
         {
            return "str";
          }


        public static T Toss<T>(T tempt)  
        {
            T rr = default(T);

            return rr;
        }
    public  class fanshe
        {

            public void ShowNum()
            {
              //  Console.WriteLine("这是没有参数的方法");
            }

            public void ShowNum(string num)
            {
               // Console.WriteLine(" 这个是带参数的方法 参数值=" + num.ToString());
            }

            public   int ReturnNum(int num)
            {
                return num;
            }
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
