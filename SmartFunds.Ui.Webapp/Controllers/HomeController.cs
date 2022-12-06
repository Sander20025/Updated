using Microsoft.AspNetCore.Mvc;
using SmartFunds.Ui.Webapp.Data;

namespace SmartFunds.Ui.Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmartFundsDbContext _database;

        public HomeController(SmartFundsDbContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        { 
            var organizations = _database.Organizations.ToList();
            return View(organizations);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}