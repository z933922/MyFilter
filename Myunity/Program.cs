using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Myunity
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建容器
            IUnityContainer myioc = new UnityContainer();
            myioc.RegisterType<IKiss,Boy>();

            var boy = myioc.Resolve<IKiss>();

            UnityContainer container = new UnityContainer();
            UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            configuration.Configure(container, "defaultContainer");


            #region  配置文件
            //         <? xml version = "1.0" encoding = "utf-8" ?>
            //< configuration >

            //  < configSections >

            //    < section name = "unity" type = "Microsoft.Practices.Unity.Configuration.UnityConfigurationSection,Microsoft.Practices.Unity.Configuration" />

            //     </ configSections >

            //     < unity >

            //       < containers >

            //         < container name = "defaultContainer" >

            //            < register type = "命名空间.接口类型1,命名空间" mapTo = "命名空间.实现类型1,命名空间" />

            //               < register type = "命名空间.接口类型2,命名空间" mapTo = "命名空间.实现类型2,命名空间" />

            //                </ container >

            //              </ containers >

            //            </ unity >
            //          </ configuration > 
            #endregion

        }


        // 接口
        public interface IKiss
        {
            void kiss();
        }

       
        public class Lily : IKiss
        {

            public IKiss boy;

            public Lily(IKiss boy)
            {
                this.boy = boy;
            }
            public void kiss()
            {
                boy.kiss();
                Console.WriteLine("lily kissing");
            }
        }

        public class Boy : IKiss
        {
            public void kiss()
            {
                Console.WriteLine("boy kissing");
            }
        }
    }
}
