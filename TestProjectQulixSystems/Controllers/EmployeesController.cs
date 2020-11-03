using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestProjectQulixSystems.Models;

namespace TestProjectQulixSystems.Controllers
{
    public class EmployeesController : Controller
    {
        IEmployeeRepository repo;
        public EmployeesController(IEmployeeRepository r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            ViewBag.Companies = repo.GetCompanies();
            return View(repo.GetEmployees());
        }

        public ActionResult Details(int id)
        {
            Employee Employee = repo.Get(id);
            if (Employee != null)
                return View(Employee);
            return NotFound();
        }

        public ActionResult Create()
        {
            ViewBag.Id = repo.GetNextId();
            ViewBag.Companies = repo.GetCompanies();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee Employee)
        {
            repo.Create(Employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Employee Employee = repo.Get(id);
            ViewBag.Companies = repo.GetCompanies();
            if (Employee != null)
                return View(Employee);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Employee Employee)
        {
            repo.Update(Employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Employee Employee = repo.Get(id);
            if (Employee != null)
                return View(Employee);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
