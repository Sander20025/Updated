using Microsoft.AspNetCore.Mvc;
using SmartFunds.Ui.Webapp.Data;
using SmartFunds.Ui.Webapp.Models;

namespace SmartFunds.Ui.Webapp.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly SmartFundsDbContext _dbContext;

        public OrganizationController(SmartFundsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var organizations = _dbContext
                .Organizations
                .ToList();

            return View(organizations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return View(organization);
            }

            _dbContext.Organizations.Add(organization);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var organization = _dbContext
                .Organizations
                .SingleOrDefault(o => o.Id == id);

            if (organization is null)
            {
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        [HttpPost]
        public IActionResult Edit(int id, Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return View(organization);
            }

            var dbOrganization = _dbContext
                .Organizations
                .SingleOrDefault(o => o.Id == id);

            if (dbOrganization is null)
            {
                return RedirectToAction("Index");
            }

            dbOrganization.Name = organization.Name;
            dbOrganization.Type = organization.Type;
            dbOrganization.CompanyNumber = organization.CompanyNumber;
            dbOrganization.Email = organization.Email;

            _dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var organization = _dbContext
                .Organizations
                .SingleOrDefault(o => o.Id == id);

            if (organization is null)
            {
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        [HttpPost("[controller]/Delete/{id:int?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var organization = _dbContext
                .Organizations
                .SingleOrDefault(o => o.Id == id);

            if (organization is null)
            {
                return RedirectToAction("Index");
            }

            _dbContext.Organizations.Remove(organization);

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
