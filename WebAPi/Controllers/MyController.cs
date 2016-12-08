using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPi;
using AutoMapper;

namespace WebAPi.Controllers
{
    public class MyController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Test(int id=0)
        {
            Student stumodel = new Student() { id = 1, name = "我是你大爷" };


            var calendarEvent = new CalendarEvent
            {
                EventDate = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };
            CalendarEventForm form = Mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);



            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}