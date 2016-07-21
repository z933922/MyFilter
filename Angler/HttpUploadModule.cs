using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Angler
{
    //实现IHttpModule接口
    public class HttpUploadModule : IHttpModule
    {
        public HttpUploadModule()
        {

        }

        public void Init(HttpApplication application)
        {
            //订阅事件
            application.BeginRequest += new EventHandler(this.Application_BeginRequest);
          
        }

        public void Dispose()
        {
        }

        private void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            HttpWorkerRequest request = GetWorkerRequest(app.Context);
            Encoding encoding = app.Context.Request.ContentEncoding;

            int bytesRead = 0;  // 已读数据大小
            int read;           // 当前读取的块的大小
            int count = 8192;   // 分块大小
            byte[] buffer;      // 保存所有上传的数据

            if (request != null)
            {
                // 返回 HTTP 请求正文已被读取的部分。
                byte[] tempBuff = request.GetPreloadedEntityBody(); //要上传的文件

                // 如果是附件上传
                if (tempBuff != null && IsUploadRequest(app.Request))    //判断是不是附件上传
                {
                    // 获取上传大小
                    // 
                    long length = long.Parse(request.GetKnownRequestHeader(HttpWorkerRequest.HeaderContentLength));

                    buffer = new byte[length];
                    count = tempBuff.Length; // 分块大小

                    // 将已上传数据复制过去
                    //
                    Buffer.BlockCopy(tempBuff,  //源数据
                        0,                      //从0开始读
                        buffer,                 //目标容器
                        bytesRead,              //指定存储的开始位置
                        count);                 //要复制的字节数。


                    // 开始记录已上传大小
                    bytesRead = tempBuff.Length;

                    // 循环分块读取，直到所有数据读取结束
                    while (request.IsClientConnected() && !request.IsEntireEntityBodyIsPreloaded() && bytesRead < length)
                    {
                        // 如果最后一块大小小于分块大小，则重新分块
                        if (bytesRead + count > length)
                        {
                            count = (int)(length - bytesRead);
                            tempBuff = new byte[count];
                        }

                        // 分块读取
                        read = request.ReadEntityBody(tempBuff, count);

                        // 复制已读数据块
                        Buffer.BlockCopy(tempBuff, 0, buffer, bytesRead, read);

                        // 记录已上传大小
                        bytesRead += read;

                    }
                    if (request.IsClientConnected() && !request.IsEntireEntityBodyIsPreloaded())
                    {
                        // 传入已上传完的数据
                        InjectTextParts(request, buffer);
                    }
                }
            }
            app.Context.Response.Write("<hr><h1 style='color:#f00'>来自HttpModule的处理，请求开始</h1>");
        }


        HttpWorkerRequest GetWorkerRequest(HttpContext context)
        {

            IServiceProvider provider = (IServiceProvider)HttpContext.Current;
            return (HttpWorkerRequest)provider.GetService(typeof(HttpWorkerRequest));
        }

        /// <summary>
        /// 传入已上传完的数据
        /// </summary>
        /// <param name="request"></param>
        /// <param name="textParts"></param>
        void InjectTextParts(HttpWorkerRequest request, byte[] textParts)
        {
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

            Type type = request.GetType();

            while ((type != null) && (type.FullName != "System.Web.Hosting.ISAPIWorkerRequest"))
            {
                type = type.BaseType;
            }

            if (type != null)
            {
                type.GetField("_contentAvailLength", bindingFlags).SetValue(request, textParts.Length);
                type.GetField("_contentTotalLength", bindingFlags).SetValue(request, textParts.Length);
                type.GetField("_preloadedContent", bindingFlags).SetValue(request, textParts);
                type.GetField("_preloadedContentRead", bindingFlags).SetValue(request, true);
            }
        }

        private static bool StringStartsWithAnotherIgnoreCase(string s1, string s2)
        {
            return (string.Compare(s1, 0, s2, 0, s2.Length, true, CultureInfo.InvariantCulture) == 0);
        }

        /// <summary>
        /// 是否为附件上传
        /// 判断的根据是ContentType中有无multipart/form-data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool IsUploadRequest(HttpRequest request)
        {
            return StringStartsWithAnotherIgnoreCase(request.ContentType, "multipart/form-data");
        }
    }
}
