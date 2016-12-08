using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TestRequre
{
    public class ModuleExample : IHttpModule
    {
        public ModuleExample()
        {
        }
        public void Init(HttpApplication context)
        {
            context.LogRequest += App_Handler;
        }


    public void App_Handler(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            if (context.CurrentNotification == RequestNotification.LogRequest)
            {
                if (!context.IsPostNotification)
                {
                    // Put code here that is invoked when the LogRequest event is raised.
                }
                else
                {
                    // PostLogRequest
                    // Put code here that runs after the LogRequest event completes.
                }
            }

        }
        public void Dispose()
        {
            
        }

    }
}