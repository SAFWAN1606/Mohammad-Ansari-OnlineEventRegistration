using OnlineRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Register u)
        {
            if (ModelState.IsValid)
            {


                using (Database1Entities db = new Database1Entities())
                {
                    bool isValidEmail = db.Clients.ToList().Exists(p => p.email.Equals(u.email, StringComparison.CurrentCultureIgnoreCase));
                    bool isValidEvent = db.Events.ToList().Exists(p => p.eventName.Equals(u.eventName, StringComparison.CurrentCultureIgnoreCase));
                    if(isValidEmail && isValidEvent)
                    {
                        db.Register.Add(u);
                        db.SaveChanges();
                        ModelState.Clear();
                        u = null;

                        TempData["message"] = "User Registration Successfully Done";
                        return RedirectToAction("ViewRegister", "Registration");

                    }
                    else
                    {
                        TempData["message"] = "Client Email or Event Name does not match";
                        return RedirectToAction("index", "Registration");
                    }
                   
                }
            }
            return View(u);
        }
        public ActionResult ViewRegister(Register model)
        {
            Database1Entities db = new Database1Entities();
            var temp = from x in db.Register
                       select x;
            return View(temp);
        }
        public ActionResult Delete()
        {
            Database1Entities db = new Database1Entities();
            var temp = from x in db.Register
                       select x;
            return View(temp);
        }

        [HttpPost]
        public ActionResult DeleteEvent(Register model)
        {
            Database1Entities db = new Database1Entities();
            List<Register> en = db.Register.Where(x => x.eventName == model.eventName && x.email==model.email).ToList();
            if(en.Any())
            {
                foreach(var findData in en)
                {
                    db.Register.Remove(findData);
                }
                db.SaveChanges();
                TempData["message"] = "Your Registration Succesfully Deleted";
                return RedirectToAction("ViewRegister", "Registration");
            }
            TempData["message"] = "Data does not exist - Please Check Your Email Address and Event Name";
            return RedirectToAction("Delete", "Registration");

        }
    }
}