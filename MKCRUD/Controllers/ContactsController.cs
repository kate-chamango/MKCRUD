using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MKCRUD.Models;
namespace MKCRUD.Controllers
{
    public class ContactsController : Controller
    {
        private ContactsDBEntities db= new ContactsDBEntities();

        // GET: Contacts/Index
        public ActionResult Index()
        {
            using (ContactsDBEntities db = new ContactsDBEntities())
                return View(db.Employees.ToList());
        }
        [HttpPost]
        public ActionResult Index(string SearchTerm)
        {

            List<Employee> employee;
            if (string.IsNullOrEmpty(SearchTerm))
            {
                employee = db.Employees.ToList();
            }
            else
            {
                employee = db.Employees.Where(c => c.FirstName.StartsWith(SearchTerm)).ToList();
            }
            return View(employee);
        }
            // GET: Contacts/Details/5
            public ActionResult Details(int id)
        {
         using (ContactsDBEntities db = new ContactsDBEntities())

         return View(db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault()); ;
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContactsDBEntities db = new ContactsDBEntities())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            using (ContactsDBEntities db = new ContactsDBEntities())

           return View(db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault()); ;
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                using (ContactsDBEntities db = new ContactsDBEntities())
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            using (ContactsDBEntities db = new ContactsDBEntities())

                return View(db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault()); ;
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                using (ContactsDBEntities db = new ContactsDBEntities())
                {
                    employee = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
