using Microsoft.AspNetCore.Mvc;

namespace ApplicatonProcess.December2020.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
