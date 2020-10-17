using OnlineRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace OnlineRegistration.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            Database1Entities db = new Database1Entities();
            var temp = from x in db.Events
                       select x;
            return View(temp);
        }
        /*public ActionResult Delete(string id)
        {
            Database1Entities db = new Database1Entities();
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            TempData["message"] = "Deleted Successfully";
            return RedirectToAction("Index", "Event");
        }

        public ActionResult Edit( string id)
        {
            Database1Entities db = new Database1Entities();
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Event model)
        {
            
            Database1Entities db = new Database1Entities();
                
                    db.Events.Add(model);
                    db.SaveChanges();
            
            TempData["message"] = "Registered Successfully";
            return RedirectToAction("Index", "Event");
        }
        [HttpPost]
        public ActionResult Update(Event model)
        {
            Database1Entities db = new Database1Entities();
            var ev = db.Events.First(a => a.eventName == model.eventName);
             db.Entry(model).State = EntityState.Modified;
            ev.eventName = model.eventName;
            ev.date = model.date;
            ev.location = model.location;
            ev.description = model.description;
            ev.ticketFee = model.ticketFee;
            db.SaveChanges();


            TempData["message"] = "Update Successfully";
            return RedirectToAction("Index", "Event");
        }
        */
        
    }
}