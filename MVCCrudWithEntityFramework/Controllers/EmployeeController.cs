using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrudWithEntityFramework.Models;
using System.Data.Entity;


namespace MVCCrudWithEntityFramework.Controllers
{
    public class EmployeeController : Controller
    {

        MyDbModel dbmodel = new MyDbModel();

        // GET: Employee
        public ActionResult Index(string search)

        {
            

            using (MyDbModel dbmodel = new MyDbModel())

            {
                //return View(dbmodel.Employees.ToList());
                return View(dbmodel.Employees.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }

            






        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (MyDbModel dbmodel = new MyDbModel())
            {
                return View(dbmodel.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());
            }
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (MyDbModel dbmodel = new MyDbModel())
                {
                    dbmodel.Employees.Add(employee);
                    dbmodel.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (MyDbModel dbmodel = new MyDbModel())
            {
                return View(dbmodel.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                using (MyDbModel dbmodel = new MyDbModel())
                {
                    dbmodel.Entry(employee).State = EntityState.Modified;
                    dbmodel.SaveChanges();


                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (MyDbModel dbmodel = new MyDbModel())
            {
                return View(dbmodel.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());
            }
        }

        //POST: Employee/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (MyDbModel dbmodel = new MyDbModel())
                {
                    Employee employee = dbmodel.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
                    dbmodel.Employees.Remove(employee);
                    dbmodel.SaveChanges();
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
