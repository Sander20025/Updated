using Microsoft.AspNetCore.Mvc;
using SmartFunds.Ui.Webapp.Data;
using SmartFunds.Ui.Webapp.Models;

namespace SmartFunds.Ui.Webapp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly SmartFundsDbContext _dbContext;

        public TransactionsController(SmartFundsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var organization = _dbContext.Organizations.SingleOrDefault(o => o.Id == id);
            if (organization is null)
            {
                return RedirectToAction("Index", "Organization");
            }

            var transactions = _dbContext.Transactions
                .Where(t => t.OrganizationId == id)
                .ToList();

            //ViewBag.Organization = organization;
            ViewData["Organization"] = organization;

            return View(transactions);
        }

        [HttpGet]
        public IActionResult Create(int organizationId)
        {
            var transaction = new Transaction
            {
                OrganizationId = organizationId,
                Owner = string.Empty,
                Remarks = string.Empty
            };
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return View(transaction);
            }

            transaction.TimeStamp = DateTime.UtcNow;

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new{Id = transaction.OrganizationId});
        }

        [HttpPost("[controller]/Delete/{id:int?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var transaction = _dbContext
                .Transactions
                .SingleOrDefault(o => o.Id == id);

            if (transaction is null)
            {
                return RedirectToAction("Index", "Organization");
            }

            _dbContext.Transactions.Remove(transaction);

            _dbContext.SaveChanges();

            return RedirectToAction("Index", new{Id = transaction.OrganizationId});
        }
    }
}
