using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineRegistration.Models;

namespace OnlineRegistration.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Client model)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities db = new Database1Entities())
                {
                    db.Clients.Add(model);
                    db.SaveChanges();
                    ModelState.Clear();
                    model = null;
                    TempData["message"] = "User Registration Successfully Done";
                    return RedirectToAction("ViewClient", "Client");
                }
            }
            return View(model);
        }

        public ActionResult viewClient(Client model)
        {
            Database1Entities db = new Database1Entities();
            var temp = from x in db.Clients
                       select x;
            return View(temp);
        }


        public ActionResult Edit()
        {
            Database1Entities db = new Database1Entities();
            var temp = from x in db.Clients
                       select x;
            return View(temp);
        }
       

        [HttpPost]
        public ActionResult Update(Client model)
        {
            Database1Entities db = new Database1Entities();
            bool isValid = db.Clients.ToList().Exists(p => p.email.Equals(model.email, StringComparison.CurrentCultureIgnoreCase));
          
            if (isValid)
            {
                var ev = db.Clients.First(a => a.email == model.email);
                ev.address = model.address;
                ev.phone = model.phone;
                db.SaveChanges();


                TempData["message"] = "Update Successfully";
                return RedirectToAction("viewClient", "Client");
            }

            TempData["message"] = "Email does not exist, Please Enter Correct Email";
            return RedirectToAction("Edit", "Client");
        }


    }

}