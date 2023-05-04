using CommonLibrary;
using MVCPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCPrcatice.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MVCPrcatice.Models;

using System.Data;
using System.Reflection;
//using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using MVCPractice.Services;
using Grpc.Core;

namespace MVCPrcatice.Controllers
{
    public class ITems
    {
        public string value { get; set; }

        public string text { get; set; }
    }
    public class CustomerController : Controller
    {

        private readonly CustomerRepository _customerRepository;

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public CustomerController(CustomerRepository customerRepository, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _customerRepository = customerRepository;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
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
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    var fileExtension = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString() + fileExtension;
                    var filePath = Path.Combine(_configuration.GetSection("FileUpload:ProfilePicturePath").Value, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    user.ImageUrl = fileName;
                }

                GetMongoCollection().InsertOne(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }



        public IActionResult IsEmailExist(string email)
        {
            var customer = _customerRepository.GetEmailCustomer(email);

            if (customer.Count == 0)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }



        public ActionResult ExportCustomers()
        {
            try
            {
                // Get all customers and convert to list
                var customers = GetMongoCollection().Find(Builders<Customer>.Filter.Empty).ToList();

                // Set the file name and path
                var fileName = "customers.csv";
                var filePath = Path.Combine(_configuration.GetSection("FileUpload:ProfilePicturePath").Value, fileName);

                // Write the CSV file
                CommonFunctions.WriteCSV(customers, filePath);

                // Download the CSV file
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "text/csv", fileName);
            }
            catch
            {
                return RedirectToAction("Index");
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
        public ActionResult Edit(Customer customer, IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    // delete old file, if exists
                    if (!string.IsNullOrEmpty(customer.ImageUrl))
                    {
                        var oldFilePath = Path.Combine(_configuration.GetSection("FileUpload:ProfilePicturePath").Value, customer.ImageUrl);
                        System.IO.File.Delete(oldFilePath);
                    }

                    // upload new file
                    var fileExtension = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString() + fileExtension;
                    var filePath = Path.Combine(_configuration.GetSection("FileUpload:ProfilePicturePath").Value, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    customer.ImageUrl = fileName;
                }

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


        public ActionResult GetCustomer(string id)
        {
            var customer = GetMongoCollection().Find(c => c.Id == id).FirstOrDefault();
            if (customer == null)
            {
                customer = new Customer();
            }
            return PartialView("CreateEditCustomer", customer);
        }



        public ActionResult Search(string search, int page = 1, string sortby = "name", string orderby = "asc")
        {

            var cookie = Request.Cookies["search"];
            if(!string.IsNullOrEmpty(cookie) && string.IsNullOrEmpty(search)) 
            {
                search = cookie;
            
            }

            var objcustomers = _customerRepository.SearchCustomer(search, sortby, orderby, page, pageSize: 3);
            ViewBag.search = search;
            ViewBag.sortby = sortby;

            orderby = (orderby == "asc" ? "desc" : "asc");
            ViewBag.orderby = orderby;

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddSeconds(60);
            if (search != null && search.Length > 0)
                _contextAccessor.HttpContext.Response.Cookies.Append("search", search, options);
            //_contextAccessor.HttpContext.Response.Cookies.Append("Customer", Newtonsoft.Json.JsonConvert.SerializeObject(objcustomers), options);
            //_contextAccessor.HttpContext.Response.Cookies.Append("Mahediali", "Mahediali@gmail.com", options);

            return View(objcustomers);
        }



        public ActionResult ReadCookie()
        {
            var cookie = Request.Cookies["Mahediali"];
            string objCookie = _contextAccessor.HttpContext.Request.Cookies["Mahediali"];

            return Json(objCookie);
        }
        public ActionResult CookieDelete()
        {
            var cookie = Request.Cookies["Mahediali"];
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddSeconds(-2);
            _contextAccessor.HttpContext.Response.Cookies.Append("Mahediali", "", options);
            return Json("Delete");

        }

        //// POST: Customer/Reset
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Reset()
        //{
        //    // Delete the "search" cookie
        //    if (Request.Cookies["search"] != null)
        //    {
        //        Response.Cookies.Delete("search");
        //    }

        //    // Redirect to the Search action with an empty search string
        //    return RedirectToAction("Search", new { search = "" });
        //}

    }

}
