using Microsoft.AspNetCore.Mvc;
using MVCPrcatice.Models;
using System.Diagnostics;


namespace MVCPrcatice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public JsonResult IsEmailExist(string Email)
        //{
        //    bool isExist = false;

        //    // TODO: Replace the following code with a call to your database to check if the email already exists
        //    var user = db.Users.FirstOrDefault(u => u.Email == Email);
        //    if (user != null)
        //    {
        //        isExist = true;
        //    }

        //    return Json(!isExist, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //}
    }
}