using Microsoft.AspNetCore.Mvc;

namespace Movies_WebApp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
