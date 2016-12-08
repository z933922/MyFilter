using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace WebAPi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // 注册映射
            Mapper.Initialize(T =>
            {
                T.CreateMap<Student, Dstudent>();
                // T.CreateMap<CalendarEvent, CalendarEventForm>().ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.EventDate.Date))//
                T.CreateMap<CalendarEvent, CalendarEventForm>().ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.EventDate.Date));
                T.CreateMap<CalendarEvent, CalendarEventForm>().ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.EventDate.Hour));
                T.CreateMap<CalendarEvent, CalendarEventForm>().ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.EventDate.Minute));
                // 字段相对应的

            }
            );
        }
    }
}
