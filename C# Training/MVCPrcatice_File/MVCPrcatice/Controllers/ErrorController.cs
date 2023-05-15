using Microsoft.AspNetCore.Mvc;

namespace MVCPrcatice.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
