using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Driver;
using MVCPrcatice.Models;

namespace MVCPrcatice.Controllers
{
    public class ITems
    {
        public string value { get; set; }

        public string text { get; set; }
    }
    public class CustomerController : Controller
    {

        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IMongoCollection<Customer> GetMongoCollection()
        {
            // Get the MongoDB connection string and database name from appsettings.json
            string connectionString = _configuration.GetSection("MongoDB:ConnectionString").Value;
            string databaseName = _configuration.GetSection("MongoDB:Database").Value;

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase(databaseName);

            // Get the MongoDB collection for the Customer model
            return database.GetCollection<Customer>("Users");
        }


        // GET: Customer
        public ActionResult Index()
        {
            // Get all users from MongoDB
            var users = GetMongoCollection().Find(Builders<Customer>.Filter.Empty).ToList();

            return View(users);
        }



        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }   


        // GET: Customer/Create
        public ActionResult Create()
        {
           
            return View();
        }



        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer user)
        {
            try
            {
                // Insert a new user into MongoDB
                GetMongoCollection().InsertOne(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            // Get a customer by Id from MongoDB
            var customer = GetMongoCollection().Find(x => x.Id == id).FirstOrDefault();

            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                // Update a customer in MongoDB
                var updateResult = GetMongoCollection().ReplaceOne(x => x.Id == customer.Id, customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




 
        // GET: Customer/Delete/5
        public ActionResult Delete(string id)
        {
            // Find the customer by ObjectId from MongoDB
            var customer = GetMongoCollection().Find(x => x.Id == id).FirstOrDefault();

            if (customer == null)
            {
    
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // Delete the customer by ObjectId from MongoDB
                GetMongoCollection().DeleteOne(x => x.Id == id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
