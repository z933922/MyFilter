using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFanXing
{
    class Program
    {
        static void Main(string[] args)
        {
            // 泛型的基础知识的练习学习
            TFan<Nullcalss> tt = new TFan<Nullcalss>();

            Console.WriteLine(tt.status.ToString());

            // static 方法可以在非static的类中 但是调用必须是类自己，不能是实例去调用类。
            //  静态类中的方法必须是静态方法。 反之非静态类中的方法 可以是静态的， 

            stacclass sta = new stacclass();//
            stacclass.mm();
            Console.ReadKey();
        }


        /// <summary>
        ///  测试 静态方法 和静态类的关系
        /// </summary>
        public class stacclass
        {
            
            public void method()
            { 
             }

            public static void  mm()
            {
                
            }
        } 


        public static class st
        {
            public static void xx()
            {
                
            }
        }

        public class Nullcalss
        {

        }

        // 泛型必须是nullclass
         public class classT1<T> where T: Nullcalss
        {

        }


        //  泛型只要是 class
        public class ClassT2<T> where T:class,new()
        {

        }
       
        // 泛型 是结构
       public class ClassT3<T> where T:struct
        {

        }


        public class ClassT4<T>
        {

        }

        public class TFan<T> where T:new()
        {
            public TFan()
            {
                status = 100;

            }
            public int status { set; get; }
            public T Data { set; get; }
        }
    }
}
