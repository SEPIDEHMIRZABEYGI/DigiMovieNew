using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigiMovei.Models;
using System.Net;
using DigiMovei.ViewModels;


namespace DigiMovei.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db;
        public CustomerController()
        {
            db = new ApplicationDbContext();
        }
        
            
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customer = db.Customers.Find(id);
            if (customer == null)

                return HttpNotFound();

            return View(customer);
        }

       
        public ActionResult create()
        
{
            
            var CustomrForViewModl = new CustomrForViewModl { MembershipTypes = db.MembershipType };
            db.SaveChanges();
            return View(CustomrForViewModl);
        }
         [HttpPost]
        public ActionResult create(Customer customer)
        {
            //var customer = new Customer { Name = Name, IsSubscribedToNewsLetter = true, BirthDate = BirthDate ,MembershipTypeID=1};
            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}