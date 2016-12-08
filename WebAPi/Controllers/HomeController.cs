using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace WebAPi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";


            var calendarEvent = new CalendarEvent
            {
                EventDate = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };
            CalendarEventForm form = Mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);
            return Json(form,JsonRequestBehavior.AllowGet);
        }
    }
}
