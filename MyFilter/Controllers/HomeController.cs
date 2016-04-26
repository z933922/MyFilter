using MyFilter.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EFcode;
using mogodb;

namespace MyFilter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       [HttpGet]
        public ActionResult Login(string returl = "Index")
        {
            ViewData["returl"] = returl;
            return View();
        }


         public   ActionResult   Mongodb()
       {
         mongo.GetInstance().GetServer();
           return View();
       }

        [HttpPost]
        public ActionResult Login(string pwd,string name)
        {

            List<person> list = new List<person>(); 

            List<Iperson> Iperson1 = new List<MyFilter.Iperson>();

           

            Result<int> result = new Result<int>();
            result.Isok = 0;
            if (pwd == "123456" && name == "123456")
            {
                result.Isok = 1;
                
             //   FormsAuthentication.SetAuthCookie(customer.Id.ToString(), true);
                Blog model = new Blog();
                model.name = "测试名称";
                model.title = "测试标题";
                using ( BlogEnties be = new BlogEnties())
                {
                    if (ModelState.IsValid)
            {
                try
                {
                    be.blosgs.Add(model);
                    be.SaveChanges();
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
                
              
            }
                }
                MyUser myuser = new MyUser() { name="123456",titel="123456"};
               string cookiename=  User.Identity.Name;
                Session["name"] = myuser;
                FormsAuthentication.SetAuthCookie(pwd,true,"");
            }
            else
            {
                result.Message = "用户名或者是密码错误";
            }
            return Json(result,JsonRequestBehavior.AllowGet);

        }


        [AuthorFilter]
        public ActionResult test()
        {
            return View();
        }

        public ActionResult dd()
        {
         FormsAuthentication.SignOut();

            return Redirect("/home/test");
        }


        //  修改图片
        public ActionResult imge()
        {
            return View();
        }

    }
}