using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Angler
{
    public class TestMoudul : IHttpModule
    {
        void IHttpModule.Dispose()
        {
          
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }


        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

            response.Write("context_BeginRequest >> 在 ASP.NET 响应请求时作为 HTTP 执行管线链中的第一个事件发生");
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

            response.Write("context_EndRequest >> 在 ASP.NET 响应请求时作为 HTTP 执行管线链中的最后一个事件发生");

            
        }
    }
}