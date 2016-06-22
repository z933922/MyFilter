using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace multithreadin
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(TestMethod));// 定义一个多线程
           // t1.Start();
           

            Action weituoAction = () => { Console.WriteLine("这个是不带菜蔬的委托"); }; // 定义一个委托

            Action<object> weituoaction1 = (object str) => { Console.WriteLine("这个是委托传进来的参数:" + str); };// 定义一个有参数的委托
            t1 = new Thread(new ThreadStart(weituoAction));
            t1.Start();

       
            t1 = new Thread(new ParameterizedThreadStart(weituoaction1)); 
            t1.Start("Action的参数");// 传值
            Func<object, object> weituofun2 = (object num) => { return num; }; // 定义一个有参数，有返回值的委托
           // t1 = new Thread(new ParameterizedThreadStart(weituofun2));
            Func<int, int> weituofunint = (int num) => { return num; };// 定义一个有参数，有返回值的委托

            IAsyncResult iasy = weituofunint.BeginInvoke(10, null, null);  // 异步 调用
             int resultnum=  weituofunint.EndInvoke(iasy);// 异步调用 得到结果

            Console.WriteLine("2016年5月23日14:58:18");

            Action a = () => { Console.WriteLine("没有参数的方法"); };// 没有参数的委托
            Action<object> a1=(object tempt)=>{ Console.WriteLine("输入的参数是："+ tempt); };// 带有参数的action 反应出我的基础知识不好 忘记了 这写发
            Func<int, int> f = (int fnum) => { return fnum++; };//带有参数，并且有返回值的 这个写法还是记得呢
            Thread t2 = new Thread(new ThreadStart(a));
            t2.Start();

            t2 = new Thread( new ParameterizedThreadStart(a1));
            t2.Start("哈哈");
            t2.Start();

             


            Console.ReadKey();

        }

        public static void TestMethod()
        {
            Console.WriteLine("不带参数的线程函数");
        }

        public static void TestMethod1(object str)
        {
            Console.WriteLine("带有参数的线程方法：参数--"+str);

        }
    }
}
