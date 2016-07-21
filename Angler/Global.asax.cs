using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Angler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IControllerFactory cfactory=   ControllerBuilder.Current.GetControllerFactory();

             // ViewEngines   视图引擎
             //MvcHandler 


        }


        // public void Application_BeginRequest(object sender, EventArgs e)
        //{
         
        //}

        //public void Application_EndRequest()
        //{
            
        //}

    }
}
