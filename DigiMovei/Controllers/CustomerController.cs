using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigiMovei.Models;
using System.Net;
using DigiMovei.ViewModels;
using System.Data.Entity.Migrations;
using DigiMovei.Helper;



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

            if (ModelState.IsValid)
            {
                customer.BirthDate = customer.BirthDate.Value.ToMiladi();
                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            return Content("ثبت نشد");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customer = db.Customers.Find(id);
            if (customer == null)

                return HttpNotFound();
            customer.BirthDate = Convert.ToDateTime(customer.BirthDate.Value.ToPersian());

            var CustomrForViewModl = new CustomrForViewModl { MembershipTypes = db.MembershipType,
                Customer = customer };

            return View(CustomrForViewModl);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            customer.BirthDate =Convert.ToDateTime(customer.BirthDate.Value.ToPersian());
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
                TempData["EditStat"] = 1;
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["EditStat"] = 0;
                return RedirectToAction("Edit");
            }



        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customer = db.Customers.Find(id);
            if (customer == null)

                return HttpNotFound();


            return View(customer);
        }


        [HttpPost]
    [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            try
            { 

                db.SaveChanges();
                TempData["DeleteStat"] = 1;

            return RedirectToAction("Index");

            }
            catch 
            {

                TempData["DeleteStat"] = 0;
                return RedirectToAction("Delete");
            }
            
        }
    }
}