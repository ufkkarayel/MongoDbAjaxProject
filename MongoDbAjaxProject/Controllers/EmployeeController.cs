using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;
using MongoDbAjaxProject.DAL.Entities;
using MongoDbAjaxProject.DAL.Settings;
using Newtonsoft.Json;

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
        [HttpGet]
        public IActionResult Ekle() 
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Ekle(Employee employee)
        {
            await _employeeCollection.InsertOneAsync(employee);
            return RedirectToAction("Index");
        }
        public async Task< IActionResult> EmployeeList()
        {
            var values = await _employeeCollection.Find(x => true).ToListAsync();
            var jsonEmployess = JsonConvert.SerializeObject(values);
            return Json(jsonEmployess);
        }
    }
}


//var values = await _categoryCollection.Find(x => true).ToListAsync();
//return View(values);