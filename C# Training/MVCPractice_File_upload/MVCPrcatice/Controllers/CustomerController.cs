using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Driver;
using MVCPrcatice.Controllers;
using MVCPrcatice.Models;
using System.Web;

//using System.Web.Mvc;


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



        public JsonResult IsEmailAvailable(string email)
        {
            bool isEmailAvailable = !_configuration.GetSection("Customers").GetChildren().Any(c => c["Email"] == email);
            return Json(isEmailAvailable);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                //if (Request.Form.Files.Count > 0)
                //{
                //    var file = Request.Form.Files[0];
                //    var filepath = "D:\\C# Mahediali_GIT\\C# Training\\MVCPractice_File_upload\\MVCPrcatice\\ProfilePicture";
                //    var extension = Path.GetExtension(file.FileName);
                //    var fileName = "my-file-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extension;
                //    var path = Path.Combine(filepath, fileName);
                //    file.SaveAs(path);
                //    user.FileName = fileName; // update the customer object with the filename
                //}
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



        //public ActionResult Upload(HttpPostedFileBase file)
        //{
        //    if (file != null && file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //        file.SaveAs(path);
        //        ViewBag.Message = "File uploaded successfully";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "You have not specified a file.";
        //    }
        //    return View();
        //}





        //[HttpGet]
        //public ActionResult UploadFile()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult UploadFile(IFormFile file)
        //{
        //    try
        //    {
        //        if (file.Length > 0)
        //        {
        //            string _FileName = Path.GetFileName(file.FileName);
        //            string _path = Path.Combine(_webHostEnvironment.WebRootPath, "ProfilePicture", _FileName);
        //            using (var stream = new FileStream(_path, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //        }
        //        ViewBag.Message = "File Uploaded Successfully!!";
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "File upload failed!!";
        //        return View();
        //    }
        //}



    }
}







//private readonly IConfiguration _configuration;
//private readonly IWebHostEnvironment _webHostEnvironment;

//public CustomerController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
//{
//    _configuration = configuration;
//    _webHostEnvironment = webHostEnvironment;
//}
