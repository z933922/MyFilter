using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    #region 抽象方法

     public abstract class ChouXiang1
     {
         public void ParentShowNum()
         {
             
         }
         public abstract void ParentAbstact();
     }
    public abstract class Chouxiang:ChouXiang1
    {
        int num = 1;
        private void privateShowNum()
        {
            Console.Write(num);
        }

        public void PublicShowNum()
        {
            Console.Write(num);
        }

        /// <summary>
        ///  覆盖父类中的方法
        /// </summary>
        public  new   void ParentShowNum()
        {

        }

        public override void ParentAbstact()
        {
            throw new NotImplementedException();
        }
        public abstract void MyMethod();
    }
    #endregion

    #region  接口
    public interface IMyJkeou
    {
        // int num = 0; 接口是不能包含字段
        int num { set; get; }
        void ShowNum();
    }

    #endregion

#region   实现抽象类
    public class TrunAbstract : Chouxiang
     {
       /// <summary>
       ///  实现 抽象父类中的方法
       /// </summary>
         public override void MyMethod()
         {
             throw new NotImplementedException();
         }

       
     }
#endregion


#region  抽象类实现接口

    public interface ImyTestForAbstruct
    {
        void ShowNum();
        void ShowNum1();
    }
    public abstract class AbsForIne :ImyTestForAbstruct
    {

        // 抽象类是  可以有构造函数
        public AbsForIne()
        {
        }
        public abstract void ShowNum(); // 接口中的方法
        public void ShowNum1()// 实现接口的方法
        {
            Console.WriteLine("ShowNum1");
        }
    }
#endregion

#region  接口显示实现 和隐实实现

    public interface IMyinterface
    {
        void showNum();

        int ReturnNum();
    }

    public interface Imyinterface2
    {
        void showNum();

        double ReturnNum();
    }

    public class XianshiClass : IMyinterface, Imyinterface2
    {

        #region  接口 IMyinterface
        /// <summary>
        ///  显示实现接口
        /// </summary>
        void IMyinterface.showNum()
        {
            Console.WriteLine("显示实现接口IMyinterface.showNum");
        }
        /// <summary>
        ///  显示实现接口
        /// </summary>
        int IMyinterface.ReturnNum()
        {
            return 1;
        } 
        #endregion
        #region  显示实现接口 Imyinterface2
        /// <summary>
        ///  显示实现接口
        /// </summary>
        void Imyinterface2.showNum()
        {
            Console.WriteLine("显示实现接口Imyinterface2.showNum");
        }
        /// <summary>
        ///  显示实现接口
        /// </summary>
        double Imyinterface2.ReturnNum()
        {
            return 2.0;
        } 
        #endregion
    }

    public class YinShiClass : IMyinterface, Imyinterface2
    {
         void IMyinterface.showNum()
        {
            Console.WriteLine("隐士实现接口IMyinterface.showNum");
        }
        
         void Imyinterface2.showNum()
        {

            Console.WriteLine("隐士实现接口Imyinterface2.showNum".AddString());
        }

         int IMyinterface.ReturnNum()
        {
            return 11;
        }

          double Imyinterface2.ReturnNum()
        {
            return 11.0;

          
        }
    }
    
#endregion


#region 扩展方法

    // 扩展方法  第一 必须是静态类  第二参数第一个 this 要扩展的类型 变量
    public static class ExtandString
    {
        public static string AddString(this string  str)
        {
            return str+"这是我扩展的";
        }
    }

    
#endregion

#region  继承
    public class perple
    {
        public virtual void ShowPeople()
        {
            Console.WriteLine("Show的showpeople");
        }

        public  void ShowNum()
        {
            Console.WriteLine("this is show Num come form people");
        }
    }

    public class spaiderpeolpe : perple
    {
        /// <summary>
        ///  重新写基类中的方法
        /// </summary>
        public override void ShowPeople()
        {
            Console.WriteLine("spaiderpeolpe的showpeople");

            base.ShowPeople();
        }

        public new   void ShowNum()
        {

        }
    }
#endregion

#region 多继承 1
    public interface IMoreInter
    {
        void ShowNum();

        void ShowStr();
    }

    public class Base:IMoreInter
    {
        /// <summary>
        ///  隐士的实现接口
        /// </summary>
        public void ShowNum()
        {
            Console.WriteLine("base :ShowNum");
        }

        /// <summary>
        ///  显示实现接口不需要加修饰符
        /// </summary>
        void IMoreInter.ShowStr()
        {
            Console.WriteLine("base : ShowStr");
        }
    }

    public class SonClass:Base,IMoreInter
    {

       /// <summary>
       ///   覆盖 base 类 中的 ShowNum 的方法
       /// </summary>
        public new void ShowNum()
        {
            Console.WriteLine("SonClass :ShowNum");
        }


        /// <summary>
        ///  覆盖父类中的 IMoreInter.ShowStr   不需要new 关键字 
        /// </summary>
        void IMoreInter.ShowStr()
        {
            Console.WriteLine("SonClass : ShowStr");
        }
    }
#endregion

#region  多继承2
    public interface ITest20
    {
        void ShowNum();

        void ShowStr();
    }

    public interface ITest21:ITest20
    {
        void ShowNum21();
    }

    public interface ITest22
    {
        void ShowNum();
    }

    public class TclassInter : ITest20, ITest22
    {
        int Num;
         public TclassInter(int Num)
        {
            this.Num = Num;
        }
        public void ShowNum()
        {
            Console.WriteLine(Num);
        }

        public void ShowStr()
        {
            Console.WriteLine("ShowStr");
        }

    }

    public class Tclassbase
    {
        public void SayHi()
        {
            Console.WriteLine("base:SayHi");
        }

        public int ReturnNum()
        {
            return 1;
        }

        public virtual int ReturnNum1()
        {
            return 11;
        }
    }

    public class TclassSon:Tclassbase
    {
        public new  void SayHi()
        {
            Console.WriteLine("TclassSon:SayHi");
        }

        public override int ReturnNum1()
        {
            return base.ReturnNum1();
        }

        public new double ReturnNum()
        {
            return 12.0;
        }

    }
#endregion

#region 多继承3
    public class D3class
    {
        public void ShowNum1()
        {
            Console.WriteLine("base: ShowNum1");
        }

        public virtual void ShowNum2()
        {
            Console.WriteLine("base: ShowNum2");
        }
    }

     public class D3sonClass:D3class
     {
         public new void ShowNum1()
         {
             Console.WriteLine("D3sonClass: ShowNum1");
         }

         public override void ShowNum2()
         {
             Console.WriteLine("D3sonClass: ShowNum2");
         }

      

     }

    #endregion

    #region 测试继承问题
     public class  Father
    {
        public Father()
        {

        }
        public virtual int num
        {
            get
            {
                return 0;
            }

        }

        private int pnum = 1;

        protected int bhnum = 2;

        public void ShowNum()
        {
            Console.WriteLine("  这个是 父类的");
        }

        public virtual void ShowStr()
        {
            Console.WriteLine("  这个是 父类的");
        }
    }

    public class son:Father
    {
        public son():base()
        {

        }
        private int pnum = 4;

        protected int bhnum = 5;

        public override int num
        {
            get
            {
                return 3;
            }

           
        }

        public void ShowNum()
        {
            Console.WriteLine("  这个是 子类的");
        }

        public override void ShowStr()
        {
            Console.WriteLine("  这个是 自类的类的");
        }
    }
    #endregion
}
