using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebAPi
{
    public class Student
    {
        public int id { set; get; }

        public string name { set; get; }
    }

    public class Dstudent
    {
        public int id { set; get; }
    }


    public class CalendarEvent
    {
        public DateTime EventDate { get; set; }
        public string Title { get; set; }
    }

    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
    }

    public class Configuration
    {
        public static void Configure()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile<Profiles.SourceProfile>();
            //    cfg.AddProfile<Profiles.OrderProfile>();
            //    cfg.AddProfile<Profiles.CalendarEventProfile>();
            //});




        }
    }
}