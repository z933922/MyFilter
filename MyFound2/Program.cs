#define debug
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RDL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CodeFirst;
using System.Threading;
namespace MyFound2
{


    class Program
    {
         static object o = new object();
        static void Main(string[] args)
        {


            #region code first

        

          Thread tt = new Thread(codeupdate);
            Thread t2 = new Thread(new ThreadStart(codeupdate2));
            t2.Start();
             tt.Start();

            Console.WriteLine("xxx");




            #endregion

            #region 测试读
            IndexC myindex = new IndexC();
            TReadLony Tr = new TReadLony();
            #endregion

            // readlony  可以在构造函数中 和初始化的时候


            #region  测试反射
            Assembly assem = Assembly.Load("RDL");
            Type myclass = assem.GetType("RDL.Rtclass");
            MethodInfo info = myclass.GetMethod("Show");
           
       
         
             Rtclass rc=  (Rtclass)Activator.CreateInstance(myclass);
            info.Invoke(Activator.CreateInstance(myclass), null);
            #endregion


            Console.ReadKey();



            #region MyRegion
            Method();
#if debug
            Console.WriteLine("debug");
            Method();
#warning "你忘记了做一件很重要的失去了"

#elif release
            console.WriteLine("release");

#endif
            #endregion

            #region  抽象方法中的static 可以在子类中调用也可以在抽象类中直接调用
            SXAbs.Say();
            Abs.Say(); 
            #endregion

        }

        public static void codeupdate()
        {
            Console.WriteLine("codeupdate");

            lock(o)
            { 
            using (Model1 model = new Model1())
            {
                var dbstudent = model.dbStudent;
                List<Student> list = new List<Student>();
                for (int i = 0; i < 5; i++)
                {
                    Student student = new Student();
                    student.StuName = " A" + i.ToString();
                    list.Add(student);
                }

                dbstudent.AddRange(list);
                model.SaveChanges();
            }
            }
        }

        public static void codeupdate2()
        {
            Console.WriteLine("codeupdate2");
            lock (o)
            {
                using (Model1 model = new Model1())
                {
                    var dbstudent = model.dbStudent;
                    List<Student> list = new List<Student>();
                    for (int i = 0; i < 5; i++)
                    {
                        Student student = new Student();
                        student.StuName = " B" + i.ToString();
                        list.Add(student);
                    }

                    dbstudent.AddRange(list);
                    model.SaveChanges();
                }
            }

        }

        #region 测试readylony conts static readlony
        public class TReadLony
        {
            public const int Num = 0;
            public readonly int Num2 = 1;
            public static readonly int Num3= 1;
            public TReadLony()
            {
             //   Num2 = 25;
            }

            static TReadLony()
            {
                Num3 = 100;
            }

            public void TUpdateNum()
            {
               // Num2 = 12;
            }
        }
        #endregion

        [ConditionalAttribute("debug")]
        public  static void Method()
        {
            Console.WriteLine("123");
        }

        public class Father
        {
            public Father (string name)
            {
                
            }

            public Father()
            {
                
            }
        }

        public class Son : Father
        {
            public Son(string name):base(name)
            {
            }

            public Son():this("哈哈")
            {
            }
        }

#region MyRegion 测试类的索引期待
        /// <summary>
        ///  测试 类的索引器 的
        /// </summary>
        public class IndexC
        {
            List<int> list = new List<int>();
            public int this[int operm]
            {
                get { return list[operm]; }
                set { list[operm] = value; }
            }
        }
        #endregion

        #region  自己联系 attribute

        /// <summary>
        ///   针对属性  不能被继承  不能被多次使用
        /// </summary>
        [AttributeUsage(AttributeTargets.Property,Inherited =false,AllowMultiple =false)]
        public sealed class TrimAttribute : Attribute
        {
            private readonly Type type;

            public TrimAttribute(Type type)
            {
                this.type = type;
            }

            public Type Type
            {
                get { return this.type; }
            }

          
        }


        public static class TrimAttributeExtension
        {
           
        }

        public  abstract class Abs
        {
            public abstract void SayHI();

            public virtual void xx()
            {

            }

            public static void Say()
            {
            }

        }

        public class SXAbs : Abs
        {
            public override void SayHI()
            {
                
            }

            public override void xx()
            {
                base.xx();
            }

           
        }

        public class Fanxie
        {

            public void SayHi<Y>(string str) where Y:new()
            {
            }

            public void SayHi(string str)
            {
            }
        }

        #endregion


# region
        public class NoStatic
        {

            public static string str;

            public string NoStaticstr;
            static NoStatic()
            {
                str = "123132";
            }

            public NoStatic()
            {
                str = "123132";
                NoStaticstr = "234234";
            }
        }
        #endregion


    }
}