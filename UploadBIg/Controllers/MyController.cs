using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadBIg.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult  myindex()
        {
            
            IServiceProvider provider = (IServiceProvider)HttpContext;
            HttpWorkerRequest wr = (HttpWorkerRequest)provider.GetService(typeof(HttpWorkerRequest));
            return View();
        }
    }
}