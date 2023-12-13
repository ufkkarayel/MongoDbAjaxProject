using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbAjaxProject.DAL.Entities;
using MongoDbAjaxProject.DAL.Settings;

namespace MongoDbAjaxProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMongoCollection<Employee> _employeeCollection;
        public EmployeeController(IDatabaseSettings _databaseSettings)
        {
            var client= new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _employeeCollection = database.GetCollection<Employee>(_databaseSettings.EmployeeCollectionName);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
