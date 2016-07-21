using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UploadBIg
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        
            
        }

        public void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        public void Application_EndRequest()
        {

        }

        #region
        //    public void Init(HttpApplication application)
        //    {
        //        //订阅事件         
        //        application.BeginRequest += new EventHandler(this.Application_BeginRequest); 
        //    }
        //protected void Application_BeginRequest(object sender, EventArgs e)
        //    {
        //        HttpApplication ha = sender as HttpApplication;
        //        HttpContext context = ha.Context;

        //        if (ha.Context.Request.ContentLength > 1000)//1000 is the max size
        //        {
        //            IServiceProvider provider = (IServiceProvider)context;
        //            HttpWorkerRequest wr = (HttpWorkerRequest)provider.GetService(typeof(HttpWorkerRequest));
        //            //FileStream fs = null;
        //            // Check if body contains data
        //            if (wr.HasEntityBody())
        //            {
        //                // get the total body length
        //                int requestLength = wr.GetTotalEntityBodyLength();
        //                // Get the initial bytes loaded
        //                int initialBytes = 0; //wr.GetPreloadedEntityBody().Length;

        //                if (!wr.IsEntireEntityBodyIsPreloaded())
        //                {
        //                    byte[] buffer = new byte[100];
        //                    // Set the received bytes to initial bytes before start reading
        //                    int receivedBytes = initialBytes;
        //                    while (requestLength - receivedBytes >= initialBytes)
        //                    {
        //                        // Read another set of bytes
        //                        initialBytes = wr.ReadEntityBody(buffer, buffer.Length);
        //                        // Write the chunks to the physical file

        //                        // Update the received bytes
        //                        receivedBytes += initialBytes;
        //                    }
        //                    initialBytes = wr.ReadEntityBody(buffer, requestLength - receivedBytes);

        //                }
        //            }
        //            //fs.Flush();
        //            //fs.Close();
        //        }
        //    }
        #endregion
    }
}
