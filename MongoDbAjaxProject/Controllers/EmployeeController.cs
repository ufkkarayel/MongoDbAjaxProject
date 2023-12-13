using Microsoft.AspNetCore.Mvc;

namespace MongoDbAjaxProject.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
