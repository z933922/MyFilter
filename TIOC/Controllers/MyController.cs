﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TIOC.Controllers
{
    public class MyController : Controller
    {

        //IHttpControllerActivator
        // GET: My
        public ActionResult Index()
        {
            return View();
        }
    }
}