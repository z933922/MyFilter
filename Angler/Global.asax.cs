using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            HttpApplication app = HttpContext.Current.ApplicationInstance;
            StringBuilder sb = new StringBuilder();

            foreach (string module in app.Modules.AllKeys)
                sb.AppendFormat(module).Append("<br />");

        

        }



        // public void Application_BeginRequest(object sender, EventArgs e)
        //{

        //}

        //public void Application_EndRequest()
        //{

        //}

    }
}
