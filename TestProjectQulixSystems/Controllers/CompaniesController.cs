using Microsoft.AspNetCore.Mvc;
using TestProjectQulixSystems.Models;

namespace TestProjectQulixSystems.Controllers
{
    public class CompaniesController : Controller
    {
        ICompanyRepository repo;
        public CompaniesController(ICompanyRepository r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            return View(repo.GetCompaniesIndex());
        }

        public ActionResult Details(int id)
        {
            Company Company = repo.Get(id);
            if (Company != null)
                return View(Company);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company Company)
        {
            if (ModelState.IsValid)
            {
                var isValidate = repo.Create(Company);
                if (isValidate)
                {
                    return (RedirectToAction("Index"));
                }
                else
                {
                    ModelState.AddModelError("Id", "Please,enter valid data");
                    return View(Company);
                }
            }
            else
            {
                return View(Company);
            }
        }

        public ActionResult Edit(int id)
        {
            Company Company = repo.Get(id);
            if (Company != null)
                return View(Company);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Company Company)
        {
            var isValidate = repo.Update(Company);
            if (isValidate)
            {
                return (RedirectToAction("Index"));
            }
            else
            {
                ModelState.AddModelError("Id", "Please,enter valid data");
                return View(Company);
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Company Company = repo.Get(id);
            if (Company != null)
                return View(Company);
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

