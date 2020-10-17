using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineRegistration.Models;

namespace OnlineRegistration.Controllers
{
    public class SearchController : Controller
    {
        public string eventName { get; private set; }
        public string date { get; private set; }
        // GET: Search
        List<Event> s;
        public ActionResult Index(Event model)
        {

            Database1Entities db = new Database1Entities();

            if (model.eventName != "" || model.date != "")
            {
                s = db.Events.Where(x => x.eventName == model.eventName || x.date == model.date).ToList();

            }
          
                var temp = from x in s
                           select x;
                
            if(!s.Any())
            {
                temp = from x in db.Events
                       select x;
           
            }
            ViewBag.eventName = model.eventName;
            ViewBag.date = model.date;
            return View(temp);
        }

        public ActionResult view(Event model)
        {
            Database1Entities db = new Database1Entities();
           
            if (model.eventName != "")
            {
              s = db.Events.Where(x => x.eventName == model.eventName).ToList();
               
            }else if(date != "")
            {

              s = db.Events.Where(x => x.date == model.date).ToList();
               
            }
            var temp = from x in s
                       select x;
           
            return View(temp);

        }
    }
}